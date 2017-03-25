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
            var array = new int[5];
            array[0] = 5;
            array[1] = 2;
            array[2] = 3;
            array[3] = 8;
            array[4] = 99;

            Console.WriteLine(String.Join(", ", array));
            array.InsertionSort();
            Console.WriteLine(String.Join(", ",array));
        }
    }

}
