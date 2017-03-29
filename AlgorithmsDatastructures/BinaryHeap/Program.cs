using System;
using System.Text;

namespace BinaryHeap
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            var heap = new BinaryHeap<int>(10);
            heap.Insert(4);
            heap.Insert(1);
            heap.Insert(26);
            heap.Insert(19);
            heap.Insert(3);
            Console.WriteLine(heap.GetPreOrder());

            heap.DeleteMin();
            Console.WriteLine(heap.GetPreOrder());
        }
    }

    public class BinaryHeap<T> where T : IComparable
    {
        private T[] array;
        private int _currentSize;

        public BinaryHeap(int size)
        {
            array = new T[size];
            _currentSize = 0;
        }

        public int Length => _currentSize;

        public void Insert(T data)
        {
            if (_currentSize + 1 == array.Length)
            {
                DoubleArray();
            }
            var hole = ++_currentSize;
            array[0] = data;
            for (; data.CompareTo(array[hole / 2]) < 0 && hole > 1; hole /= 2)
            {
                array[hole] = array[hole / 2];
            }
            array[hole] = data;
        }

        private void DoubleArray()
        {
            var oldArr = array;
            array = new T[oldArr.Length * 2 + 1];
            for (var i = 0; i < oldArr.Length; i++)
            {
                array[i] = oldArr[i];
            }
        }

        public T FindMin()
        {
            return array[1];
        }

        public T DeleteMin()
        {
            var min = FindMin();
            array[1] = array[_currentSize];
            _currentSize--;
            PercolateDown(1);
            return min;
        }

        private void PercolateDown(int hole)
        {
            T tmp = array[hole];
            var child = 0;
            for (; hole * 2 <= _currentSize; hole = child)
            {
                child = hole * 2;
                if (child != _currentSize && array[child + 1].CompareTo(array[child]) < 0)
                {
                    child++;
                }
                if (array[child].CompareTo(tmp) < 0)
                {
                    array[hole] = array[child];
                }
                else
                {
                    break;
                }
            }

            array[hole] = tmp;
        }

        public string GetPreOrder()
        {
            return GetPreOrder(1);
        }

        private string GetPreOrder(int index)
        {
            if (index > _currentSize)
            {
                return "";
            }
            var sb = new StringBuilder();
            sb.Append(array[index]);
            if (index * 2 <= _currentSize)
            {
                sb.Append(",");
                sb.Append(GetPreOrder(index*2));
            }
            if (index * 2 +1 <= _currentSize)
            {
                sb.Append(",");
                sb.Append(GetPreOrder(index * 2 + 1));
            }
            return sb.ToString();
        }
    }

}