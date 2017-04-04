using Model;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace View
{
    public partial class MainWindow : Form
    {
        private IElement _iElement;
        private Circuit _circuit;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void _circuitKind_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            _elementControl1.Visible = false;
            _elementControl2.Visible = false;
            _elementControl3.Visible = false;
            _circuit = new Circuit();
            int circuitIndex = _circuitKind.SelectedIndex;
            switch (circuitIndex)
            {
                case 0:
                    AddElement("R1", 10, _elementControl1);
                    AddElement("C2", 150, _elementControl2);
                    break;
                case 1:
                    AddElement("R1", 12, _elementControl1);
                    AddElement("L2", 50, _elementControl2);
                    break;
                case 2:
                    AddElement("C1", 200, _elementControl1);
                    AddElement("L2", 20, _elementControl2);
                    break;
                case 3:
                    AddElement("R1", 90, _elementControl1);
                    AddElement("C2", 200, _elementControl2);
                    AddElement("L3", 20, _elementControl3);
                    break;
                case 4:
                    AddElement("R1", 10, _elementControl1);
                    AddElement("R2", 90, _elementControl2);
                    AddElement("C3", 200, _elementControl3);
                    break;

                default:

                    break;
            }
           
        }

        private void AddElement(string name, double value, ElementControl elementControl)
        {
            elementControl.Visible = true;
            
            Regex r = new Regex("R");
            Regex c = new Regex("C");
            Regex i = new Regex("L");

            if (r.IsMatch(name))
                _iElement = new Resistor(name, value);
                
            if (c.IsMatch(name))
                _iElement = new Capacitor(name, value);

            if (i.IsMatch(name))
                _iElement = new Inductor(name, value);

            _iElement.ValueChanged += _circuit.ElementValueChanged;
            _circuit.Elements.Add(_iElement);
            elementControl.Object = _iElement;
        }


    }
}
