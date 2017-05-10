using Model;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using System.Numerics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

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
            _circuit.InvalidMatrix += _circuit_InvalidMatrix;
        }

        /// <summary>
        /// Обработчик события проверки матрицы
        /// </summary>
        private void _circuit_InvalidMatrix(string msg)
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
            Regex r = new Regex("R");
            Regex c = new Regex("C");
            Regex i = new Regex("L");
            //TODO: Насколько просто будет расширить вашу программу при добавлении новых наследников
            //TODO: от IElement
            if (r.IsMatch(name))
            {
                iElement = new Resistor(name, value);
            }
            if (c.IsMatch(name))
            {
                iElement = new Capacitor(name, value);
            }
            if (i.IsMatch(name))
            {
                iElement = new Inductor(name, value);
            }
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
                if (InputDataController.InputDataValidating(text))
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
                if (!InputDataController.InputDataValidating(text))
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
            //TODO: Можно это собрать в один словарь и инициализировать ключами из словаря комбобокс
            //TODO: а потом брать значения из словаря по ключу
            if (((ToolStripMenuItem)sender).Name == "_circuit1")
            {
                _countOfElementView.Value = 2;
                AddElement("R", 10, 1, 2);
                AddElement("C", 150, 1, 2);
            }
            if (((ToolStripMenuItem)sender).Name == "_circuit2")
            {
                _countOfElementView.Value = 2;
                AddElement("R", 12, 1, 2);
                AddElement("L", 50, 2, 3);
            }
            if (((ToolStripMenuItem)sender).Name == "_circuit3")
            {
                _countOfElementView.Value = 2;
                AddElement("C", 200, 1, 2);
                AddElement("L", 20, 2, 3);
            }
            if (((ToolStripMenuItem)sender).Name == "_circuit4")
            {
                _countOfElementView.Value = 3;
                AddElement("R", 90, 1, 2);
                AddElement("C", 200, 2, 3);
                AddElement("L", 20, 3, 4);
            }
            if (((ToolStripMenuItem)sender).Name == "_circuit5")
            {
                _countOfElementView.Value = 3;
                AddElement("R", 10, 1, 2);
                AddElement("R", 90, 2, 3);
                AddElement("C", 200, 3, 4);
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
    }
}
