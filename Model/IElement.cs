using System.Numerics;
using System;


namespace Model
{
    /// <summary>
    /// Делегат, оторый возвращает void и принимает string
    /// </summary>
    public delegate void UserDelegate(string msg);

    /// <summary>
    /// Сущность, описывающая элемент в электрической цепи
    /// </summary>
    public interface IElement
    {
        //TODO: Неудачной практикой является оставление всех свойств на get и set, таким образом нарушается инкапсуляция
        /// <summary>
        /// Уникальное имя элемента
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Значение номинала элемента
        /// </summary>
        double Value { get; set; }

        //TODO: Поля In и Out не должны пренадлежить интерфейсу, 
        //TODO: это не знания элемента, это знания схемы, 
        //TODO: т.к. схема должна говорить как соединяются элементы
        /// <summary>
        /// Номер узла, откуда ток приходит
        /// </summary>
        int In { get; set; }
        
        /// <summary>
        /// Номер узла, куда ток уходит
        /// </summary>
        int Out { get; set; }

        /// <summary>
        /// Метод возвращает значение комплексного сопротивления элемента в цепи
        /// </summary>
        /// <param name="frequence">Частота сигнала в цепи</param>
        /// <returns></returns>
        Complex CalculateZ(double frequence);

        /// <summary>
        /// Событие, происходящее при изменении номинала элемента
        /// </summary>
        event UserDelegate ValueChanged;
    }
}
