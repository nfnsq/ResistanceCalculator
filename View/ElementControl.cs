using System.ComponentModel;
using System.Windows.Forms;
using Model;
using System.Text.RegularExpressions;

namespace View
{
    public partial class ElementControl : UserControl
    {
        public ElementControl()
        {
            InitializeComponent();
        }

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
        private void DataValidating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+$");
            if ((regex.IsMatch(((TextBox)sender).Text) != true) && (((TextBox)sender).Text != ""))
            {
                MessageBox.Show("Invalid data. Please, try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                ((TextBox)sender).Text = "";
            }
        }

        private void _elementKind_SelectedIndexChanged(object sender, System.EventArgs e)
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

        private void _elementValue_TextChanged(object sender, System.EventArgs e)
        {
            _object.Value = double.Parse(_elementValue.Text);
        }
    }
}
