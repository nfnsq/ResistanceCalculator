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
        public Complex[] CalculateZ(params double[] frequencies)
        {
            Complex[] _z = null;
            try
            {

                for (int i = 0; i < frequencies.Length; i++)
                {
                    foreach (IElement element in Elements)
                    {
                        _z[i] = _z[i] + element.CalculateZ(frequencies[i]);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Circuit's calculating failure.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _z;
        }

        /// <summary>
        /// Событие, происходящее при изменении номиналов элементов в цепи
        /// </summary>
        public event ValueChangedHandler CircuitChanged;

        public void ElementValueChanged(object sender)
        {
            CircuitChanged?.Invoke(this);
        }
    }
}
