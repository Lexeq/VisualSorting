using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualSorting.Sortings
{
    public class CombSort : VisualSort
    {
        private const double shrinkFactor = 1.3;
        protected override void PerformSort(ISortingCollection collection)
        {
            var step = collection.Count;
            bool wasSwap = false;

            do
            {
                wasSwap = false;
                if (step > 1)
                    step = (int)(step / shrinkFactor);

                for (int i = step; i < collection.Count; i++)
                {
                    if (collection.Compare(i, i - step) < 0)
                    {
                        collection.Swap(i, i - step);
                        wasSwap = true;
                    }
                }

            } while (wasSwap || step > 1);

        }
    }
}
