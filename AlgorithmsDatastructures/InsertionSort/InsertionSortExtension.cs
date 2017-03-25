using System;

namespace InsertionSort
{

    public static class InsertionSortExtension
    {
        public static T[] InsertionSort<T>(this T[] data) where T : IComparable
        {
            for (var i = 1; i < data.Length; i++)
            {
                Sort(data, i);
            }

            return data;
        }

        private static void Sort<T>(T[] data, int index) where T : IComparable
        {
            if (index > 0)
            {
                if (data[index - 1].CompareTo(data[index]) > 0)
                {
                    // swap
                    var old = data[index];
                    data[index] = data[index - 1];
                    data[index - 1] = old;
                    if (index > 1)
                    {
                        Sort(data, index - 1);
                    }
                }
            }
        }
    }

}