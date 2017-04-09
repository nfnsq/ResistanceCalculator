using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model
{
    /// <summary>
    /// Сущность для валидации данных
    /// </summary>
    public static class DataController
    {
        /// <summary>
        /// Метод для проверки данных
        /// </summary>
        /// <param name="value">Проверяемое значение</param>
        /// <returns></returns>
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
                #if !DEBUG
                string message = "Invalid data. Try again!\n" + 
                    "Entering data should be between 10 and 22*10^6";
                MessageBox.Show(message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                #endif
                return false;
            }
        }
    }
}
