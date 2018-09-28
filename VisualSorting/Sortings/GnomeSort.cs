using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualSorting.Sortings
{
    public class GnomeSort : VisualSort
    {
        protected override void InternalSort(ISortingCollection collection)
        {
            int i = 1;
            while (i < collection.Count)
            {
                if (i != 0 && collection.Compare(i, i - 1) < 0)
                {
                    collection.Swap(i, i - 1);
                    i--;
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
