using Model;
using System;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ZedGraph;

namespace View
{
    /// <summary>
    /// Сущность для описания графика
    /// </summary>
    internal class Graph
    {
        /// <summary>
        /// Метод рисует график
        /// </summary>
        /// <param name="zedGraphControl">Компонент ZedGraphControl, в котором нужно нарисовать график</param>
        /// <param name="output">Список того, что нужно отобразить на графике</param>
        public void DrawGraph(ZedGraphControl zedGraphControl, string[] output, int axisType)
        {
            GraphPane pane = zedGraphControl.GraphPane;
            if (axisType == 1)
            {
                pane.XAxis.Type = AxisType.Linear;
            }
            else
            {
                pane.XAxis.Type = AxisType.Log;
            }
            pane.YAxis.MajorGrid.IsZeroLine = false;
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.XAxis.MajorGrid.DashOff = 0;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.DashOff = 0;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.DashOff = 0;
            pane.XAxis.IsAxisSegmentVisible = false;
            pane.CurveList.Clear();
            
            for (int i = 0; i < output.Length; i++)
            {
                AC_Analysis._text = "";
                Ngspice.ngSpice_Command("print " + output[i]);
                if (AC_Analysis._text != "")
                {
                    PointPairList points;
                    if (Regex.IsMatch(output[i], "vdb"))
                    {
                        points = GetPointPairsDB();
                    }
                    else
                    {
                        points = GetPointPairsHZ();
                    }

                    LineItem curve = pane.AddCurve(output[i], points, GetRandomColor(), SymbolType.None);
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

        /// <summary>
        /// Метод получает данные для прорисовки графика DB
        /// </summary>
        /// <returns></returns>
        private PointPairList GetPointPairsDB()
        {
            PointPairList pointsList = new PointPairList();

            string[] substrings = Parser.GetArrayOfData(AC_Analysis._text);
            for (int i = 0; i < substrings.Length - 3; i += 3)
            {
                double x = double.Parse(substrings[i + 1], CultureInfo.InvariantCulture);
                double y = double.Parse(substrings[i + 2], CultureInfo.InvariantCulture);
                pointsList.Add(x, y);
            }
            return pointsList;
        }

        /// <summary>
        /// Метод получает данные для прорисовки графика HZ
        /// </summary>
        /// <returns></returns>
        private PointPairList GetPointPairsHZ()
        {
            PointPairList pointsList = new PointPairList();

            string[] substrings = Parser.GetArrayOfData(AC_Analysis._text);
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

        /// <summary>
        /// Метод генерирует рандомный цвет
        /// </summary>
        private Color GetRandomColor()
        {
            Color randomColor;
            do
            {
                Random randomGen = new Random();
                KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                KnownColor randomColorName = names[randomGen.Next(names.Length)];
                randomColor = Color.FromKnownColor(randomColorName);
            }
            while ((randomColor.GetSaturation() > 0.5)
            &&(randomColor.GetBrightness() > 0.5));
            return randomColor;
        }
    }
}