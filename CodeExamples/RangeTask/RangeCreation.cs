using System;

namespace Academits.Dorosh.RangeTask
{
    public static class RangeCreation
    {
        public static Range GetRange()
        {
            while (true)
            {
                Console.Write("Введите начало отрезка: ");
                double from = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите конец отрезка: ");
                double to = Convert.ToDouble(Console.ReadLine());

                if (from < to)
                {
                    return new Range(from, to);
                }

                Console.WriteLine("Ошибка! Значение начала диапазона должно быть меньше его окончания. Повторите ввод.");
            }
        }
    }
}