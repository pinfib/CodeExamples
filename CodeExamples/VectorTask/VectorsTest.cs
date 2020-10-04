using System;

namespace Academits.Dorosh.VectorTask
{
    class VectorsTest
    {
        public static void ObjectMethodsTest(Vector vector1, Vector vector2)
        {
            Console.WriteLine();

            Console.WriteLine("Исходные векторы");
            Console.WriteLine("Вектор 1 - " + vector1.ToString());
            Console.WriteLine("Вектор 2 - " + vector2.ToString());
            Console.WriteLine();

            for (int i = 0; i < 2; i++)
            {
                Vector tmpVector1 = new Vector(vector1);
                Vector tmpVector2 = new Vector(vector2);

                switch (i)
                {
                    case 0:
                        Console.Write("Сложение векторов: ".PadRight(25, ' '));
                        tmpVector1.Add(tmpVector2);
                        break;
                    case 1:
                        Console.Write("Вычитание векторов: ".PadRight(25, ' '));
                        tmpVector1.Subtract(tmpVector2);
                        break;
                }

                Console.WriteLine(tmpVector1.ToString());
            }
        }

        public static void StaticMethodsTest(Vector vector1, Vector vector2)
        {
            Console.WriteLine();

            Console.WriteLine("Исходные векторы");
            Console.WriteLine("Вектор 1 - " + vector1.ToString());
            Console.WriteLine("Вектор 2 - " + vector2.ToString());
            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                Vector tmpVector1 = new Vector(vector1);
                Vector tmpVector2 = new Vector(vector2);

                Vector vector3 = null;

                switch (i)
                {
                    case 0:
                        Console.Write("Сложение векторов: ".PadRight(25, ' '));
                        vector3 = Vector.GetSum(tmpVector1, tmpVector2);
                        Console.WriteLine(vector3.ToString());
                        break;
                    case 1:
                        Console.Write("Вычитание векторов: ".PadRight(25, ' '));
                        vector3 = Vector.GetDifference(tmpVector1, tmpVector2);
                        Console.WriteLine(vector3.ToString());
                        break;
                    case 2:
                        Console.Write("Скалярное произведение векторов: ".PadRight(25, ' '));
                        Console.WriteLine(Vector.GetScalarMultiplication(tmpVector1, tmpVector2));
                        break;
                }
            }
        }

        public static void SelfMethodsTest(Vector vector, double scalar)
        {
            Console.WriteLine();

            Console.WriteLine("Исходный вектор");
            Console.WriteLine("Вектор 1 - {0},  длина вектора: {1:#.###}, размерность: {2:#.###}", vector.ToString(), vector.GetModule(), vector.GetSize());
            Console.WriteLine();

            for (int i = 0; i < 2; i++)
            {
                Vector tmpVector = new Vector(vector);

                switch (i)
                {
                    case 0:
                        Console.Write("Умножение на скаляр: ".PadRight(25, ' '));
                        tmpVector.MultiplyByNumber(scalar);
                        break;
                    case 1:
                        Console.Write("Разворот вектора: ".PadRight(25, ' '));
                        tmpVector.Negate();
                        break;
                }

                Console.WriteLine(tmpVector.ToString());
            }
        }
    }
}