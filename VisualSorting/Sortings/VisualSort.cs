using System;
using System.Collections.Generic;

namespace VisualSorting.Sortings
{
    public abstract class VisualSort
    {
        public event EventHandler<ComparedEventArgs> Compared;

        public event EventHandler<SwappedEventArgs> Swapped;

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
            if (list.Count < 2)
                return;

            ListWrapper<T> lw = new ListWrapper<T>(list, comparer);
            lw.Compared += OnCompared;
            lw.Swapped += OnSwapped;
            PerformSort(lw);
            lw.Compared -= OnCompared;
            lw.Swapped -= OnSwapped;
        }

        protected abstract void PerformSort(ISortingCollection collection);

        private void OnCompared(object sender, ComparedEventArgs e)
        {
            var handler = Compared;
            handler?.Invoke(this, e);
        }

        private void OnSwapped(object sender, SwappedEventArgs e)
        {
            var handler = Swapped;
            handler?.Invoke(this, e);
        }
    }
}
