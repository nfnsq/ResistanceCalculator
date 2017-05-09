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
        /// <summary>
        /// Конструктор по умолчанию 
        /// </summary>
        public Capacitor()
        {

        }

        /// <summary>
        /// Параметеризированный конструктор
        /// </summary>
        /// <param name="name">Имя элемента</param>
        /// <param name="value">Значение емкости конденсатора</param>
        public Capacitor(string name, double value)
        {
            Value = value;
            Name = name;
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
                    if (value != _value)
                    {
                        _value = value;
                        ValueChanged?.Invoke("Capacitor value was changed.");
                    }
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
                return -1 / (2 * Math.PI * frequence * Value) * Complex.ImaginaryOne;
            }
            catch
            {
            #if !DEBUG
                MessageBox.Show("Capacitor's Z calculating failure.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endif
                return 0;
            }
        }

        /// <summary>
        /// Событие, определяющее изменение номинала конденсатора
        /// </summary>
        public event UserDelegate ValueChanged;

    }
}
