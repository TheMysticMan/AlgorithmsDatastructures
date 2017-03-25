using System;
using System.Text;

namespace SinglyLinkedList
{

    public class SinglyLinkedList<T>
    {
        private readonly ListNode<T> _head = new ListNode<T>();

        /// <summary>
        /// </summary>
        public void AddFirst(T data)
        {
            var newNode = new ListNode<T>(data) {Next = _head.Next};
            _head.Next = newNode;
        }

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void Insert(uint index, T data)
        {
            var previous = _head;
            for (var i = 0; i < index; i++)
            {
                previous = previous.Next;
                if (previous == null)
                {
                    throw new IndexOutOfRangeException();
                }
            }

            var newNode = new ListNode<T>(data);
            newNode.Next = previous.Next;
            previous.Next = newNode;
        }

        /// <summary>
        /// </summary>
        public void RemoveFirst()
        {
            if (_head.Next != null)
            {
                _head.Next = _head.Next.Next;
            }
        }

        public T GetFirst()
        {
            if (_head.Next != null)
            {
                return _head.Next.Data;
            }
            return default(T);
        }

        /// <summary>
        /// </summary>
        public void Clear()
        {
            _head.Next = null;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("<");

            var current = _head;
            if (current.Next != null)
            {
                while ((current = current.Next) != null)
                {
                    sb.Append($"{current.Data},");
                }
                // remove last ,
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append(">");

            return sb.ToString();
        }
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListNode<T>
    {
        public T Data { get; set; }
        public ListNode<T> Next { get; set; }

        /// <summary>
        /// </summary>
        public ListNode()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        public ListNode(T data)
        {
            Data = data;
        }
    }
}