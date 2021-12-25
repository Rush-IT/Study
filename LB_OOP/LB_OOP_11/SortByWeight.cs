using System;
using System.Collections.Generic;
using System.Text;

namespace LB_OOP_11
{
    class SortByWeight 
    {
        public int Compare(Animals x, Animals y)
        {
            if (x.Weight > y.Weight) return 1;
            if (x.Weight < y.Weight) return -1;
            return 0;
        }
    }
}
