using SinglyLinkedList;

namespace Stack_LinkedList
{

    public class Stack<T>
    {
        private readonly SinglyLinkedList<T> _list;

        public Stack()
        {
            _list = new SinglyLinkedList<T>();
        }

        public void Push(T data)
        {
            _list.AddFirst(data);   
        }

        public T Pop()
        {
            var data = _list.GetFirst();
            _list.RemoveFirst();
            return data;
        }

        public T Top()
        {
            return _list.GetFirst();
        }

        public override string ToString()
        {
            return _list.ToString();
        }
    }

}