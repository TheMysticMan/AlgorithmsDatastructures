using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintBackwards
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>(){0,1,2,3,4,5,6,7,8,9};

            PrintBackwards(list, 3);
        }

        public static void PrintBackwards(List<int> input, int i)
        {
            if (i < input.Count)
            {
                PrintBackwards(input, i +1);
                Console.WriteLine(input[i]);
                
            }
        }
    }
}
