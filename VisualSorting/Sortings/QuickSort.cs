namespace VisualSorting.Sortings
{
    public class QuickSort : VisualSort
    {
        protected override void InternalSort(ISortingCollection collection)
        {
            Sort(collection, 0, collection.Count - 1);
        }

        private void Sort(ISortingCollection collection, int lower, int higher)
        {
            if (higher <= lower)
                return;

            int pivot = Pivot(collection, lower, higher);
            Sort(collection, lower, pivot);
            Sort(collection, pivot + 1, higher);
        }

        private int Pivot(ISortingCollection collection, int lower, int higher)
        {
            int pi = (lower + higher) / 2; //pivot index

            int left = lower - 1;
            int right = higher + 1;

            while (true)
            {
                do
                    left++;
                while (collection.Compare(left, pi) < 0);

                do
                    right--;
                while (collection.Compare(right, pi) > 0);

                if (left >= right)
                    return right;

                collection.Swap(left, right);
                if (left == pi)
                    pi = right;
                else if (right == pi)
                    pi = left;
            }
        }
    }
}