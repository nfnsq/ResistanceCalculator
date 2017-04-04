using System;
using System.Numerics;
using System.Windows.Forms;

namespace Model
{
    /// <summary>
    /// Сущность, описывающая элемент - конденсатор
    /// </summary>
    public class Capacitor : IElement
    {
        public Capacitor()
        {

        }

        public Capacitor(string name, double value)
        {
            Name = name;
            Value = value;
        }
        /// <summary>
        /// Уникальное имя конденсатора 
        /// </summary>
        public string Name { get; set; }

        private double _value;
        /// <summary>
        /// Емкость конденсатора
        /// </summary>
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
        /// Метод для расчета комплексного сопротивления
        /// </summary>
        /// <param name="frequence">Частота сигнала в цепи</param>
        /// <returns></returns>
        public Complex CalculateZ(double frequence)
        {
            try
            {
                return -1 / (2 * Math.PI * frequence * Value);
            }
            catch
            {
                MessageBox.Show("Capacitor's Z calculating failure.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Событие, определяющее изменение номинала конденсатора
        /// </summary>
        public event ValueChangedHandler ValueChanged;

    }
}
