using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public class Array<T> where T : IComparable
    {
        public T[] array;
        public Array(T[] array)
        {
            this.array = array;
        }
        /// <summary>
        /// Объявление делегата
        /// </summary>
        /// <param name="array"></param>
        public delegate void Delegate(T[] array); 

        public void ShellSort(Delegate @delegate)
        {
            int n = array.Length;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    T temp = array[i];
                    int j = i;

                    while (j >= gap && array[j - gap].CompareTo(temp) > 0)
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }

                    array[j] = temp;
                }

                gap /= 2;
            }

            @delegate(array);
        }

        public T FindRange(Delegate @delegate)
        {
            // Размах массива
            T min = array.Min();
            T max = array.Max();
            return (dynamic)max - (dynamic)min;
        }
    }
}
