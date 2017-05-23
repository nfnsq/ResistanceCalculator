﻿using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Сущность для проверки вводимых данных
    /// </summary>
    public static class InputDataController
    {
        /// <summary>
        /// Метод для проверки данных
        /// </summary>
        public static bool InputDataValidating(string text)
        {
            Regex regex = new Regex("^[0-9]+$");
            if (regex.IsMatch(text) != true)
            {
                return false;
            }
            return true;
        }
    }
}
