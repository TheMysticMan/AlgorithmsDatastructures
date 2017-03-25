using System;

namespace ShellSort
{

    public static class ShellSortExtension
    {
        public static T[] ShellSort<T>(this T[] data) where T : IComparable
        {
            for (var gap = data.Length / 2; gap > 0; gap = gap == 2 ? 1 : (int)(gap / 2.2))
            {
                for (var i = 0; i < gap; i++)
                {
                    for (var j = i; j < data.Length; j += gap)
                    {
                        Sort(data, j, gap);
                    }
                }
            }
            return data;
        }

        private static void Sort<T>(T[] data, int index, int gap) where T : IComparable
        {
            if (index >= gap)
            {
                if (data[index - gap].CompareTo(data[index]) > 0)
                {
                    // swap
                    var old = data[index];
                    data[index] = data[index - gap];
                    data[index - gap] = old;
                    if (index >= gap * 2)
                    {
                        Sort(data, index - gap, gap);
                    }
                }
            }
        }
    }

}