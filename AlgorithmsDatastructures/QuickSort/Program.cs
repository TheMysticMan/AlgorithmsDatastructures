using System;
using System.Linq;

namespace QuickSort
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            var array = new int[10000];
            var random = new Random();
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = random.Next();
            }
            Console.WriteLine(string.Join(",", array));
            array.QuickSort();

            Console.WriteLine(string.Join(",", array));

        }
    }

    public static class QuickSortExtension
    {
        public static T[] QuickSort<T>(this T[] data) where T : IComparable
        {
            QuickSort(data, 0, data.Length - 1);
            return data;
        }

        private static void QuickSort<T>(T[] data, int start, int end) where T : IComparable
        {
            if (end - start <= 4)
            {
                InsertionSort(data, start, end);
            }
            else
            {
                var center = (start + end) / 2;
                // determine pivot
                var startVal = data[start];
                var centerVal = data[center];
                var endVal = data[end];
                var median = 0;
                var medianValue = default(T);

                if (startVal.CompareTo(centerVal) > 0 && startVal.CompareTo(endVal) < 0 ||
                    startVal.CompareTo(centerVal) < 0 && startVal.CompareTo(endVal) > 0)
                {
                    median = start;
                    medianValue = startVal;
                }
                else if (endVal.CompareTo(centerVal) > 0 && endVal.CompareTo(startVal) < 0 ||
                         endVal.CompareTo(centerVal) < 0 && endVal.CompareTo(startVal) > 0)
                {
                    median = end;
                    medianValue = endVal;
                }
                else
                {
                    median = center;
                    medianValue = centerVal;
                }
                data[median] = data[end];
                data[end] = medianValue;

                var i = start;
                var j = end-1;

                while (true)
                {
                    while (data[i].CompareTo(medianValue) < 0 && i <= end)
                    {
                        i++;
                    }
                    while (data[j].CompareTo(medianValue) > 0 && j >= start)
                    {
                        j--;
                    }
                    if (i > j)
                    {
                        break;
                    }
                    var old = data[i];
                    data[i] = data[j];
                    data[j] = old;
                }

                data[end] = data[i];
                data[i] = medianValue;

                QuickSort(data, start, j);
                QuickSort(data, i, end);
            }
        }

        private static void InsertionSort<T>(T[] data, int start, int end) where T : IComparable
        {
            for (var i = start + 1; i <= end; i++)
            {
                InsertionSort(data, i);
            }
        }

        private static void InsertionSort<T>(T[] data, int index) where T : IComparable
        {
            if (index > 0)
            {
                if (data[index - 1].CompareTo(data[index]) > 0)
                {
                    // swap
                    var old = data[index];
                    data[index] = data[index - 1];
                    data[index - 1] = old;
                    if (index > 1)
                    {
                        InsertionSort(data, index - 1);
                    }
                }
            }
        }
    }

}