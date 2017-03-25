using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new int[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0};
            data.MergeSort();
            Console.WriteLine(string.Join(",", data));
        }
    }

    public static class MergeSortAlgoritm
    {
        public static T[] MergeSort<T>(this T[] data) where T : IComparable
        {
            MergeSort(data, 0, data.Length -1);
            return data;
        }

        private static void MergeSort<T>(T[] data, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                var center = (left + right) / 2;
                MergeSort(data, left, center);
                MergeSort(data, center + 1, right);
                Merge(data, left, center + 1, right);
            }
        }

        private static void Merge<T>(T[] data, int left, int center, int right) where T: IComparable
        {
            var retVal = new T[right - left + 1];
            var aCtr = left;
            var bCtr = center;
            var cCtr = 0;

            for (; aCtr < center && bCtr <= right;)
            {
                var compared = data[aCtr].CompareTo(data[bCtr]);
                if (compared < 0)
                {
                    retVal[cCtr] = data[aCtr];
                    aCtr++;
                }
                else if (compared > 0)
                {
                    retVal[cCtr] = data[bCtr];
                    bCtr++;
                }
                else
                {
                    retVal[cCtr] = data[aCtr];
                    cCtr++;
                    retVal[cCtr] = data[bCtr];
                }
                cCtr++;
            }
            if (aCtr < center)
            {
                for (var i = aCtr; i < center; i++)
                {
                    retVal[cCtr] = data[i];
                    cCtr++;
                }
            }
            else if (bCtr < right)
            {
                for (var i = bCtr; i <= right; i++)
                {
                    retVal[cCtr] = data[i];
                    cCtr++;
                }
            }

            for (var i = 0; i < retVal.Length; i++)
            {
                data[left + i] = retVal[i];
            }
        }
    }
}
