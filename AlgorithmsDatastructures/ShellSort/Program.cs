using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            Console.WriteLine(String.Join(",", array));
            array.ShellSort();
            Console.WriteLine(String.Join(",", array));
        }
    }

}
