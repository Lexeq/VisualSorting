namespace VisualSorting.Sortings
{
    public class SelectionSort : VisualSort
    {
        protected override void PerformSort(ISortingCollection collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                collection.Swap(i, FindMinIndex(collection, i));
            }
        }

        private int FindMinIndex(ISortingCollection collection, int start)
        {
            var minIndex = start;

            for (int i = start + 1; i < collection.Count; i++)
            {
                if (collection.Compare(i, minIndex) < 0)
                    minIndex = i;
            }
            return minIndex;
        }
    }
}
