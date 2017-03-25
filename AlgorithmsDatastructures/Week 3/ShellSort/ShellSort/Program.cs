using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace ShellSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            arr = Sort(arr);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        static int[] Sort(int[] arr)
        {
            var gap = arr.Length / 2;
            for (; gap > 0; gap = gap/2)
            {
                for (var j = 1; j <= gap; j++)
                {
                    for (var i = gap * j; i < arr.Length; i += gap)
                    {
                        arr = Compare(arr, i, i - gap, gap);
                    }
                }

                foreach (var item in arr)
                {
                    Console.WriteLine($"{gap}:{item}");
                }
            }
            return arr;
        }

        static int[] Compare(int[] arr, int i, int j, int gap)
        {
            if (arr[i] < arr[j])
            {
                arr = Swap(arr, i, j);
                if (j >= gap)
                {
                    arr = Compare(arr, i - gap, j - gap, gap);
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