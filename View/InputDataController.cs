using System.ComponentModel;
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
        public static void InputDataValidating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+$");
            if ((regex.IsMatch(((TextBox)sender).Text) != true) && (((TextBox)sender).Text != ""))
            {
                MessageBox.Show("Invalid data in textBox. Please, try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                ((TextBox)sender).Text = "";
            }
        }
        /// <summary>
        /// Перегрузка метода проверки для валидации строки datagridview
        /// </summary>
        public static void InputDataValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string text = ((DataGridViewCell)sender).EditedFormattedValue.ToString();
            Regex regex = new Regex("^[0-9]+$");
            if ((regex.IsMatch(text) != true) && (text != ""))
            {
                MessageBox.Show("Invalid data in the cell. Please, try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                ((DataGridViewCell)sender).Value = "";
            }
        }
    }
}
