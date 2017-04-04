using System.Numerics;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Сущность, описывающая элемент - резистор
    /// </summary>
    public class Resistor : IElement
    {
        public Resistor()
        {

        }
        public Resistor(string name, double value)
        {
            Value = value;
            Name = name;
        }
        /// <summary>
        /// Уникальное имя резистора
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сопротивление резистора
        /// </summary>
        private double _value;
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (DataController.Validating(value))
                {
                    if (_value != value)
                        ValueChanged?.Invoke(this);
                    _value = value;
                }
                else
                {
                    _value = 0;
                }
            }
        }

        /// <summary>
        /// Метод для расчета комплексного сопротивления резистора
        /// </summary>
        /// <param name="frequence">Частота сигнала в цепи</param>
        /// <returns></returns>
        public Complex CalculateZ(double frequence)
        {
            try
            {
                return Value;
            }
            catch
            {
                MessageBox.Show("Resistor's Z calculating failure.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Событие, определяющее изменение номинала резистора
        /// </summary>
        public event ValueChangedHandler ValueChanged;

    }
}
