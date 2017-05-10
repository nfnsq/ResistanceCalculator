using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Creator
    {
        public Creator(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public abstract IElement CreateElement();
    }
}
