﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace Model
{
    /// <summary>
    /// Главная сущность программы, представляющая 
    /// последовательную электрическую цепь
    /// </summary>
    public class Circuit
    {
        /// <summary>
        /// Список элементов, входящих в электрическую цепь
        /// </summary>
        public ObservableCollection<IElement> Elements;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Circuit()
        {
            Elements = new ObservableCollection<IElement>();
            Elements.CollectionChanged += Elements_CollectionChanged;
        }
        
        /// <summary>
        /// Событие, происходящее при изменении номиналов элементов в цепи
        /// </summary>
        public event UserDelegate CircuitChanged;

        /// <summary>
        /// Событие, происходящее при неправильномм вводе номера узла
        /// </summary>
        public event UserDelegate InvalidMatrix;

        /// <summary>
        /// Метод для вычисления комплескного сопротивления цепи
        /// </summary>
        /// <param name="frequencies"></param>
        /// <returns></returns>
        public Complex[] CalculateZ(List<double> frequencies)
        {
            Complex[] result = new Complex[frequencies.Count];
            //локальная переменная для списка элементов
            List<Complex> z = new List<Complex>();
            try
            {
                if (frequencies.Count > 0)
                {
                    for (int f = 0; f < frequencies.Count; f++)
                    {
                        for (int i = 0; i < Elements.Count; i++)
                        {
                            z.Add(Elements[i].CalculateZ(frequencies[f]));
                        }

                        //получить размер строк
                        int rowCount = z.Count;
                        //получить размер столбцов
                        int columnCount = 0;
                        foreach (IElement elem in Elements)
                        {
                            if (elem.Out > columnCount)
                                columnCount = elem.Out;
                        }

                        //создать и заполнить матрицу
                        List<List<int>> A = CreateMatrix(columnCount, rowCount);

                        //проверка на корректность матрицы
                        if (MatrixIsCorrect(A, rowCount, columnCount))
                        {
                            //Расчет общего эквивалентного сопротивления
                            while (z.Count > 1)
                            {
                                //Объединение последовательных элементов
                                for (int j = 0; j < columnCount; j++)
                                {
                                    //поиск столбца, отвечающего условиям
                                    if ((ItemSumm(j, A) == 0) && (QuantityInColumn(j, A) == 2))
                                    {
                                        int p = A[j].IndexOf(-1);
                                        int q = A[j].IndexOf(1);
                                        //замена первого элемента на экивалентную
                                        z[p] = CalculateEquivalent(z[p], z[q], frequencies[f], true);

                                        //удаление второго элемента
                                        for (int i = 0; i < columnCount; i++)
                                        {
                                            A[i][p] = A[i][p] + A[i][q];
                                            A[i].RemoveAt(q);
                                        }
                                        z.RemoveAt(q);
                                    }
                                }
                                //Объединение параллельных элементов
                                for (int i = 0; i < z.Count; i++)
                                {
                                    //поиск одинаковых строк в матрице
                                    for (int k = i + 1; k < z.Count; k++)
                                    {
                                        bool isEqual = true;
                                        for (int j = 0; j < columnCount; j++)
                                        {
                                            if (A[j][i] == A[j][k])
                                            {
                                                isEqual = isEqual && true;
                                            }
                                            else
                                            {
                                                isEqual = isEqual && false;
                                            }
                                        }
                                        if (isEqual)
                                        {
                                            //замена первого элемента эквивалентным
                                            z[i] = CalculateEquivalent(z[i], z[k], frequencies[f], false);

                                            //удаление второго элемента
                                            z.RemoveAt(k);
                                            for (int n = 0; n < columnCount; n++)
                                            {
                                                A[n].RemoveAt(k);
                                            }
                                        }
                                    }
                                }
                            }

                            result[f] = z[0];
                            z.Clear();
                        }
                        else
                        {
                            InvalidMatrix?.Invoke("Verify that the node numbers are correct");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Circuit's calculating failure.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        
        /// <summary>
        /// Обработчик события изменения коллекции
        /// </summary>
        private void Elements_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (Elements.Count > 0)
            {
                CircuitChanged?.Invoke("Circuit changed");
            }
        }
        
        /// <summary>
        /// Метод рассчитывает сумму элементов в столбце матрицы
        /// </summary>
        /// <param name="j">Номер столбца</param>
        /// <param name="A">Матрица</param>
        /// <returns></returns>
        private int ItemSumm(int j, List<List<int>> A)
        {
            int s = 0;
            for (int i = 0; i < A[j].Count; i++)
            {
                s = s + A[j][i];
            }
            return s;
        }

        /// <summary>
        /// Метод считает количество ненулевых элементов в столбце
        /// </summary>
        /// <param name="j">Номер столбца</param>
        /// <param name="A">Матрица</param>
        /// <returns></returns>
        private int QuantityInColumn(int j, List<List<int>> A)
        {
            int q = 0;
            for (int i = 0; i < A[j].Count; i++)
            {
                if (A[j][i] != 0)
                    q++;
            }
            return q;
        }

        /// <summary>
        /// Метод считает количество ненулевых элементов в строке
        /// </summary>
        /// <param name="j"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        private int QuantityInRow(int j, List<List<int>> A)
        {
            int q = 0;
            for (int i = 0; i < A[j].Count; i++)
            {
                if (A[i][j] != 0)
                    q++;
            }
            return q;
        }

        /// <summary>
        /// Метод создает матрицу инцидентности
        /// </summary>
        /// <param name="columnCount">Количество столбцов</param>
        /// <param name="rowCount">Количество строк</param>
        /// <returns></returns>
        private List<List<int>> CreateMatrix(int columnCount, int rowCount)
        {
            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < columnCount; i++)
            {
                matrix.Add(new List<int>(0));
                for (int j = 0; j < rowCount; j++)
                {
                    if (Elements[j].In == i + 1)
                    {
                        matrix[i].Add(1);
                    }
                    else if (Elements[j].Out == i + 1)
                    {
                        matrix[i].Add(-1);
                    }
                    else
                    {
                        matrix[i].Add(0);
                    }
                }
            }
            return matrix;
        }
        
        /// <summary>
        /// Метод для расчета эквивалентного сопротивления
        /// </summary>
        private Complex CalculateEquivalent(Complex z1, Complex z2, double frequence, bool connection)
        {
            Complex zEq = new Complex();
            try
            {
                if (connection)
                {
                    zEq = z1 + z2;
                }
                else
                {
                    zEq = z1 * z2 / (z1 + z2);
                }
            }
            catch
            {
                MessageBox.Show("Error in calculating equivalent resistance", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return zEq;
        }
        
        /// <summary>
        /// Обработчик события ValueChaned
        /// </summary>
        public void ElementChanged(string msg)
        {
            CircuitChanged?.Invoke("Circuit changed. " + msg);
        }

        /// <summary>
        /// Метод проверяет корректность матрицы
        /// </summary>
        private bool MatrixIsCorrect(List<List<int>> matrix, int rowCount, int columnCount)
        { 
            bool result = true;
            for (int i = 0; i < columnCount; i++)
            {
                if (QuantityInColumn(i, matrix) == 0)
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
            
            if ((qP > 1)||(qN > 1)) { result = result && false; }

            return result;
        }
    }
}
