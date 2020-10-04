using System;

namespace Academits.Dorosh.RangeTask
{
    class RangeProgram
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("МЕНЮ");
                Console.WriteLine();
                Console.WriteLine("1. Проверка вхождения числа в заданный диапазон");
                Console.WriteLine("2. Операции над множествами, готовые тесты");
                Console.WriteLine("3. Операции над множествами, ввести свои отрезки");
                Console.WriteLine("4. Выход");
                Console.WriteLine();
                Console.WriteLine("Выберите пункт (только номер): ");

                string userChoice = Console.ReadLine();

                if (userChoice.Equals("1"))
                {
                    Range range = RangeCreation.GetRange();

                    Console.WriteLine("Вы ввели диапазон от {0} до {1}.", range.From, range.To);
                    Console.WriteLine("Его длина: {0}", range.GetLength());

                    Console.Write("Введите значение, чтобы проверить входит ли оно в заданный диапазон: ");
                    double number = Convert.ToDouble(Console.ReadLine());

                    if (range.IsInside(number))
                    {
                        Console.WriteLine("Значение {0} входит в заданный диапазон.", number);
                    }
                    else
                    {
                        Console.WriteLine("Значение {0} не входит в заданный диапазон.", number);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Нажмите любую клавишу...");

                    Console.ReadKey();

                    continue;
                }

                if (userChoice.Equals("2"))
                {
                    Range[] rangeA =
                    {
                        new Range(1,10),
                        new Range(1, 5),
                        new Range(1, 20),
                        new Range(1, 10),
                        new Range(1, 10),
                        new Range(15, 20),
                        new Range(5, 15)
                    };

                    Range[] rangeB =
{
                        new Range(5, 15),
                        new Range(5, 10),
                        new Range(5, 10),
                        new Range(15, 20),
                        new Range(1, 10),
                        new Range(5, 10),
                        new Range(1, 10)
                    };

                    for (int i = 0; i < rangeA.Length; i++)
                    {
                        Console.Write("Отрезок 1: ");
                        RangePrint.Print(rangeA[i]);

                        Console.Write("Отрезок 2: ");
                        RangePrint.Print(rangeB[i]);

                        Console.WriteLine();
                        Console.WriteLine("Объединение: ");
                        RangePrint.Print(rangeA[i].Union(rangeB[i]));

                        Console.WriteLine();
                        Console.WriteLine("Пересечение: ");
                        RangePrint.Print(rangeA[i].Intersection(rangeB[i]));

                        Console.WriteLine();
                        Console.WriteLine("Разность: ");
                        RangePrint.Print(rangeA[i].Complement(rangeB[i]));

                        Console.WriteLine();
                        Console.WriteLine("======================");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Нажмите любую клавишу...");

                    Console.ReadKey();

                    continue;
                }

                if (userChoice.Equals("3"))
                {
                    Console.WriteLine("Введите отрезок 1: ");
                    Range rangeA = RangeCreation.GetRange();
                    Console.WriteLine();

                    Console.WriteLine("Введите отрезок 2: ");
                    Range rangeB = RangeCreation.GetRange();

                    Console.WriteLine();
                    Console.WriteLine("Объединение: ");
                    RangePrint.Print(rangeA.Union(rangeB));

                    Console.WriteLine();
                    Console.WriteLine("Пересечение: ");
                    RangePrint.Print(rangeA.Intersection(rangeB));

                    Console.WriteLine();
                    Console.WriteLine("Разность: ");
                    RangePrint.Print(rangeA.Complement(rangeB));

                    Console.WriteLine();
                    Console.WriteLine("Нажмите любую клавишу...");

                    Console.ReadKey();

                    continue;
                }

                if (userChoice.Equals("4"))
                {
                    break;
                }
            }
        }
    }
}