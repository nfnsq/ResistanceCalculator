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
        /// <summary>
        /// Метод иициализирующий UserControl
        /// </summary>
        public ElementControl()
        {
            InitializeComponent();
        }

        private IElement _object = null;
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
        }

        /// <summary>
        /// Обработчик при проверке действительности элемента управления
        /// </summary>
        private void _elementValue_Validating(object sender, CancelEventArgs e)
        {
            InputDataController.InputDataValidating(sender, e);
        }

        /// <summary>
        /// Команды после упешной проверки корректности в элементе управления
        /// </summary>
        private void _elementValue_Validated(object sender, EventArgs e)
        {
            try
            {
                _object.Value = double.Parse(_elementValue.Text);
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
    }
}
