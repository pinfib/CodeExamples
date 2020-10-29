using System;
using System.Text;

namespace Academits.Dorosh.TreeTask
{
    class TreeProgram
    {
        static void Main(string[] args)
        {
            try
            {
                //var numbersTree = new Tree<int>(8, new ReverseIntComparer());
                var numbersTree = new Tree<int>(8);

                numbersTree.Add(10);
                numbersTree.Add(3);
                numbersTree.Add(1);
                numbersTree.Add(6);
                numbersTree.Add(14);
                numbersTree.Add(4);
                numbersTree.Add(7);
                numbersTree.Add(13);

                Console.WriteLine("Дерево int");

                Console.WriteLine(numbersTree);

                var stringBuilder = new StringBuilder();
                Action<int> action = (x) => { stringBuilder.Append($"{x} "); };

                numbersTree.BreadthFirstTraversal(action);
                Console.WriteLine($"Обход в ширину:\t\t\t{stringBuilder}");
                Console.WriteLine();

                stringBuilder.Clear();
                numbersTree.RecursiveDepthFirstTraversal(action);
                Console.WriteLine($"Обход в глубину с рекурсией:\t{stringBuilder}");
                Console.WriteLine();

                stringBuilder.Clear();
                numbersTree.DepthFirstTraversal(action);
                Console.WriteLine($"Обход в глубину:\t\t{stringBuilder}");
                Console.WriteLine();

                var data = 10;
                Console.WriteLine($"Содержится ли в дереве элемент {data}? {numbersTree.Contains(data)}");
                Console.WriteLine();

                Console.WriteLine("Удаление элемента по значению.");
                Console.WriteLine($"Удаляется элемент \"{data}\". Удаление успешно? {numbersTree.Remove(data)}");
                Console.WriteLine(numbersTree);

                Console.WriteLine($"Содержится ли в дереве элемент {data}? {numbersTree.Contains(data)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                var stringsTree = new Tree<string>("корень");

                stringsTree.Add(null);
                stringsTree.Add("собака");
                stringsTree.Add("мышь");
                stringsTree.Add("попугай");
                stringsTree.Add("черепаха");
                stringsTree.Add(null);
                stringsTree.Add("як");
                stringsTree.Add("коза");
                stringsTree.Add("корова");
                stringsTree.Add("конь");
                stringsTree.Add("кот");

                Console.WriteLine();
                Console.WriteLine("Дерево string");
                Console.WriteLine();

                Console.WriteLine(stringsTree);

                var stringBuilder = new StringBuilder();
                var stringInsert = new StringBuilder("Животное: ");
                Action<string> action = (x) =>
                {
                    if (x == null)
                    {
                        stringBuilder.AppendLine("null");
                    }
                    else
                    {
                        stringBuilder.AppendLine($"{stringInsert}{x}");
                    }
                };

                stringsTree.BreadthFirstTraversal(action);
                Console.WriteLine("Обход в ширину:");
                Console.WriteLine(stringBuilder);
                Console.WriteLine();

                stringBuilder.Clear();
                stringsTree.RecursiveDepthFirstTraversal(action);
                Console.WriteLine("Обход в глубину с рекурсией:");
                Console.WriteLine(stringBuilder);
                Console.WriteLine();

                stringBuilder.Clear();
                stringsTree.DepthFirstTraversal(action);
                Console.WriteLine("Обход в глубину:");
                Console.WriteLine(stringBuilder);
                Console.WriteLine();

                Console.WriteLine("Удаление элемента по значению.");
                var data = "корень";
                Console.WriteLine($"Удаляется элемент \"{data}\". Удаление успешно? {stringsTree.Remove(data)}");
                Console.WriteLine(stringsTree);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
