using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayList;

namespace Queue_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>(5);
            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(1);

            Console.WriteLine(queue);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

            Console.WriteLine(queue);
        }
    }

    class Queue<T>
    {
        private ArrayList<T> _list;
        private uint front = 0;
        private int back = -1;

        public Queue(uint size)
        {
            _list = new ArrayList<T>(size);
        }

        public void Enqueue(T data)
        {
            _list.Add(data);
            back++;
        }

        public T Dequeue()
        {
            var data = _list.Get(front);
            front++;
            return data;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(_list.ToString());
            sb.Append($"head: {front}, back: {back}");

            return sb.ToString();
        }
    }
}
