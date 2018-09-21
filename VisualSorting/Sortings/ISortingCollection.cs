namespace VisualSorting.Sortings
{
    public interface ISortingCollection
    {
        int Count { get; }

        void Swap(int x, int y);

        int Compare(int x, int y);
    }
}
