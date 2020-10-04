using System;

namespace Academits.Dorosh.VectorTask
{
    class VectorCreation
    {
        public static Vector GetVector()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите размерность вектора: ");
                    int length = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Введите компоненты вектора через пробел: ");
                    char[] charSeparators = { ' ' };
                    string[] userLine = Console.ReadLine().Split(charSeparators);

                    double[] components = new double[length];

                    for (int i = 0; i < userLine.Length && i < length; i++)
                    {
                        try
                        {
                            components[i] = Convert.ToDouble(userLine[i]);
                        }
                        catch (FormatException)
                        {
                            components[i] = 0;
                        }
                    }

                    return new Vector(length, components);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }
            }
        }
    }
}