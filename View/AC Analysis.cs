using Model;
using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;

namespace View
{
    public partial class AC_Analysis : Form
    {
        private static string _text;
        private static bool _write = false;

        // явно захватить делегаты в поля класса, 
        // чтобы экземпляры делегата не были собраны сборщиком мусора
        private SendChar _sc;
        private SendStat _ss;
        private ControlledExit _ce;
        private SendData _sd;
        private SendInitData _sid;
        private BGThreadRunning _bgtrun;
        private Circuit _circuit;

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="circuit"></param>
        public AC_Analysis(Circuit circuit)
        {
            InitializeComponent();
            _circuit = circuit;
        }

        /// <summary>
        /// Метод загружает схему и источник 
        /// для анализа по переменному току
        /// </summary>
        /// <param name="circuit"></param>
        private void LoadNetlist(Circuit circuit)
        {
            _sc = new SendChar(cbSendChar);
            _ss = new SendStat(cbSendStat);
            _ce = new ControlledExit(cbControlledExit);
            _sd = new SendData(cbSendData);
            _sid = new SendInitData(cbSendInitData);
            _bgtrun = new BGThreadRunning(cbBGThreadRunnig);
            int thread = Thread.CurrentThread.ManagedThreadId;

            IntPtr caller = Marshal.AllocHGlobal(Marshal.SizeOf(thread));
            Marshal.StructureToPtr(thread, caller, false);

            Ngspice.ngSpice_Init(
                Marshal.GetFunctionPointerForDelegate(_sc),
                Marshal.GetFunctionPointerForDelegate(_ss),
                Marshal.GetFunctionPointerForDelegate(_ce),
                Marshal.GetFunctionPointerForDelegate(_sd),
                Marshal.GetFunctionPointerForDelegate(_sid),
                Marshal.GetFunctionPointerForDelegate(_bgtrun),
                caller);

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
            // TODO: проверка данных
            Ngspice.ngSpice_Command("circbyline vin " +
                nodeInTB.Text + " " +
                nodeOutTB.Text + " " +
                "ac " +
                magnitudeTB.Text + " " +
                phaseTB.Text);
            Ngspice.ngSpice_Command("circbyline .options noacct");
            Ngspice.ngSpice_Command("circbyline .end");
        }

        /// <summary>
        /// Метод задает параметры и запускает анализ
        /// </summary>
        private void RunAnalysis()
        {
            // TODO: проверка данных
            Ngspice.ngSpice_Command("ac " + 
                variationCB.Text + " " +
                numberOfPointsTB.Text + " " +
                fstartTB.Text + " " +
                fstopTB.Text);
        }

        /// <summary>
        /// Метод получает данные для прорисовки графика
        /// </summary>
        /// <returns></returns>
        private PointPairList GetPointPairsDB()
        {
            PointPairList pointsList = new PointPairList();
            
            string[] substrings = Parser.GetArrayOfData(_text);
            for (int i = 0; i < substrings.Length - 3; i += 3)
            {
                double x = double.Parse(substrings[i + 1], CultureInfo.InvariantCulture);
                double y = double.Parse(substrings[i + 2], CultureInfo.InvariantCulture);
                pointsList.Add(x, y);
            }
            return pointsList;
        }
        /// <summary>
        /// Метод получает данные для прорисовки графика
        /// </summary>
        /// <returns></returns>
        private PointPairList GetPointPairsHZ()
        {
            PointPairList pointsList = new PointPairList();

            string[] substrings = Parser.GetArrayOfData(_text);
            for (int i = 0; i < substrings.Length - 4; i += 4)
            {
                double x = double.Parse(substrings[i + 1], CultureInfo.InvariantCulture);
                double y1 = double.Parse(substrings[i + 2], CultureInfo.InvariantCulture);
                double y2 = double.Parse(substrings[i + 3], CultureInfo.InvariantCulture);
                double y = Math.Sqrt(Math.Pow(y1, 2) + Math.Pow(y2, 2));
                pointsList.Add(x, y);
            }
            return pointsList;
        }

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

        /// <summary>
        /// Обработчик нажатия кнопки btDraw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDraw_Click(object sender, EventArgs e)
        {
            LoadNetlist(_circuit);
            RunAnalysis();
            GraphPane pane = zedGraphControl.GraphPane;
            
            pane.YAxis.MajorGrid.IsZeroLine = false;
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.XAxis.MajorGrid.DashOff = 0;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.DashOff = 0;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.DashOff = 0;
            pane.XAxis.IsAxisSegmentVisible = false;
            pane.CurveList.Clear();
            string[] output = plotNodesTB.Text.Split(',');
            for (int i = 0; i < output.Length; i++)
            {
                _text = "";
                Ngspice.ngSpice_Command("print " + output[i]);
                if (_text != "")
                {
                    PointPairList points;
                    if (Regex.IsMatch(output[i], "vdb"))
                    {
                        points = GetPointPairsDB();
                        pane.XAxis.Type = AxisType.Log;
                    }
                    else
                    {
                        points = GetPointPairsHZ();
                        pane.XAxis.Type = AxisType.Linear;
                    }
                    Random randomGen = new Random();
                    KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                    KnownColor randomColorName = names[randomGen.Next(names.Length)];
                    Color randomColor = Color.FromKnownColor(randomColorName);
                    LineItem curve = pane.AddCurve(output[i], points, randomColor, SymbolType.None);
                    curve.Line.IsSmooth = true;
                }
                else
                {
                    MessageBox.Show("Graph didn't plot. Check parameters and try again.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }

        private void TB_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = "";
            ((TextBox)sender).ForeColor = SystemColors.WindowText;
        }

        private void cancelBT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
