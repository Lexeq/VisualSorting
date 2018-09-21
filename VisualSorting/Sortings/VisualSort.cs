using System;
using System.Collections.Generic;

namespace VisualSorting.Sortings
{
    public abstract class VisualSort
    {
        public event EventHandler<ComparedEventArgs> Compared;

        public event EventHandler<SwappedEventArgs> Swapped;

        public int SwapCount { get; private set; }

        public int CompareCount { get; private set; }

        public void Sort<T>(IList<T> list)
        {
            Sort(list, Comparer<T>.Default);
        }

        public void Sort<T>(IList<T> list, IComparer<T> comparer)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            ListWrapper<T> lw = new ListWrapper<T>(list, comparer);
            lw.Compared += OnCompared;
            lw.Swapped += OnSwapped;
            InternalSort(lw);
            lw.Compared -= OnCompared;
            lw.Swapped -= OnSwapped;
        }

        protected abstract void InternalSort(ISortingCollection collection);

        private void OnCompared(object sender, ComparedEventArgs e)
        {
            CompareCount++;
            var handler = Compared;
            handler?.Invoke(this, e);
        }

        private void OnSwapped(object sender, SwappedEventArgs e)
        {
            SwapCount++;
            var handler = Swapped;
            handler?.Invoke(this, e);
        }
    }
}
