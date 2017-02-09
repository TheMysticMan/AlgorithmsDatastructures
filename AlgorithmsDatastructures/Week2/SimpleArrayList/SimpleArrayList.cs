using System;
using System.Text;

namespace SimpleArrayList
{
    public class SimpleArrayList<T> : ISimpleArrayList<T>
    {
        private T[] _array;
        private int _index;
        private int _maxSize;
        public SimpleArrayList(int size)
        {
            _array = new T[size];
            _index = -1;
            _maxSize = size;
        }

        public void Add(T newData)
        {
            if (_index >= _maxSize - 1)
            {
                throw new IndexOutOfRangeException("List is full");
            }
            _array[++_index] = newData;
        }

        public T Get(uint index)
        {
            if (index > _maxSize - 1)
            {
                throw new IndexOutOfRangeException($"index {index} is out of range");
            }
            return _array[index];
        }

        public void Set(uint index, T newData)
        {
            if (index > _maxSize - 1)
            {
                throw new IndexOutOfRangeException($"index {index} is out of range");
            }

            _array[index] = newData;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (var i = 0; i <= _index; i++)
            {
                if (i != 0)
                {
                    builder.Append(',');
                }

                builder.Append(_array[i]);
                
            }
            return builder.ToString();
        }

        public void Clear()
        {
            _index = -1;
        }

        public int CountOccurences(T n)
        {
            var count = 0;
            for (var i = 0; i <= _index; i++)
            {
                if (_array[i].Equals(n))
                {
                    count ++;
                }
            }

            return count;
        }
    }
}