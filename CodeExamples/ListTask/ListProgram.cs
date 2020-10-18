using System;

namespace Academits.Dorosh.ListTask
{
    class ListProgram
    {
        public static void MethodsTest(List<int> list)
        {
            Console.WriteLine($"Исходный список: {list}");
            Console.WriteLine();

            int data = -50;
            int index = 0;

            for (int i = 0; i < 6; i++)
            {
                int deletedItem;
                List<int> tmpList = list.GetCopy();

                try
                {
                    switch (i)
                    {
                        case 0:
                            tmpList.Reverse();
                            Console.Write($"Разворот списка. ");
                            break;
                        case 1:
                            tmpList.Insert(index, data);
                            Console.Write($"В список по индексу {index} добавлен элемент [ {data} ]. ");
                            break;
                        case 2:
                            tmpList.AddFirst(data - 10);
                            Console.Write($"В начало списка добавлен элемент [ {data - 10} ]. ");
                            break;
                        case 3:
                            deletedItem = tmpList.RemoveAt(index);
                            Console.Write($"Удаляется элемент по индексу {index}, он содержал значение {deletedItem}. ");
                            break;
                        case 4:
                            deletedItem = tmpList.RemoveFirst();
                            Console.Write($"Удален первый элемент. Его значение [{deletedItem}]. ");
                            break;
                        case 5:
                            data = tmpList.GetData(0);
                            bool isDeleted = tmpList.Remove(data);
                            Console.Write($"Удаляется элемент со значением [{data}]. Успешно? {isDeleted}. ");
                            break;
                    }

                    Console.WriteLine($"Итоговый список: {tmpList}");
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            List<int> list = new List<int>(40);

            list.AddFirst(30);
            list.AddFirst(20);
            list.AddFirst(10);
            list.AddFirst(0);

            MethodsTest(list);

            try // тест копирования
            {
                List<int> list2 = list.GetCopy();
                Console.WriteLine("Копирование списка.");
                Console.WriteLine($"Исходный список: {list}");
                list.SetData(1, -333);
                Console.WriteLine($"Новый спиок: {list2}");

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            // Тест индексов
            
            Console.WriteLine();
            Console.WriteLine($"Исходный список: {list}");

            try // крайние индексы
            {
                Console.WriteLine($"Значение по индексу 0: {list.GetData(0)}");
                Console.WriteLine($"Значение по индексу {list.Count - 1}: {list.GetData(list.Count - 1)}");

            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            try // за границами списка
            {
                Console.WriteLine($"Значение по индексу -1: {list.GetData(-1)}");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            try // за границами списка
            {
                Console.WriteLine($"Значение по индексу {list.Count}: {list.GetData(list.Count)}");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            try // в границах списка
            {
                Console.WriteLine($"Значение по индексу {1}: {list.GetData(1)}");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
            
            Console.ReadKey();
        }
    }
}