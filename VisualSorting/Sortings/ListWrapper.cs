using System;
using System.Collections.Generic;

namespace VisualSorting.Sortings
{
    class ListWrapper<T> : ISortingCollection
    {
        IList<T> list;

        IComparer<T> comparer;

        public event EventHandler<ComparedEventArgs> Compared;

        public event EventHandler<SwappedEventArgs> Swapped;

        public ListWrapper(IList<T> list, IComparer<T> comparer)
        {
            this.list = list;
            this.comparer = comparer;
        }

        private void OnCompared(ComparedEventArgs e)
        {
            var handler = Compared;
            handler?.Invoke(this, e);
        }

        private void OnSwapped(SwappedEventArgs e)
        {
            var handler = Swapped;
            handler?.Invoke(this, e);
        }

        public int Count => list.Count;

        public int Compare(int x, int y)
        {
            int result = comparer.Compare(list[x], list[y]);
            OnCompared(new ComparedEventArgs(x, y, result));
            return result;
        }

        public void Swap(int x, int y)
        {
            T tmp = list[x];
            list[x] = list[y];
            list[y] = tmp;
            OnSwapped(new SwappedEventArgs(x, y));
        }
    }
}
