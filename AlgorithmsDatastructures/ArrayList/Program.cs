using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayList = new ArrayList<int>(5);
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add(4);
            arrayList.Add(5);

            Console.WriteLine(arrayList);

            Console.WriteLine(arrayList.Get(3));

            arrayList.Set(3, 2);
            Console.WriteLine(arrayList);

            Console.WriteLine(arrayList.ToString(true));
            // double array length
            arrayList.Add(6);
            Console.WriteLine(arrayList.ToString(true));

            arrayList.Clear();
            Console.WriteLine(arrayList);
        }
    }
}
