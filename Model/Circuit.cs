using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;

namespace Model
{
    /// <summary>
    /// Главная сущность программы, представляющая 
    /// последовательную электрическую цепь
    /// </summary>
    public class Circuit
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Circuit()
        {
            Elements = new List<IElement>();
        }
        /// <summary>
        /// Список элементов, входящих в электрическую цепь
        /// </summary>
        public List<IElement> Elements;

        /// <summary>
        /// Метод для вычисления комплескного сопротивления цепи
        /// </summary>
        /// <param name="frequencies"></param>
        /// <returns></returns>
        public Complex[] CalculateZ(List<double> frequencies)
        {
            Complex[] z = new Complex[frequencies.Count];
            try
            {

                for (int i = 0; i < frequencies.Count; i++)
                {
                    foreach (IElement element in Elements)
                    {
                        z[i] = z[i] + element.CalculateZ(frequencies[i]);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Circuit's calculating failure.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return z;
        }

        private Complex CalculateEquivalent(IElement element1, IElement element2, double frequence, bool connection)
        {
            Complex rEq = new Complex();
            Complex r1 = element1.CalculateZ(frequence);
            Complex r2 = element2.CalculateZ(frequence);

            try
            {
                if (connection)
                {
                    rEq = r1 + r2;
                }
                else
                {
                    rEq = r1 * r2 / (r1 + r2);
                }
            }
            catch
            {
                MessageBox.Show("Error in calculating equivalent resistance", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return rEq;
        }


        /// <summary>
        /// Событие, происходящее при изменении номиналов элементов в цепи
        /// </summary>
        public event ValueChangedHandler CircuitChanged;

        public void ElementValueChanged(string msg)
        {
            CircuitChanged?.Invoke("Circuit changed. " + msg);
        }
    }
}
