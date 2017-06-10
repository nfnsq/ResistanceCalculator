using System;
using System.Collections.Generic;
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
        private ObservableCollection<IElement> _elements;
        public ObservableCollection<IElement> Elements
        {
            get
            {
                return _elements;
            }
            set
            {
                _elements = value;
            }
        }

        private Dictionary<int, Tuple<int, int>> _nodes;
        /// <summary>
        /// Словарь хранит номера узлов, к которым соединены элементы
        /// </summary>
        public Dictionary<int, Tuple<int, int>> Nodes
        {
            get
            {
                return _nodes;
            }
            set
            {
                _nodes = value;
            }
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Circuit()
        {
            Elements = new ObservableCollection<IElement>();
            Nodes = new Dictionary<int, Tuple<int, int>>();
            Elements.CollectionChanged += Elements_CollectionChanged;
        }
        
        /// <summary>
        /// Событие, происходящее при изменении номиналов элементов в цепи
        /// </summary>
        public event UserDelegate CircuitChanged;

        /// <summary>
        /// Событие, происходящее при неправильномм вводе номера узла
        /// </summary>
        public event UserDelegate InvalidNodes;

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
                        bool zeroNode = false;
                        foreach (IElement elem in Elements)
                        {
                            if (_nodes[_elements.IndexOf(elem)].Item2 > columnCount)
                            {
                                columnCount = _nodes[_elements.IndexOf(elem)].Item2;
                            }
                            if (_nodes[_elements.IndexOf(elem)].Item1 > columnCount)
                            {
                                columnCount = _nodes[_elements.IndexOf(elem)].Item1;
                            }
                            if ((_nodes[_elements.IndexOf(elem)].Item2 == 0)
                                &&(!zeroNode))
                            {
                                zeroNode = true;
                                columnCount++;
                            }
                        }

                        //создать и заполнить матрицу
                        IncidenceMatrix incidenceMatrix = new IncidenceMatrix(columnCount, rowCount, _nodes);
                        
                        //проверка на корректность матрицы
                        if (incidenceMatrix.IsCorrect(incidenceMatrix.Matrix, rowCount, columnCount))
                        {
                            //Расчет общего эквивалентного сопротивления
                            while (z.Count > 1)
                            {
                                //Объединение последовательных элементов
                                for (int j = 0; j < columnCount; j++)
                                {
                                    //поиск столбца, отвечающего условиям
                                    if ((incidenceMatrix.GetSummOfColumn(j, incidenceMatrix.Matrix) == 0) && (incidenceMatrix.GetNonZeroQuantityInColumn(j, incidenceMatrix.Matrix) == 2))
                                    {
                                        int p = incidenceMatrix.Matrix[j].IndexOf(-1);
                                        int q = incidenceMatrix.Matrix[j].IndexOf(1);
                                        //замена первого элемента на экивалентную
                                        z[p] = CalculateEquivalent(z[p], z[q], true);

                                        //удаление второго элемента
                                        for (int i = 0; i < columnCount; i++)
                                        {
                                            incidenceMatrix.Matrix[i][p] = incidenceMatrix.Matrix[i][p] + incidenceMatrix.Matrix[i][q];
                                            incidenceMatrix.Matrix[i].RemoveAt(q);
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
                                        bool isEqual = false;
                                        for (int j = 0; j < columnCount; j++)
                                        {
                                            if (incidenceMatrix.Matrix[j][i] == incidenceMatrix.Matrix[j][k])
                                            {
                                                isEqual = isEqual || true;
                                            }
                                            else
                                            {
                                                isEqual = isEqual || false;
                                            }
                                        }
                                        if (isEqual)
                                        {
                                            //замена первого элемента эквивалентным
                                            z[i] = CalculateEquivalent(z[i], z[k], false);

                                            //удаление второго элемента
                                            z.RemoveAt(k);
                                            for (int n = 0; n < columnCount; n++)
                                            {
                                                incidenceMatrix.Matrix[n].RemoveAt(k);
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
                            InvalidNodes?.Invoke("Verify that the node numbers are correct");
                        }
                    }
                }
            }
            catch
            {
                for (int i = 0; i < frequencies.Count; i++)
                {
                    result[i] = Complex.Zero;
                }
            }
            return result;
        }

        /// <summary>
        /// Метод для расчета эквивалентного сопротивления
        /// </summary>
        private Complex CalculateEquivalent(Complex z1, Complex z2, bool connection)
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
                zEq = Complex.Zero;
            }
            return zEq;
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
        /// Обработчик события ValueChaned
        /// </summary>
        public void ElementChanged(string msg)
        {
            CircuitChanged?.Invoke("Circuit changed. " + msg);
        }
    }
}
