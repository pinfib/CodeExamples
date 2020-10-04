using System;
using System.Collections.Generic;
using System.Linq;

namespace Academits.Dorosh.LambdaTask
{
    class LambdaProgram
    {
        public static IEnumerable<double> GetSquareRoots()
        {
            var i = 0;

            while (true)
            {
                yield return Math.Sqrt(i);

                ++i;
            }
        }

        public static IEnumerable<int> GetFibonacciNumbers()
        {
            var previousNumber = 0;
            var currentNumber = 1;

            yield return currentNumber;     // первое число фибоначчи - 1

            while (true)
            {
                currentNumber += previousNumber;

                yield return currentNumber;

                previousNumber = currentNumber - previousNumber;
            }
        }

        public static int GetNumbersCount(string message)
        {
            Console.WriteLine(message);

            var numbersCount = 10;

            try
            {
                numbersCount = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                Console.WriteLine($"Возвращено значение [{numbersCount}]");
            }

            if (numbersCount < 0)
            {
                Console.WriteLine("Нельзя вводить отрицательное число. Возвращено значение по модулю.");
                return Math.Abs(numbersCount);
            }

            return numbersCount;
        }

        static void Main()
        {
            var peopleList = new List<Person>
            {
                new Person("Ольга", 5),
                new Person("Иван", 15),
                new Person("Мария", 16),
                new Person("Иван", 21),
                new Person("Ольга", 24),
                new Person("Иван", 30),
                new Person("Валентина", 33),
                new Person("Иван", 37),
                new Person("Ольга", 40),
                new Person("Олег", 45),
                new Person("Анна", 50),
                new Person("Иван", 60),
                new Person(null, 0)
            };

            // А) получить список уникальных имен

            var namesList = peopleList
                .Select(p => p.Name)
                .Distinct()
                .ToList();

            // Б) вывести список уникальных имен в формате:
            //Имена: Иван, Сергей, Петр.

            Console.WriteLine("А, Б) Список уникальных имен");
            Console.Write("Имена: ");
            Console.WriteLine(string.Join(", ", namesList));
            Console.WriteLine();

            // В) получить список людей младше 18, посчитать для них средний возраст

            try
            {
                var averageAge = peopleList
                    .Where(p => p.Age < 18)
                    .Average(p => p.Age);

                Console.WriteLine("В) Средний возраст людей младше 18");
                Console.WriteLine($"Средний возраст: {averageAge}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Г) при помощи группировки получить Map, в котором ключи – имена, а значения – средний возраст

            var peopleByName = peopleList
                .GroupBy(
                    p => p.Name,
                    p => p.Age,
                    (name, ages) => new
                    {
                        Name = name,
                        AverageAge = ages.Average()
                    })
                .ToDictionary(p => p.Name, p => p.AverageAge);

            Console.WriteLine("Г) Dictionary, в котором ключи – имена, а значения – средний возраст");
            Console.WriteLine(string.Join(Environment.NewLine, peopleByName));
            Console.WriteLine();

            // Д) получить людей, возраст которых от 20 до 45, вывести в консоль их имена в порядке убывания возраста

            var adultPeople = peopleList
                .Where(p => p.Age >= 20 && p.Age <= 45)
                .OrderByDescending(p => p.Age)
                .ToList();

            Console.WriteLine("Д) Люди от 20 до 45 в порядке убывания возраста");
            Console.WriteLine(string.Join(Environment.NewLine, adultPeople));
            Console.WriteLine();

            // Задача 2

            Console.WriteLine("ЗАДАЧА 2)");
            Console.WriteLine("А) Бесконечный поток корней чисел");

            var numbersCount = GetNumbersCount("Введите количество чисел, из которых будут извлечены корни: ");
            Console.WriteLine();

            foreach (var e in GetSquareRoots().Take(numbersCount))
            {
                Console.Write($"{e: 0.###} ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Б) Бесконечный поток чисел Фибоначчи");
            Console.WriteLine();

            numbersCount = GetNumbersCount("Введите количество чисел Фибоначчи: ");
            Console.WriteLine();

            foreach (var e in GetFibonacciNumbers().Take(numbersCount))
            {
                Console.Write($"{e} ");
            }

            Console.ReadKey();
        }
    }
}