using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualSorting.Sortings
{
    public class HeapSort : VisualSort
    {
        protected override void PerformSort(ISortingCollection collection)
        {
            var hs = BuildHeap(collection);
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                collection.Swap(0, i);
                hs--;
                Heapify(collection, hs, 0);
            }
        }

        private int BuildHeap(ISortingCollection collection)
        {
            int heapSize = collection.Count - 1;
            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(collection, heapSize, i);
            }
            return heapSize;
        }

        private void Heapify(ISortingCollection collection, int heapSize, int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int largest = index;
            if (left <= heapSize && collection.Compare(left, index) > 0)
            {
                largest = left;
            }

            if (right <= heapSize && collection.Compare(right, largest) > 0)
            {
                largest = right;
            }

            if (largest != index)
            {
                collection.Swap(index, largest);
                Heapify(collection, heapSize, largest);
            }
        }
    }
}
