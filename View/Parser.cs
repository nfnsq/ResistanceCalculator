using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Синтаксический анализатор
    /// </summary>
    public static class Parser
    {
        /// <summary>
        /// Метод разделяет строку на подстроки
        /// </summary>
        /// <param name="stringFromLib"></param>
        /// <returns></returns>
        public static string[] GetArrayOfData(string stringFromLib)
        {
            try
            {
                var re = new Regex("stdout ");
                stringFromLib = re.Replace(stringFromLib, "");
                re = new Regex(",");
                stringFromLib = re.Replace(stringFromLib, "");

                int index = stringFromLib.IndexOf("\t");
                stringFromLib = stringFromLib.Substring(index - 1);

                char delimiter = '\t';
                var substrings = stringFromLib.Split(delimiter);

                return substrings;
            }
            catch
            {
                MessageBox.Show("Parser error", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
