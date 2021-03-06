﻿using Model;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace View
{
    //TODO: Часть этого класса я бы перенёс в отдельный класс-прослойку, какой-нибудь NGSpiceWrapper
    // BUG: не рассчитывает еали присутсвуют параллельные катушки и последовательные конденсаторы
    /// <summary>
    /// Форма для анализа частотных характеристик
    /// </summary>
    /// //TODO: Название не соответствует стандарту
    public partial class AC_Analysis : Form
    {
        // TODO: узнать можно ли избежать статических полей
        internal static string _text;


        private static bool _isWritten = false;

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
            _sc = cbSendChar;
            _ss = cbSendStat;
            _ce = cbControlledExit;
            _sd = cbSendData;
            _sid = cbSendInitData;
            _bgtrun = cbBGThreadRunnig;
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
                if (Regex.IsMatch(elem.Name, "R"))
                {
                    Ngspice.ngSpice_Command("circbyline " +
                                            elem.Name + " " +
                                            nodes[elements.IndexOf(elem)].Item1 + " " +
                                            nodes[elements.IndexOf(elem)].Item2 + " " +
                                            elem.Value);
                }
                if (Regex.IsMatch(elem.Name, "C"))
                {
                    Ngspice.ngSpice_Command("circbyline rbogus" +
                                            elem.Name + " " +
                                            nodes[elements.IndexOf(elem)].Item1 + " " +
                                            nodes[elements.IndexOf(elem)].Item2 + " 9e12");
                    Ngspice.ngSpice_Command("circbyline " +
                                            elem.Name + " " +
                                            nodes[elements.IndexOf(elem)].Item1 + " " +
                                            nodes[elements.IndexOf(elem)].Item2 + " " +
                                            elem.Value);
                }
                if (Regex.IsMatch(elem.Name, "L"))
                {
                    Ngspice.ngSpice_Command("circbyline rbogus" +
                                            elem.Name + " " +
                                            nodes[elements.IndexOf(elem)].Item1 + " " +
                                            nodes[elements.IndexOf(elem)].Item1 + "a 1e-12");
                    Ngspice.ngSpice_Command("circbyline " +
                                            elem.Name + " " +
                                            nodes[elements.IndexOf(elem)].Item1 + "a " +
                                            nodes[elements.IndexOf(elem)].Item2 + " " +
                                            elem.Value);
                }
            }
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
            Ngspice.ngSpice_Command("ac " +
                                    variationCB.Text + " " +
                                    numberOfPointsTB.Text + " " +
                                    fstartTB.Text + " " +
                                    fstopTB.Text);
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
            string[] output = plotNodesTB.Text.Split(',');
            Graph graph = new Graph();
            graph.DrawGraph(zedGraphControl, output, variationCB.SelectedIndex);
        }

        /// <summary>
        /// Обработчик события нажатия на поле TextBox
        /// </summary>
        private void TextBoxEnter(object sender, EventArgs e)
        {
            ((TextBox) sender).Text = "";
            ((TextBox) sender).ForeColor = SystemColors.WindowText;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку CancelBT
        /// </summary>
        private void CancelBtClick(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Обработчик события изменения значения свойства Text элемента TextBox
        /// </summary>
        private void DoubleTextChanged(object sender, EventArgs e)
        {
            InputDataController.DoubleTextBoxChanged(sender, e);
        }

        /// <summary>
        /// Обработчик события изменения значения свойства Text элемента TextBox
        /// </summary>
        private void IntTextChanged(object sender, EventArgs e)
        {
            InputDataController.IntTextBoxChanged(sender, e);
        }


        private static int cbSendChar(IntPtr param0, int param1, IntPtr param2)
        {
            string message = Marshal.PtrToStringAnsi(param0);
            if (Regex.IsMatch(message, "AC Analysis"))
            {
                _isWritten = true;
            }
            if (_isWritten)
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

        private static int cbControlledExit(int param0, [MarshalAs(UnmanagedType.I1)] bool param1,
            [MarshalAs(UnmanagedType.I1)] bool param2, int param3, IntPtr param4)
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
    }
}