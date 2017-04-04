using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class DataController
    {
        public static bool Validating(double value)
        {
            double min = 10;
            double max = 22E+6;
            if ((value >= min) && (value <= max))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
