using System;

namespace SinglyLinkedList
{

    internal class Program
    {
        private static void Main()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.AddFirst(2);
            linkedList.AddFirst(1);
            linkedList.AddFirst(0);
            linkedList.AddFirst(-1);

            Console.WriteLine(linkedList);

            linkedList.Insert(0, 4);
            Console.WriteLine(linkedList);

            linkedList.RemoveFirst();
            Console.WriteLine(linkedList);

            Console.WriteLine(linkedList.GetFirst());
        }
    }
}