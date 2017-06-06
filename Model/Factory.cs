using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Сущность абстрактная фабрика
    /// </summary>
    public abstract class Factory
    {
        /// <summary>
        /// Абстрактный метод фабрики для создания объекта IElement
        /// </summary>
        /// <param name="value">Значение номинала создаваемого объекта</param>
        /// <returns>Возвращает созданный объект</returns>
        public abstract IElement CreateElement(double value);

        /// <summary>
        /// Метод для создания нужной фабрики в зависимотси от типа элемента
        /// </summary>
        /// <param name="type">Тип элемента в целочисленной форме (int) 
        /// (1 - резистор, 2 - конденсатор, 3 - катушка)</param>
        /// <returns></returns>
        public static Factory GetFactory(int type)
        {
            switch (type)
            {
                case 0:
                    return new ResistorFactory();
                case 1:
                    return new CapacitorFactory();
                case 2:
                    return new InductorFactory();
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        /// <summary>
        /// Метод для создания нужной фабрики в зависимотси от типа элемента
        /// </summary>
        /// <param name="type">Тип элемента в символьной форме (char) 
        /// (R - резистор, C - конденсатор, L - катушка)</param>
        /// <returns></returns>
        public static Factory GetFactory(char type)
        {
            switch (type)
            {
                case 'R':
                    return new ResistorFactory();
                case 'C':
                    return new CapacitorFactory();
                case 'L':
                    return new InductorFactory();
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }

    /// <summary>
    /// Фабрика для создания элемента - резистор
    /// </summary>
    public class ResistorFactory : Factory
    {
        public override IElement CreateElement( double value)
        {
            return new Resistor("R", value);
        }
    }

    /// <summary>
    /// Фабрика для создания элемента - конденсатор 
    /// </summary>
    public class CapacitorFactory : Factory
    {
        public override IElement CreateElement(double value)
        {
            return new Capacitor("C", value);
        }
    }

    /// <summary>
    /// Фабрика для создания элемента - катушка
    /// </summary>
    public class InductorFactory : Factory
    {
        public override IElement CreateElement(double value)
        {
            return new Inductor("L", value);
        }
    }


}
