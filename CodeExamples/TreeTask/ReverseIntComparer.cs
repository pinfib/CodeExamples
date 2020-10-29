using System.Collections.Generic;

namespace Academits.Dorosh.TreeTask
{
    public class ReverseIntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return -x.CompareTo(y);
        }
    }
}