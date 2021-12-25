using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LB_OOP_10_I
{
    class SortByWeight : IComparer<Animals>
    {
        public int Compare(Animals x, Animals y)
        {
            if (x.Weight > y.Weight) return 1;
            if (x.Weight < y.Weight) return -1;
            return 0;
        }
    }
}
