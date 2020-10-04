using Academits.Dorosh.VectorTask;
using System;

namespace Academits.Dorosh.MatrixTask
{
    class MatrixProgram
    {
        static void BinaryMethodsTests(Matrix matrix1, Matrix matrix2)
        {
            Console.WriteLine("Матрица 1:");
            Console.WriteLine(matrix1);
            Console.WriteLine();

            Console.WriteLine("Матрица 2:");
            Console.WriteLine(matrix2);
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                Matrix tmpMatrix1;

                try
                {
                    switch (i)
                    {
                        case 0:
                            Console.WriteLine("=== Умножение (статический): ===");
                            Console.WriteLine(Matrix.GetProduct(matrix1, matrix2));
                            break;
                        case 1:
                            Console.WriteLine("=== Сложение (статический): ===");
                            Console.WriteLine(Matrix.GetSum(matrix1, matrix2));
                            break;
                        case 2:
                            Console.WriteLine("=== Вычитание (статический): ===");
                            Console.WriteLine(Matrix.GetDifference(matrix1, matrix2));
                            break;
                        case 3:
                            Console.WriteLine("=== Сложение (не статический): ===");
                            tmpMatrix1 = new Matrix(matrix1);
                            tmpMatrix1.Add(matrix2);
                            Console.WriteLine(tmpMatrix1);
                            break;
                        case 4:
                            Console.WriteLine("=== Вычитание (не статический): ===");
                            tmpMatrix1 = new Matrix(matrix1);
                            tmpMatrix1.Subtract(matrix2);
                            Console.WriteLine(tmpMatrix1);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ошибка: {e.Message}");
                    Console.WriteLine();
                }
            }
        }

        static void UnaryMethodsTests(Matrix matrix)
        {
            Console.WriteLine("Исходная: ");
            Console.WriteLine(matrix);
            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                Matrix tmpMatrix;

                try
                {
                    switch (i)
                    {
                        case 0:
                            Console.WriteLine("=== Вычисление определителя матрицы: ===");
                            Console.WriteLine("Определитель: {0}", matrix.GetDeterminant());
                            break;
                        case 1:
                            Console.WriteLine("=== Умножение на скаляр: ===");
                            tmpMatrix = new Matrix(matrix);
                            tmpMatrix.MultiplyByNumber(10);
                            Console.WriteLine(tmpMatrix);
                            break;
                        case 2:
                            Console.WriteLine("=== Транспонирование матрицы: ===");
                            tmpMatrix = new Matrix(matrix);
                            tmpMatrix.Transpose();
                            Console.WriteLine("Транспонировнная: ");
                            Console.WriteLine(tmpMatrix);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ошибка: {e.Message}");
                    Console.WriteLine();
                }
            }
        }

        static void Main()
        {

            double[,] array1 =
            {
                {1, 0, 0, 0 },
                {1, 1, 0, 0 },
                {1, 1, 1, 0 },
                {1, 1, 1, 1 },
            };

            double[,] array2 =
            {
                {1, 1, 1, 1 },
                {0, 1, 1, 1 },
                {0, 0, 1, 1 },
                {0, 0, 0, 1 },
            };


            Matrix matrix1 = new Matrix(array1);
            Matrix matrix2 = new Matrix(array2);

            BinaryMethodsTests(matrix1, matrix2);

            Matrix matrix3 = new Matrix(new double[,]
            {
                {1, 2, 3, 4 },
                {5, 6, 7, 8 },
                {1, 9, 5, 1 },
                {2, 4, 8, 0 }
            }); //определитель = -576

            UnaryMethodsTests(matrix3);

            // Умножение матрицы на вертикальный вектор
            try
            {
                Vector vector = new Vector(2.0, 2.0, 2.0, 2.0);

                Console.WriteLine("=== Умножение на вертикальный вектор: ===");
                Console.WriteLine(matrix1.MultiplyByVector(vector));
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine($"Ошибка: {e.Message}");
                Console.WriteLine();
            }

            /*  
            // Тест индексов
            Matrix matrix4 = new Matrix(new double[,]
            {
                {3, 4 },
                {1, 2 },
                {3, 4 },
                {1, 2 }
            });

            int i = 1;
            int j = 3;

            try
            {
                Console.WriteLine($"Столбец {i + 1}: {matrix4.GetColumn(i)}");
            }
            catch(Exception e)
            {
                Console.WriteLine();
                Console.WriteLine($"Ошибка: {e.Message}");
                Console.WriteLine();
            }

            try
            {
                Console.WriteLine($"Строка {j + 1}: {matrix4.GetRow(j)}");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine($"Ошибка: {e.Message}");
                Console.WriteLine();
            }*/

            Console.ReadKey();
        }
    }
}