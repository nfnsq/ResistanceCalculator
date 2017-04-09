using System.Numerics;
using System;


namespace Model
{
    /// <summary>
    /// Делегат, оторый возвращает void и принимает
    /// </summary>
    public delegate void ValueChangedHandler(string msg);

    /// <summary>
    /// Сущность, описывающая элемент в электрической цепи
    /// </summary>
    public interface IElement
    {
        /// <summary>
        /// Уникальное имя элемента
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Значение номинала элемента
        /// </summary>
        double Value { get; set; }

        /// <summary>
        /// Метод возвращает значение комплексного сопротивления элемента в цепи
        /// </summary>
        /// <param name="frequence">Частота сигнала в цепи</param>
        /// <returns></returns>
        Complex CalculateZ(double frequence);

        /// <summary>
        /// Событие, происходящее при изменении номинала элемента
        /// </summary>
        event ValueChangedHandler ValueChanged;
    }
}
