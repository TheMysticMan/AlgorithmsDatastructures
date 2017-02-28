using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            arr = Sort(arr);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        static int[] Sort(int[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                arr = Compare(arr, i, i - 1);
            }
            return arr;
        }

        static int[] Compare(int[] arr, int i, int j)
        {
            if (arr[i] < arr[j])
            {
                arr = Swap(arr, i, j);
                if (i > 1)
                {
                    arr = Compare(arr, i - 1, j - 1);
                }
            }
            return arr;
        }

        static int[] Swap(int[] arr, int indexA, int indexB)
        {
            var oldA = arr[indexA];
            arr[indexA] = arr[indexB];
            arr[indexB] = oldA;
            return arr;
        }
    }
}
