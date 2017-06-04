using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using ZedGraph;
using System.Drawing;
using System.Globalization;

namespace View
{
    public partial class AC_Analysis : Form
    {
        private static string _text;
        private static bool _write = false;
        public AC_Analysis(Circuit circuit)
        {
            InitializeComponent();

            SendChar sc = new SendChar(cbSendChar);
            SendStat ss = new SendStat(cbSendStat);
            ControlledExit ce = new ControlledExit(cbControlledExit);
            SendData sd = new SendData(cbSendData);
            SendInitData sid = new SendInitData(cbSendInitData);
            BGThreadRunning bgtrun = new BGThreadRunning(cbBGThreadRunnig);
            int thread = Thread.CurrentThread.ManagedThreadId;

            IntPtr caller = Marshal.AllocHGlobal(Marshal.SizeOf(thread));
            Marshal.StructureToPtr(thread, caller, false);

            Ngspice.ngSpice_Init(
                Marshal.GetFunctionPointerForDelegate(sc),
                Marshal.GetFunctionPointerForDelegate(ss),
                Marshal.GetFunctionPointerForDelegate(ce),
                Marshal.GetFunctionPointerForDelegate(sd),
                Marshal.GetFunctionPointerForDelegate(sid),
                Marshal.GetFunctionPointerForDelegate(bgtrun),
                caller);

            LoadNetlist(circuit);
            RunAnalysis();

        }

        private void LoadNetlist(Circuit circuit)
        {
            Ngspice.ngSpice_Command("circbyline AC analysis");

            var nodes = circuit.Nodes;
            var elements = circuit.Elements;
            foreach (IElement elem in elements)
            {
                Ngspice.ngSpice_Command("circbyline " + 
                    elem.Name + " " +
                    nodes[elements.IndexOf(elem)].Item1 + " " +
                    nodes[elements.IndexOf(elem)].Item2 + " " +
                    elem.Value);
            }
            //TODO: добавить возможность задавать параметры источника
            Ngspice.ngSpice_Command("circbyline vin 1 0 dc 0 ac 1");
            Ngspice.ngSpice_Command("circbyline .options noacct");
            Ngspice.ngSpice_Command("circbyline .end");
        }

        private void RunAnalysis()
        {
            Ngspice.ngSpice_Command("run");
            //TODO: добавить возможность выбора выходных параметров
            Ngspice.ngSpice_Command("ac dec 10 0.01 100");
            Ngspice.ngSpice_Command("print vdb(2)");
        }

        private PointPairList GetPointPairs()
        {
            PointPairList pointsList = new PointPairList();

            var re = new Regex("stdout ");
            _text = re.Replace(_text, "");

            int index = _text.IndexOf("\t");
            _text = _text.Substring(index - 1);

            char delimiter = '\t';
            string[] substrings = _text.Split(delimiter);

            for (int i = 0; i < substrings.Length - 3; i += 3)
            {
                double x = double.Parse(substrings[i + 1], CultureInfo.InvariantCulture);
                double y = double.Parse(substrings[i + 2], CultureInfo.InvariantCulture);
                pointsList.Add(x, y);
            }
            return pointsList;
        }
        /// <summary>
        /// Функция обратного вызова. Отправляет данные из ngspice вызывающему
        /// </summary>
        /// <param name="param0"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <returns></returns>
        private static int cbSendChar(IntPtr param0, int param1, IntPtr param2)
        {
            string message = Marshal.PtrToStringAnsi(param0);
            if (Regex.IsMatch(message, "AC Analysis"))
            {
                _write = true;
            }
            if (_write)
            {
                _text += message;
            }

            //Console.WriteLine("lib {0}: {1}", param1, message);
            return 1;
        }
        private static int cbSendStat(IntPtr param0, int param1, IntPtr param2)
        {
            string stat = Marshal.PtrToStringAnsi(param0);

            Console.WriteLine("lib {0}: {1}", param1, stat);
            return 1;
        }
        private static int cbControlledExit(int param0, [MarshalAs(UnmanagedType.I1)] bool param1, [MarshalAs(UnmanagedType.I1)] bool param2, int param3, IntPtr param4)
        {
            Console.WriteLine("contolled exit");
            return param0;
        }
        private static int cbSendData(IntPtr param0, int param1, int param2, IntPtr param3)
        {
            return 1;
        }
        private static int cbSendInitData(IntPtr param0, int param1, IntPtr param2)
        {

            return 1;
        }
        private static int cbBGThreadRunnig([MarshalAs(UnmanagedType.I1)] bool param0, int param1, IntPtr param2)
        {
            return 1;
        }

        private void btDraw_Click(object sender, EventArgs e)
        {
            GraphPane pane = zedGraphControl.GraphPane;
            pane.XAxis.Type = AxisType.Log;
            pane.XAxis.Scale.Min = 10E-2;
            pane.XAxis.Scale.Max = 10E+3;
            pane.CurveList.Clear();
            PointPairList points = GetPointPairs();
            LineItem curve = pane.AddCurve("AC", points, Color.Blue, SymbolType.None);
        }
    }
}
