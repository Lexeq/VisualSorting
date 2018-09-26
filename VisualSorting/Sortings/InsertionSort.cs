namespace VisualSorting.Sortings
{
    public class InsertionSort : VisualSort
    {
        protected override void InternalSort(ISortingCollection collection)
        {
            for (int i = 1; i < collection.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (collection.Compare(j, j - 1) < 0)
                        collection.Swap(j, j - 1);
                    else
                        break;
                }
            }
        }
    }
}
