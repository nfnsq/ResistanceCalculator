using System;
using System.Numerics;
using System.Windows.Forms;

namespace Model
{
    /// <summary>
    /// Сущность, описывающая элемент - катушка
    /// </summary>
    public class Inductor : IElement
    {
        public Inductor()
        {

        }

        public Inductor(string name, double value)
        {
            Name = name;
            Value = value;
        }
        /// <summary>
        /// Уникальное имя катушки
        /// </summary>
        public string Name { get; set; }

        private double _value;
        /// <summary>
        /// Индуктивность катушки
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
        /// Метод для расчета комплексного сопротивления катушки
        /// </summary>
        /// <param name="frequence">Частота сигнала в цепи</param>
        /// <returns></returns>
        public Complex CalculateZ(double frequence)
        {
            try
            {
                return 2 * Math.PI * frequence * Value;
            }
            catch
            {
                MessageBox.Show("Inductor's Z calculating failure.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Событие, определяющее изменение номинала катушки
        /// </summary>
        public event ValueChangedHandler ValueChanged;
    }
}
