using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System;

namespace View
{
    /// <summary>
    /// Сущность для проверки вводимых данных
    /// </summary>
    public static class InputDataController
    {
        /// <summary>
        /// Метод для проверки свойства Text Элемента TextBox на тип int
        /// </summary>
        public static void IntTextBoxChanged(object sender, EventArgs e)
        {
            string verifiableText = ((TextBox)sender).Text;
            if (!TypeOfIntCheck(verifiableText))
            {
                ((TextBox)sender).Text = "";
            }
        }

        /// <summary>
        /// Метод для проверки свойства Text Элемента TextBox на тип double
        /// </summary>
        public static void DoubleTextBoxChanged(object sender, EventArgs e)
        {
            string verifiableText = ((TextBox)sender).Text;
            if (!TypeOfDoubleCheck(verifiableText))
            {
                ((TextBox)sender).Text = "";
            }
        }

        /// <summary>
        ///  Метод для проверки строки на тип int
        /// </summary>
        public static bool TypeOfIntCheck(string dataGridCellValue)
        {
            Regex regex = new Regex("^[0-9]+$");
            if (TextValidating(dataGridCellValue, regex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  Метод для проверки строки на тип double
        /// </summary>
        public static bool TypeOfDoubleCheck(string dataGridCellValue)
        {
            Regex regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (TextValidating(dataGridCellValue, regex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Метод для проверки строки на совпадение
        /// с регулярным выражением
        /// </summary>
        private static bool TextValidating(string verifiableText, Regex regex)
        {
            if (((regex.IsMatch(verifiableText) != true))
                && (verifiableText != ""))
            {
                MessageBox.Show("Invalid data. Please, try again. Only numeric can be entered.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
