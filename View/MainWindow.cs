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
    /// <summary>
    /// Сущность для главного окна программы
    /// </summary>
    public partial class MainWindow : Form
    {
        private IElement _iElement;
        private Circuit _circuit;
        private List<double> _frequences = new List<double>();
        private Complex[] _z;
        private List<ElementControl> elementContolList = new List<ElementControl>();

        /// <summary>
        /// Инициализация главного окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _dataGridView.Columns.Add("Frequence", "freq");
            _dataGridView.Columns.Add("Resistance", "res");
            _dataGridView.Columns["Resistance"].ReadOnly = true;
            _dataGridView.Columns["Resistance"].ValueType = Type.GetType("System.Double");
            _dataGridView.Rows.Add();
            _circuit = new Circuit();
            _circuit.CircuitChanged += _circuit_CircuitChanged;
        }

        /// <summary>
        /// Обработчик при изменении свойства SelectedIndex
        /// </summary>
        private void _circuitKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _mainWindowStatusStrip.Text = "Enter a frequence.";
            _dataGridView.Enabled = true;

            int circuitIndex = _circuitKind.SelectedIndex;

            foreach (ElementControl ec in elementContolList)
            {
                Controls.Remove(ec);
                ec.Dispose();
            }
            elementContolList.Clear();
            _circuit.Elements.Clear();

            switch (circuitIndex)
            {
                case 0:
                    AddElement("R", 10);
                    AddElement("C", 150);
                    break;
                case 1:
                    AddElement("R", 12);
                    AddElement("L", 50);
                    break;
                case 2:
                    AddElement("C", 200);
                    AddElement("L", 20);
                    break;
                case 3:
                    AddElement("R", 90);
                    AddElement("C", 200);
                    AddElement("L", 20);
                    break;
                case 4:
                    AddElement("R", 10);
                    AddElement("R", 90);
                    AddElement("C", 200);
                    break;

                default:

                    break;
            }
        }

        /// <summary>
        /// Метод создает экземпляр объекта элемент и добавляет его в схему
        /// </summary>
        /// <param name="name">Имя элемента</param>
        /// <param name="value">Номинальное значение</param>
        /// <param name="elementControl">UserControl в котором отобразится данные об элементе</param>
        private void AddElement(string name, double value)
        {
            Regex r = new Regex("R");
            Regex c = new Regex("C");
            Regex i = new Regex("L");

            if (r.IsMatch(name))
                _iElement = new Resistor(name, value);

            if (c.IsMatch(name))
                _iElement = new Capacitor(name, value);

            if (i.IsMatch(name))
                _iElement = new Inductor(name, value);

            int index = elementContolList.Count;
            _iElement.Name = _iElement.Name + (index + 1).ToString();
            _circuit.Elements.Add(_iElement);

            ElementControl elementControl = new ElementControl();
            this._groupBox.Controls.Add(elementControl);
            
            int delta = 33;
            elementControl.Location = new Point(6, 40 + delta * index);
            elementControl.Name = "elementControl" + index.ToString();
            elementControl.Object = _iElement;
            elementControl.Visible = true;
            elementControl.Size = new Size(235, 27);
            elementControl.TabIndex = _dataGridView.TabIndex + index + 1;
            elementControl.Object.ValueChanged += _circuit.ElementValueChanged;

            elementContolList.Add(elementControl);
            _circuit_CircuitChanged("Added new element");
            Binding bind = new Binding("Text", _iElement, "Value");
            elementControl.DataBindings.Add(bind);
        }

        /// <summary>
        /// Обработчик при изменении схемы
        /// </summary>
        /// <param name="msg"></param>
        private void _circuit_CircuitChanged(string msg)
        {
            for (int i = 0; i < elementContolList.Count; i++)
            {
                _circuit.Elements[i] = elementContolList[i].Object;
            }
            _mainWindowStatusStrip.Text = "Circuit changed";

            foreach (DataGridViewRow row in _dataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    int i = row.Index;
                    _frequences[i] = double.Parse(row.Cells[0].FormattedValue.ToString());
                }
            }
            _z = _circuit.CalculateZ(_frequences);
            foreach (DataGridViewRow row in _dataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    int i = row.Index;
                    row.Cells[1].Value = _z.GetValue(i);
                }
            }
        }
        
        /// <summary>
        /// Валидация введенных в dataGridView данных
        /// </summary>
        private void _dataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewCell cell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
                InputDataController.InputDataValidating(cell, e);
            }
        }

        /// <summary>
        /// Обработчик при изменении значения номинала элемента
        /// </summary>
        /// <param name="msg"></param>
        public void _object_ValueChanged(string msg)
        {
            _mainWindowStatusStrip.Text = msg;
        }

        /// <summary>
        /// Обработчик при остановке режима правки для выбранной ячейки
        /// </summary>
        private void _dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
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
                _z = _circuit.CalculateZ(_frequences);
                _dataGridView.Rows[r].Cells[1].Value = _z.GetValue(r);
                if (r + 1 == _dataGridView.Rows.Count)
                    _dataGridView.Rows.Add();
            }
            catch
            {
                MessageBox.Show("Calculating failure.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
