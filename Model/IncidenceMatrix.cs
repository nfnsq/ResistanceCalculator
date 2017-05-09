using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Сущность для создания и расчета матрицы инциденцийы
    /// </summary>
    public class IncidenceMatrix
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="columnCount">Количество столбцов матрицы</param>
        /// <param name="rowCount">Количество строк матрицы</param>
        /// <param name="nodes">Словарь, содержащий номера узлов</param>
        public IncidenceMatrix(int columnCount, int rowCount,
            Dictionary<int, Tuple<int, int>> nodes)
        {
            _matrix = new List<List<int>>();

            for (int i = 0; i < columnCount; i++)
            {
                _matrix.Add(new List<int>(0));
                for (int j = 0; j < rowCount; j++)
                {
                    if (nodes[j].Item1 == i + 1)
                    {
                        _matrix[i].Add(1);
                    }
                    else if (nodes[j].Item2== i + 1)
                    {
                        _matrix[i].Add(-1);
                    }
                    else
                    {
                        _matrix[i].Add(0);
                    }
                }
            }
        }

        private List<List<int>> _matrix;
        /// <summary>
        /// Матрица инциденций
        /// </summary>
        public List<List<int>> Matrix
        {
            get
            {
                return _matrix;
            }
            set
            {
                _matrix = value;
            }
        }

        /// <summary>
        /// Метод рассчитывает сумму элементов в столбце матрицы
        /// </summary>
        /// <param name="column">Номер столбца</param>
        /// <param name="matrix">Матрица</param>
        /// <returns></returns>
        public int GetSummOfColumn(int column, List<List<int>> matrix)
        {
            int summ = 0;
            for (int i = 0; i < matrix[column].Count; i++)
            {
                summ = summ + matrix[column][i];
            }
            return summ;
        }

        /// <summary>
        /// Метод считает количество ненулевых элементов в столбце
        /// </summary>
        /// <param name="column">Номер столбца</param>
        /// <param name="matrix">Матрица</param>
        /// <returns></returns>
        public int GetNonZeroQuantityInColumn(int column, List<List<int>> matrix)
        {

            int quantity = 0;
            for (int i = 0; i < matrix[column].Count; i++)
            {
                if (matrix[column][i] != 0)
                    quantity++;
            }
            return quantity;
        }

        /// <summary>
        /// Метод считает количество ненулевых элементов в строке
        /// </summary>
        /// <param name="row"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private int QuantityInRow(int row, List<List<int>> matrix)
        {
            int quantity = 0;
            for (int i = 0; i < matrix[row].Count; i++)
            {
                if (matrix[i][row] != 0)
                    quantity++;
            }
            return quantity;
        }

        /// <summary>
        /// Метод проверяет корректность матрицы
        /// </summary>
        public bool IsCorrect(List<List<int>> matrix, int rowCount, int columnCount)
        {
            bool result = true;
            for (int i = 0; i < columnCount; i++)
            {
                if (GetNonZeroQuantityInColumn(i, matrix) == 0)
                {
                    result = result && false;
                }
            }

            for (int i = 0; i < rowCount; i++)
            {
                if (QuantityInRow(i, matrix) == 0)
                {
                    result = result && false;
                }
            }

            int qP = 0;
            int qN = 0;

            for (int i = 0; i < columnCount; i++)
            {
                int p = 0;
                int n = 0;
                for (int j = 0; j < rowCount; j++)
                {
                    if (matrix[i][j] == 1)
                    { p++; }

                    if (matrix[i][j] == -1)
                    { n++; }
                }
                if (p == 0) { qP++; }
                if (n == 0) { qN++; }
            }

            if ((qP > 1) || (qN > 1)) { result = result && false; }

            return result;
        }
    }
}