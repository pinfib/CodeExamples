using System;

namespace Academits.Dorosh.HashTableTask
{
    class HashTableProgram
    {
        static void Main()
        {
            HashTable<string> hashTable = new HashTable<string>(5);

            hashTable.Add(null);
            hashTable.Add("Москва");
            hashTable.Add("Екатеринбург");
            hashTable.Add("Киров");
            hashTable.Add("Нижний Новгород");
            hashTable.Add("Калининград");
            hashTable.Add("Чита");

            Console.WriteLine("Внутренняя организация таблицы:");
            Console.WriteLine("Количество элементов - {0}", hashTable.Count);
            Console.WriteLine(hashTable);

            string element = "Калининград";
            Console.Write("Содержит ли таблица строку [{0}]? ", element);
            Console.WriteLine(hashTable.Contains(element));
            Console.WriteLine();

            try
            {
                string[] array = new string[10];
                hashTable.CopyTo(array, 0);
                Console.WriteLine("Копирование в массив. Итоговый массив: ");
                Console.WriteLine(string.Join(", ", array));
                Console.WriteLine();

                Console.WriteLine("Тест итератора:");

                foreach (string e in hashTable)
                {
                    Console.WriteLine("foreach: {0}", e);
                }

                Console.WriteLine();

                Console.Write("Удаление элемента со значением {0}. Успешно? ", element);
                Console.WriteLine(hashTable.Remove(element));
                Console.WriteLine();

                Console.WriteLine("Итоговое состояние таблицы:");
                Console.WriteLine("Количество элементов - {0}", hashTable.Count);
                Console.WriteLine(hashTable);
                Console.WriteLine();

                Console.WriteLine("Очистка таблицы.");
                hashTable.Clear();
                Console.WriteLine("Итоговое состояние таблицы:");
                Console.WriteLine("Количество элементов - {0}", hashTable.Count);
                Console.WriteLine(hashTable);
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}