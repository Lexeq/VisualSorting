namespace VisualSorting.Sortings
{
    public class BubbleSort : VisualSort
    {
        protected override void InternalSort(ISortingCollection collection)
        {
            bool wasSwap;
            do
            {
                wasSwap = false;
                for (int i = 1; i < collection.Count; i++)
                {
                    if (collection.Compare(i, i - 1) < 0)
                    {
                        collection.Swap(i, i - 1);
                        wasSwap = true;
                    }
                }
            } while (wasSwap);
        }
    }
}
