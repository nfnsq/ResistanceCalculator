using System.Numerics;
using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace Model
{
    /// <summary>
    /// Сущность, описывающая элемент - резистор
    /// </summary>
    public class Resistor : IElement
    {
        /// <summary>
        /// Параметризированный конструктор
        /// </summary>
        /// <param name="name">Имя элемента</param>
        /// <param name="value">Значение сопротивления резистора</param>
        internal Resistor(string name, double value)
        {
            Value = value;
            Name = name;
        }

        /// <summary>
        /// Уникальное имя резистора
        /// </summary>
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value[0] == 'R')
                {
                    _name = value;
                }
            }
        }

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