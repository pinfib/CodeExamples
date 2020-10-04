using System;

namespace Academits.Dorosh.RangeTask
{
    class RangePrint
    {
        public static void Print(params Range[] ranges)
        {
            if (ranges.Length == 0 || ranges[0] == null)
            {
                Console.Write("Нет");

                return;
            }

            foreach (Range range in ranges)
            {
                Console.WriteLine("({0}; {1})", range.From, range.To);
            }
        }
    }
}