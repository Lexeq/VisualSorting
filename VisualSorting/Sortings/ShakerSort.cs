using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualSorting.Sortings
{
    class ShakerSort : VisualSort
    {
        protected override void InternalSort(ISortingCollection collection)
        {
            bool wasSwap;
            var left = 0;
            var right = collection.Count - 1;

            do
            {
                wasSwap = false;
                for (int i = left + 1; i < right + 1; i++)
                {
                    if (collection.Compare(i, i - 1) < 0)
                    {
                        collection.Swap(i, i - 1);
                        wasSwap = true;
                    }
                }

                right--;
                if (wasSwap)
                {
                    wasSwap = false;
                    for (int i = right - 1; i >= left; i--)
                    {
                        if (collection.Compare(i, i + 1) > 0)
                        {
                            collection.Swap(i, i + 1);
                            wasSwap = true;
                        }
                    }
                    left++;
                }

            } while (wasSwap);
        }
    }
}
