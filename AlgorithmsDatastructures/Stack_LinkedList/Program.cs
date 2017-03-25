using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            stack.Push(3);
            stack.Push(2);
            stack.Push(6);
            Console.WriteLine(stack);

            Console.WriteLine("Top: " + stack.Top());
            Console.WriteLine("Pop: " + stack.Pop());
            Console.WriteLine(stack);
        }
    }

}
