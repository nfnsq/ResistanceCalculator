using Model;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.ComponentModel;

namespace View
{
    /// <summary>
    /// UserControl для ввода данных элемента
    /// </summary>
    public partial class ElementControl : UserControl
    {
        private IElement _object = null;
        /// <summary>
        /// Метод иициализирующий UserControl
        /// </summary>
        public ElementControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Возвращает или устанавливает элемент в UserControl
        /// </summary>
        public IElement Object
        {
            get
            {
                return _object;
            }

            set
            {
                _object = value;

                if (_object != null)
                {
                    _elementValue.Text = _object.Value.ToString();
                    _nodeIn.Text = _object.In.ToString();
                    _nodeOut.Text = _object.Out.ToString();

                    Regex r = new Regex("R");
                    Regex c = new Regex("C");
                    Regex i = new Regex("L");

                    if (r.IsMatch(_object.Name))
                        _elementKind.SelectedIndex = 0;

                    if (c.IsMatch(_object.Name))
                        _elementKind.SelectedIndex = 1;

                    if (i.IsMatch(_object.Name))
                        _elementKind.SelectedIndex = 2;
                }
            }
        }
        
        /// <summary>
        /// Обработчик события SelectedIndexChanged
        /// </summary>
        private void _elementKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            int key = _elementKind.SelectedIndex;
            switch (key)
            {
                case 0:
                    _object = new Resistor();
                    _object.Name = "R";
                    break;
                case 1:
                    _object = new Capacitor();
                    _object.Name = "C";
                    break;
                case 2:
                    _object = new Inductor();
                    _object.Name = "L";
                    break;
                default:
                    MessageBox.Show("Object wasn't created.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            _object.Value = double.Parse(_elementValue.Text);
            _object.In = int.Parse(_nodeIn.Text);
            _object.Out = int.Parse(_nodeOut.Text);
            ObjectChanged?.Invoke("Element type changed.");

        }
        
        /// <summary>
        /// Обработчик при проверке действительности элемента управления
        /// </summary>
        private void TextBoxValidating(object sender, CancelEventArgs e)
        {
            try
            {
                int a = int.Parse(_nodeIn.Text);
                int b = int.Parse(_nodeOut.Text);
                if (InputDataController.InputDataValidating(((TextBox)sender).Text)
                && (a != b) && (a < b))
                {
                    e.Cancel = false;
                }
                else
                {
                    MessageBox.Show("Invalid data, try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ((TextBox)sender).Text = "";
                    e.Cancel = true;
                }
            }
            catch
            {
                MessageBox.Show("Parsing failure.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Обработчик упешной проверки корректности в элементе управления
        /// </summary>
        private void TextBoxValidated(object sender, EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Name == "_elementValue")
                {
                    _object.Value = double.Parse(((TextBox)sender).Text);
                }
                if (((TextBox)sender).Name == "_nodeIn")
                {
                    _object.In = int.Parse(((TextBox)sender).Text);
                }
                if (((TextBox)sender).Name == "_nodeOut")
                {
                    _object.Out = int.Parse(((TextBox)sender).Text);
                }
                ObjectChanged?.Invoke("");
            }
            catch
            {
                if (_elementValue.Text == "")
                {
                    _object.Value = 0;
                }
                else
                {
                    MessageBox.Show("Parsing failure. Please, try again", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _elementValue.Text = "";
                }
            }
        }

        /// <summary>
        /// Обработчик при изменении значения свойства Text элемента TextBox
        /// </summary>
        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            if (!InputDataController.InputDataValidating(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = "";
            }
            ObjectChanged?.Invoke("");
        }

        /// <summary>
        /// Событие, определяющее изменение элемента в цепи
        /// </summary>
        public event UserDelegate ObjectChanged;
    }
}
