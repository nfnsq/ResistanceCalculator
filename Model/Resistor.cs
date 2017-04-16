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
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Resistor()
        {

        }

        /// <summary>
        /// Параметризированный конструктор
        /// </summary>
        /// <param name="name">Имя элемента</param>
        /// <param name="value">Значение сопротивления резистора</param>
        public Resistor(string name, double value, int inp, int outp)
        {
            Value = value;
            Name = name;
            In = inp;
            Out = outp;
        }

        /// <summary>
        /// Уникальное имя резистора
        /// </summary>
        public string Name { get; set; }

        private double _value;
        /// <summary>
        /// Сопротивление резистора
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
                        ValueChanged?.Invoke("Resistor value was changed.");
                    }
                }
                else
                {
                    _value = 0;
                }
            }
        }

        /// <summary>
        /// Номер узла, откуда ток приходит
        /// </summary>
        public int In { get; set; }

        /// <summary>
        /// Номер узла, куда ток уходит
        /// </summary>
        public int Out { get; set; }

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
                #if !DEBUG
                MessageBox.Show("Resistor's Z calculating failure.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                #endif
                return 0;
            }
        }

        /// <summary>
        /// Событие, определяющее изменение номинала резистора
        /// </summary>
        public event UserDelegate ValueChanged;
    }
}