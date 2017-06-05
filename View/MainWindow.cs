using Model;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using System.Numerics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace View
{
    //BUG: Меняем номер узла и ошибка показывается по количеству элементов в цепи
    //BUG: Добавление новых элементов, после переконфигурирования старых - вызывает ошибки
    /// <summary>
    /// Сущность для главного окна программы
    /// </summary>
    public partial class MainWindow : Form
    {

        private Circuit _circuit;
        private List<double> _frequences = new List<double>();
        private List<ElementControl> _elementContolList = new List<ElementControl>();
        
        /// <summary>
        /// Инициализация главного окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _dataGridView.Columns["Resistance"].ValueType = Type.GetType("System.Double");
            _dataGridView.Rows.Add();
            _circuit = new Circuit();
            _circuit.CircuitChanged += Circuit_CircuitChanged;
            _circuit.InvalidNodes += Circuit_InvalidMatrix;

                    }

        /// <summary>
        /// Обработчик события проверки матрицы
        /// </summary>
        private void Circuit_InvalidMatrix(string msg)
        {
            _mainWindowStatusStrip.Text = msg;
        }

        /// <summary>
        /// Метод создает экземпляр объекта элемент и добавляет его в схему
        /// </summary>
        /// <param name="name">Имя элемента</param>
        /// <param name="value">Номинальное значение</param>
        /// <param name="elementControl">UserControl в котором отобразится данные об элементе</param>
        private void AddElement(string name, double value, int inp, int outp)
        {
            IElement iElement = null;
            Factory factory = Factory.GetFactory(name[0]);
            iElement = factory.CreateElement(value);
            //TODO: Насколько просто будет расширить вашу программу при добавлении новых наследников(done)
            //TODO: от IElement(done)
            int index = _elementContolList.Count;

            iElement.Name = iElement.Name + (index + 1).ToString();
            _circuit.Elements.Add(iElement);
            _circuit.Nodes.Add(index, new Tuple<int, int>(inp, outp));
            

            ElementControl elementControl = new ElementControl();
            elementControl.ObjectChanged += ElementControl_ObjectChanged;
            this._elementsPanel.Controls.Add(elementControl);
            
            int delta = 33;

            elementControl.Location = new Point(6, 5 + delta * index);
            elementControl.Name = "elementControl" + index.ToString();
            elementControl.In = inp;
            elementControl.Out = outp;
            elementControl.Object = iElement;
            elementControl.Visible = true;
            elementControl.Size = new Size(416, 27);
            elementControl.TabIndex = _dataGridView.TabIndex + index + 1;
            elementControl.Object.ValueChanged += _circuit.ElementChanged;

            _elementContolList.Add(elementControl);
        }

        /// <summary>
        /// Обработчик при изменении элемента в цепи
        /// </summary>
        /// <param name="msg"></param>
        private void ElementControl_ObjectChanged(string msg)
        {
            for (int i = 0; i < _elementContolList.Count; i++)
            {
                _circuit.Elements[i] = _elementContolList[i].Object;
                _circuit.Nodes[i] = new Tuple<int, int>(_elementContolList[i].In, _elementContolList[i].Out);
            }
            Circuit_CircuitChanged("");
        }

        /// <summary>
        /// Метод удаляет последний в списке элемент из схемы
        /// </summary>
        private void RemoveElement()
        {
            int index = _circuit.Elements.Count - 1;
            _circuit.Elements.RemoveAt(index);
            _circuit.Nodes.Remove(index);
            _elementContolList.RemoveAt(index);
            _elementsPanel.Controls.RemoveAt(index);
        }

        /// <summary>
        /// Обработчик при изменении цепи
        /// </summary>
        private void Circuit_CircuitChanged(string msg)
        {
            _mainWindowStatusStrip.Text = msg;

            foreach (DataGridViewRow row in _dataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    int i = row.Index;
                    _frequences[i] = double.Parse(row.Cells[0].FormattedValue.ToString());
                }
            }
            Complex[] z = _circuit.CalculateZ(_frequences);

            foreach (DataGridViewRow row in _dataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    int i = row.Index;
                    row.Cells[1].Value = z.GetValue(i);
                }
            }
        }
        
        /// <summary>
        /// Валидация введенных в dataGridView данных
        /// </summary>
        private void DataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewCell cell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
                string text = cell.EditedFormattedValue.ToString();
                if (InputDataController.InputIntValidating(text))
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Обработчик при изменении значения ячейки _dataGridView
        /// </summary>
        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0) && ((DataGridView)sender).RowCount != 0)
            {
                DataGridViewCell cell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
                string text = cell.EditedFormattedValue.ToString();
                if (!InputDataController.InputIntValidating(text))
                {
                    cell.Value = "";
                }
            }
        }

        /// <summary>
        /// Обработчик при остановке режима правки для выбранной ячейки
        /// </summary>
        private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _mainWindowStatusStrip.Text = "";
            int r = e.RowIndex;
            int c = e.ColumnIndex;
            string cellValue = _dataGridView.Rows[r].Cells[c].FormattedValue.ToString();
            try
            {
                _frequences[r] = double.Parse(cellValue);
            }
            catch (ArgumentOutOfRangeException)
            {
                _frequences.Add(double.Parse(cellValue));
            }
            catch (FormatException)
            {
                if (r != _dataGridView.RowCount - 1)
                {
                    _dataGridView.Rows.RemoveAt(r);
                }
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Format overflow.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                Complex[] z = _circuit.CalculateZ(_frequences);
                _dataGridView.Rows[r].Cells[1].Value = z.GetValue(r);
                if (r + 1 == _dataGridView.Rows.Count)
                    _dataGridView.Rows.Add();
            }
            catch
            {
                MessageBox.Show("Calculating failure.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод очищает панель контролов и удаляет все элементы в цепи
        /// </summary>
        private void ClearPanel()
        {
            _mainWindowStatusStrip.Text = "Enter a frequence.";
            _dataGridView.Enabled = true;

            foreach (ElementControl ec in _elementContolList)
            {
                Controls.Remove(ec);
                ec.Dispose();
            }
            _elementContolList.Clear();
            _circuit.Elements.Clear();
            _circuit.Nodes.Clear();
        }

        /// <summary>
        /// Метод создает схему выбранный из 5 готовых
        /// </summary>
        private void LoadCircuit(object sender, EventArgs e)
        {
            ClearPanel();
            _countOfElementView.Enabled = false;

            //HACK: инициализируются каждый раз при выборе схемы
            var dict = new Dictionary<string, Tuple<int, List<Tuple <string, int, int, int>>>>();

            dict.Add("_circuit1", new Tuple<int, List<Tuple<string, int, int, int>>>(2,
                    new List<Tuple<string, int, int, int>>
                    {
                        new Tuple<string, int, int, int>("R", 10, 1, 2),
                        new Tuple<string, int, int, int>("C", 150, 1, 2),
                    }));

            dict.Add("_circuit2", new Tuple<int, List<Tuple<string, int, int, int>>>(2,
                    new List<Tuple<string, int, int, int>>
                    {
                        new Tuple<string, int, int, int>("R", 10, 1, 2),
                        new Tuple<string, int, int, int>("L", 50, 2, 3),
                    }));

            dict.Add("_circuit3", new Tuple<int, List<Tuple<string, int, int, int>>>(2,
                    new List<Tuple<string, int, int, int>>
                    {
                        new Tuple<string, int, int, int>("C", 200, 1, 2),
                        new Tuple<string, int, int, int>("L", 20, 2, 3),
                    }));

            dict.Add("_circuit4", new Tuple<int, List<Tuple<string, int, int, int>>>(3,
                    new List<Tuple<string, int, int, int>>
                    {
                        new Tuple<string, int, int, int>("R", 90, 1, 2),
                        new Tuple<string, int, int, int>("C", 200, 2, 3),
                        new Tuple<string, int, int, int>("L", 20, 3, 4),
                    }));

            dict.Add("_circuit5", new Tuple<int, List<Tuple<string, int, int, int>>>(3,
                    new List<Tuple<string, int, int, int>>
                    {
                        new Tuple<string, int, int, int>("R", 10, 1, 2),
                        new Tuple<string, int, int, int>("R", 90, 2, 3),
                        new Tuple<string, int, int, int>("C", 200, 3, 4),
                    }));


            var element = dict[((ToolStripMenuItem)sender).Name];
            _countOfElementView.Value = element.Item1;

            foreach (var elem in element.Item2)
            {
                AddElement(elem.Item1, elem.Item2, elem.Item3, elem.Item4);
            }
        }

        /// <summary>
        /// Метод для создания пользовательской схемы
        /// </summary>
        private void CreateCircuit(object sender, EventArgs e)
        {
            ClearPanel();
            _countOfElementView.Value = 0;
            _countOfElementView.Enabled = true;
        }

        /// <summary>
        /// Обрабочик при изменении свойства Value элемента управления _countOfElementView
        /// </summary>
        private void CountOfElementView_ValueChanged(object sender, EventArgs e)
        {
            if (_countOfElementView.Enabled)
            {
                decimal count = _countOfElementView.Value;
                int lastNode = 1;
                if (_elementContolList.Count != 0)
                {
                    int index = _elementContolList.Count - 1;
                    lastNode = _circuit.Nodes[index].Item2;
                }
                if (count > _circuit.Elements.Count)
                {
                    AddElement("R", 10, lastNode, lastNode + 1);
                }
                else
                {
                    RemoveElement();
                }
            }
        }

        private void aCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_circuit.Elements.Count == 0)
            {
                MessageBox.Show("Circuit should have at least one element.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AC_Analysis acWindow = new AC_Analysis(_circuit);
                acWindow.ShowDialog();
            }
        }
    }
}
