using System;

namespace Academits.Dorosh.ArrayListTask
{
    class ArrayListProgram
    {
        static void Main(string[] args)
        {
            ArrayList<string> list = new ArrayList<string>(0) { "5", null, "3", "", "1" };

            Console.WriteLine($"Исходный список: {list}");

            string element = "5";

            try
            {
                Console.WriteLine($"Содержит ли список элемент {element}? {list.Contains(element)}");
                Console.WriteLine($"Индекс элемента {element} - {list.IndexOf(element)}");
                Console.WriteLine($"Содержит ли список элемент -111 - {list.Contains("-111")}");
                Console.WriteLine($"Индекс элемента null - {list.IndexOf(null)}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                list.Add(element);
                Console.WriteLine($"Вставка элемента со значением [{element}] в конец: {list}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                element = "ch";
                list.Insert(list.Count, element);
                Console.WriteLine($"Вставка по индексу элемента со значением [{element}] в конец: {list}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            int index = 2;

            try
            {
                element = "rt";
                list.Insert(index, element);
                Console.WriteLine($"Вставка элемента со значением [{element}] по индексу [{index}]: {list}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                list.Remove(element);
                Console.WriteLine($"Удаление элемента со значением  [{element}]: {list}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                list.RemoveAt(index);
                Console.WriteLine($"Удаление по индексу [{index}]: {list}");
                //Console.WriteLine($"Элемент по индексу {list.Count} - {list[list.Count]}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                list.TrimExcess();
                Console.WriteLine($"Уменьшение вместимости: {list}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                list.TrimExcess();
                Console.WriteLine($"Повторное уменьшение вместимости: {list}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                list.Add("5");
                Console.WriteLine($"Добавление элемента: {list}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                string[] array = new string[7];
                list.CopyTo(array, 0);
                Console.WriteLine($"Копирование: {string.Join(" ", array)}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Тест итератора:");
            try
            {
                foreach (string e in list)
                {
                    Console.WriteLine($"foreach: {e}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}