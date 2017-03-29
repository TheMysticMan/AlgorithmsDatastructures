using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new HashTable<int>(7);
            table.Add(4);
            Console.WriteLine(table);
            table.Add(11);
            table.Add(1);
            table.Add(47298);
            table.Add(56298);
            Console.WriteLine(table);

            table.Delete(11);
            Console.WriteLine(table);
        }
    }

    class HashTable<T>
    {
        private List<T>[] _table;
        private int _tableSize;
        public HashTable(int size)
        {
            _table = new List<T>[size];
            _tableSize = size;
        }

        private int GetHash(T item)
        {
            var value = item.GetHashCode();
            return value % _tableSize;
        }

        public void Add(T item)
        {
            var key = GetHash(item);
            if (_table[key] == null)
            {
                _table[key] = new List<T>();
            }
            _table[key].Add(item);
        }

        public T Delete(T item)
        {
            var key = GetHash(item);
            var list = _table[key];
            if (list != null)
            {
                var found = list.FirstOrDefault(x => x.Equals(item));
                if (found != null && !found.Equals(default(T)))
                {
                    list.Remove(found);
                    return found;
                }
                else
                {
                    return default(T);
                }
            }
            else
            {
                return default(T);
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < _table.Length; i++)
            {
                if (_table[i] != null)
                {
                    sb.AppendLine($"{i}: <{String.Join(",", _table[i].ToArray())}>");
                }
                else
                {
                    sb.AppendLine($"{i}: null");
                }
            }

            return sb.ToString();
        }
    }
}
