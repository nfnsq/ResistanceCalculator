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
                //TODO: Потенциально можем получить отрицительный узел
                _in = value;
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
                //TODO: Потенциально можем получить отрицительный узел
                _out = value;
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
                //TODO: Дублируется в MainWindow
                if (_object != null)
                {
                    _elementValue.Text = _object.Value.ToString();
                    _nodeIn.Text = _in.ToString();
                    _nodeOut.Text = _out.ToString();

                    Regex r = new Regex("R");
                    Regex c = new Regex("C");
                    Regex i = new Regex("L");

                    //TODO: Скобочки?
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
            double value = double.Parse(_elementValue.Text); 
            Creator creator = null;
            switch (key)
            {
                case 0:
                    creator = new ResistorCreator("R", value);
                    break;
                case 1:
                    creator = new CapacitorCreator("C", value);
                    break;
                case 2:
                    creator = new InductorCreator("L", value);
                    break;
                default:
                    MessageBox.Show("Object wasn't created.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            _object = creator.CreateElement();
            _in = int.Parse(_nodeIn.Text);
            _out = int.Parse(_nodeOut.Text);
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
            if (!InputDataController.InputDataValidating(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = "";
            }
            ObjectChanged?.Invoke("");
        }
    }
}
