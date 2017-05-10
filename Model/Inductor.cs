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
        public Inductor(string name, double value)
        {
            Value = value;
            Name = name;
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
                    if (value != _value)
                    {
                        _value = value;
                        ValueChanged?.Invoke("Inductor value was changed.");
                    }
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
        public event UserDelegate ValueChanged;
    }

    public class InductorCreator : Creator
    {
        public InductorCreator(string name) : base(name)
        {

        }

        public override IElement CreateElement()
        {
            return new Inductor(Name, 10);
        }
    }
}