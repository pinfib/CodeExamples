using System;

namespace Academits.Dorosh.RangeTask
{
    public class Range
    {
        private const double Epsilon = 1.0e-10;

        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        private static bool IsLargerOrEqual(double a, double b)
        {
            return a - b >= -Epsilon;
        }

        private static bool IsSmallerOrEqual(double a, double b)
        {
            return a - b <= Epsilon;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return IsLargerOrEqual(number, From) && IsSmallerOrEqual(number, To);
        }

        public Range[] Union(Range range)
        {
            if (From > range.To)
            {
                return new Range[] { new Range(range.From, range.To), new Range(From, To) };
            }

            if (To < range.From)
            {
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
            }

            return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
        }

        public Range Intersection(Range range)
        {
            if (To <= range.From || From >= range.To)
            {
                return null;
            }

            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }

        public Range[] Complement(Range range)
        {
            if (From >= range.From && To <= range.To)        //если отрезки равны или второй больше первого
            {
                return new Range[0];
            }

            if (To <= range.From || From >= range.To)       //если второй отрезок не соприкасается с первым
            {
                return new Range[] { new Range(From, To) };
            }

            if (From < range.From && To > range.To)         //если второй отрезок меньше и включен в первый
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }

            if (From < range.From)                          //если второй отрезок соприкасается с первым каким-либо краем
            {
                return new Range[] { new Range(From, range.From) };
            }

            return new Range[] { new Range(range.To, To) };
        }
    }
}