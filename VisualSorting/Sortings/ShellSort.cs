using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VisualSorting.Sortings
{
    public class ShellSort : VisualSort
    {
        static readonly IList<int> steps = new ReadOnlyCollection<int>(new List<int>
        {
            1,4,10,23,57,132,301,701,1750
        });

        protected override void PerformSort(ISortingCollection collection)
        {
            var stepIndx = GetStepIndex(collection) + 1;
            int step;
            do
            {
                step = steps[--stepIndx];
                for (int i = step; i < collection.Count; i += step)
                {
                    for (int j = i; j > 0; j -= step)
                    {
                        if (collection.Compare(j, j - step) < 0)
                            collection.Swap(j, j - step);
                        else
                            break;
                    }

                }
            } while (step > 1);
        }

        private int GetStepIndex(ISortingCollection collection)
        {
            for (int i = steps.Count - 1; i >= 0; i--)
            {
                if (collection.Count > steps[i])
                    return i;
            }
            return 1;
        }
    }
}