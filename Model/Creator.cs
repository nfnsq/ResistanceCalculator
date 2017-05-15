using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //TODO: XML комментарии
    //TODO: не понятно назначение этой сущности

    public abstract class Creator
    {
        public Creator(string name, double value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public double Value { get; set; }

        public abstract IElement CreateElement();
    }
}
