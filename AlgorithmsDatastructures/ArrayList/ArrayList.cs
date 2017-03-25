using System;
using System.Text;

namespace ArrayList
{

    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayList<T>
    {
        private T[] _array;
        private int _currentSize;

        /// <summary>
        /// </summary>
        /// <param name="size"></param>
        public ArrayList(uint size)
        {
            _array = new T[size];
            _currentSize = 0;
        }

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            if (_currentSize == _array.Length)
            {
                DoubleLenght();
            }

            _array[_currentSize] = data;
            _currentSize++;
        }

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Get(uint index)
        {
            if (index > _currentSize)
            {
                throw new IndexOutOfRangeException($"{index} is out of range");
            }

            return _array[index];
        }

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void Set(uint index, T data)
        {
            if (index > _array.Length -1)
            {
                throw new IndexOutOfRangeException($"{index} is out of range");
            }

            _array[index] = data;
        }

        /// <summary>
        /// </summary>
        public void Clear()
        {
            _array = new T[_array.Length];
            _currentSize = 0;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool printEmpty)
        {
            var sb = new StringBuilder();
            sb.Append("<");
            if (_currentSize > 0)
            {
                var max = printEmpty
                    ? _array.Length
                    : _currentSize;
                for (var i = 0; i < max; i++)
                {
                    sb.Append($"{_array[i]},");
                }
                // remove last ,
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append(">");

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        private void DoubleLenght()
        {
            var oldArr = _array;
            _array = new T[oldArr.Length * 2 + 1];

            for (var i = 0; i < oldArr.Length; i++)
            {
                _array[i] = oldArr[i];
            }
        }
    }

}