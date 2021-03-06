﻿using Model;
using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Globalization;

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
                if (value >= 0)
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
                if (_object != null)
                {
                    _elementValue.Text = _object.Value.ToString();
                    _nodeIn.Text = _in.ToString();
                    _nodeOut.Text = _out.ToString();
                    //TODO: Есть ощущение, что это не здесь должно быть. На вскидку убрал бы в фабрику, но пока мне такое решение не очень нравится.
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
                double value = double.Parse(_elementValue.Text, CultureInfo.InvariantCulture);
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
                if (((TextBox)sender).Name != "_elementValue")
                {
                    int a = int.Parse(_nodeIn.Text);
                    int b = int.Parse(_nodeOut.Text);
                    if ((a != b) && ((a < b) || (b == 0)))
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;

                        if ((a == b) || (a > b))
                        {
                            MessageBox.Show("In should be less than Out", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ((TextBox)sender).Text = "";
                    }
                }
            }
            catch
            {
                if (((TextBox)sender).Text == "")
                {
                    MessageBox.Show("It's empty! Should be filled.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Parsing failure.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                //TODO: Плохая практика привязываться к именам, они имеют обыкновение меняться
                if (((TextBox)sender).Name == "_elementValue")
                {
                    _object.Value = double.Parse(((TextBox)sender).Text, CultureInfo.InvariantCulture);
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
                    ObjectChanged?.Invoke("");
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
        /// Обработчик события изменения значения свойства Text элемента TextBox
        /// </summary>
        private void DoubleTextChanged(object sender, EventArgs e)
        {
            InputDataController.DoubleTextBoxChanged(sender, e);
            ObjectChanged?.Invoke("");
        }

        /// <summary>
        /// Обработчик события изменения значения свойства Text элемента TextBox
        /// </summary>
        private void IntTextChanged(object sender, EventArgs e)
        {
            InputDataController.IntTextBoxChanged(sender, e);
            ObjectChanged?.Invoke("");
        }
    }
}
