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
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Inductor()
        {

        }

        /// <summary>
        /// Параметризированный конструктор
        /// </summary>
        /// <param name="name">Имя элемента</param>
        /// <param name="value">Значение индуктивности катушки</param>
        public Inductor(string name, double value, int inp, int outp)
        {
            Value = value;
            Name = name;
            In = inp;
            Out = outp;
        }

        /// <summary>
        /// Уникальное имя катушки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Индуктивность катушки
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
                    if (value != _value)
                    {
                        _value = value;
                        ValueChanged?.Invoke("Resistor value was changed.");
                    }
                }
            }
        }

        public int In { get; set; }
        public int Out { get; set; }
        /// <summary>
        /// Метод для расчета комплексного сопротивления катушки
        /// </summary>
        /// <param name="frequence">Частота сигнала в цепи</param>
        /// <returns></returns>
        public Complex CalculateZ(double frequence)
        {
            try
            {
                return 2 * Math.PI * frequence * Value * Complex.ImaginaryOne;
            }
            catch
            {
                #if !DEBUG
                MessageBox.Show("Inductor's Z calculating failure.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                #endif

                return 0;
            }
        }

        /// <summary>
        /// Событие, определяющее изменение номинала катушки
        /// </summary>
        public event ValueChangedHandler ValueChanged;
    }
}