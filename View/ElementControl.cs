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
        /// Метод инициализирующий UserControl
        /// </summary>
        public ElementControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие, определяющее изменение элемента в цепи
        /// </summary>
        public event UserDelegate ObjectChanged;

        private int _in;
        /// <summary>
        /// Номер узла, от которого ток приходит
        /// </summary>
        public int In
        {
            get
            {
                return _in;
            }
            set
            {
                if (value > 0)
                {
                    _in = value;
                }
                else
                {
                    _in = 1;
                    _out = 2;
                }
            }
        }

        private int _out;
        /// <summary>
        /// Номер узла, куда ток уходит
        /// </summary>
        public int Out
        {
            get
            {
                return _out;
            }
            set
            {
                if (value > 0)
                {
                    _out = value;
                }
                else
                {
                    _in = 1;
                    _out = 2;
                }
            }
        }
        
        /// <summary>
        /// Возвращает или устанавливает элемент в UserControl
        /// </summary>
        private IElement _object = null;
        public IElement Object
        {
            get
            {
                return _object;
            }

            set
            {
                _object = value;
                //TODO: Дублируется в MainWindow (done)
                if (_object != null)
                {
                    _elementValue.Text = _object.Value.ToString();
                    _nodeIn.Text = _in.ToString();
                    _nodeOut.Text = _out.ToString();

                    if (_object.Name[0] == 'R')
                    {
                        _elementKind.SelectedIndex = 0;
                    }
                    if (_object.Name[0] == 'C')
                    {
                        _elementKind.SelectedIndex = 1;
                    }
                    if (_object.Name[0] == 'L')
                    {
                        _elementKind.SelectedIndex = 2;
                    }
                }
            }
        }

        /// <summary>
        /// Обработчик события SelectedIndexChanged
        /// </summary>
        private void _elementKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int key = _elementKind.SelectedIndex;
                Factory factory = Factory.GetFactory(key);
                double value = double.Parse(_elementValue.Text);
                _object = factory.CreateElement(value); ;
                _in = int.Parse(_nodeIn.Text);
                _out = int.Parse(_nodeOut.Text);
                ObjectChanged?.Invoke("Element type changed.");

            }
            catch
            {
                MessageBox.Show("Object wasn't created.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
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
                    e.Cancel = true;
                    if (((TextBox)sender).Text == "")
                    {
                        MessageBox.Show("It's empty! Should be filled.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if ((a == b)||(a > b))
                    {
                        MessageBox.Show("In should be less than Out", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ((TextBox)sender).Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Parsing failure.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
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
                    _in = int.Parse(((TextBox)sender).Text);
                }
                if (((TextBox)sender).Name == "_nodeOut")
                {
                    _out = int.Parse(((TextBox)sender).Text);
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
            if ((!InputDataController.InputDataValidating(((TextBox)sender).Text))&&(((TextBox)sender).Text != ""))
            {
                MessageBox.Show("Invalid data. Please, try again. Only numeric can be entered.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = "";
            }
            ObjectChanged?.Invoke("");
        }
    }
}
