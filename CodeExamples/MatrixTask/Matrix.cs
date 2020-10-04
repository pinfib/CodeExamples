using Academits.Dorosh.VectorTask;
using System;
using System.Text;

namespace Academits.Dorosh.MatrixTask
{
    public class Matrix
    {
        private Vector[] rows;

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0 || columnsCount <= 0)
            {
                throw new ArgumentException($"Передано: количество строк [{rowsCount}], количество столбцов [{columnsCount}]. Количество строк и столбцов матрицы должно быть больше нуля.");
            }

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = new Vector(columnsCount);
            }
        }

        public Matrix(double[,] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Передан пустой массив double, нельзя создать пустую матрицу.", nameof(array));
            }

            int rowsCount = array.GetLength(0);
            int columnsCount = array.GetLength(1);

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = new Vector(columnsCount);

                for (int j = 0; j < columnsCount; j++)
                {
                    rows[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] vectors)
        {
            if (vectors.Length == 0)
            {
                throw new ArgumentException("Передан пустой массив vectors, нельзя создать пустую матрицу.", nameof(vectors));
            }

            int columnsCount = vectors[0].GetSize();                 // поиск максимальной длины вектора

            foreach (Vector v in vectors)
            {
                columnsCount = Math.Max(columnsCount, v.GetSize());
            }

            rows = new Vector[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                rows[i] = new Vector(columnsCount);                 // все вектора матрицы объявить максимальной длины

                rows[i].Add(vectors[i]);
            }
        }

        public Matrix(Matrix matrix)
        {
            int rowsCount = matrix.GetRowsCount();

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = new Vector(matrix.rows[i]);
            }
        }

        public int GetColumnsCount()
        {
            return rows[0].GetSize();
        }

        public int GetRowsCount()
        {
            return rows.Length;
        }

        public Vector GetRow(int index)
        {
            int rowsCount = GetRowsCount();

            if (index < 0 || index >= rowsCount)
            {
                throw new IndexOutOfRangeException($"Передан индекс [{index}]. Допустимое значение индекса от 0 до {rowsCount - 1}.");
            }

            return new Vector(rows[index]);
        }

        public Vector GetColumn(int index)
        {
            int columnsCount = GetColumnsCount();

            if (index < 0 || index >= columnsCount)
            {
                throw new IndexOutOfRangeException($"Передан индекс [{index}]. Допустимое значение индекса от 0 до {columnsCount - 1}.");
            }

            int rowsCount = GetRowsCount();

            Vector vector = new Vector(rowsCount);

            for (int i = 0; i < rowsCount; i++)
            {
                vector.SetComponent(i, rows[i].GetComponent(index));
            }

            return vector;
        }

        public void SetRow(int index, Vector vector)
        {
            int size = vector.GetSize();
            int columnsCount = GetColumnsCount();

            if (size != columnsCount)
            {
                throw new ArgumentException($"Передан вектор размерности [{size}], количество столбцов в текущей матрице [{columnsCount}]. Размерности не совпадают.", nameof(vector));
            }

            int rowsCount = GetRowsCount();

            if (index < 0 || index >= rowsCount)
            {
                throw new IndexOutOfRangeException($"Передан индекс [{index}]. Допустимое значение индекса от 0 до {rowsCount - 1}.");
            }

            rows[index] = new Vector(vector);
        }

        public void Transpose()
        {
            int columnsCount = GetColumnsCount();

            Vector[] vectors = new Vector[columnsCount];

            for (int i = 0; i < columnsCount; i++)
            {
                vectors[i] = GetColumn(i);
            }

            rows = vectors;
        }

        public void MultiplyByNumber(double number)
        {
            foreach (Vector v in rows)
            {
                v.MultiplyByNumber(number);
            }
        }

        public void Add(Matrix matrix)
        {
            int columnsCount1 = GetColumnsCount();
            int columnsCount2 = matrix.GetColumnsCount();

            int rowsCount1 = GetRowsCount();
            int rowsCount2 = matrix.GetRowsCount();

            if (rowsCount1 != rowsCount2 || columnsCount1 != columnsCount2)
            {
                throw new ArgumentException($"Размеры текущей матрицы: {rowsCount1}x{columnsCount1}, входящей: {rowsCount2}x{columnsCount2}. Нельзя складывать или вычитать матрицы разных размерностей.");
            }

            for (int i = 0; i < rowsCount1; i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            int columnsCount1 = GetColumnsCount();
            int columnsCount2 = matrix.GetColumnsCount();

            int rowsCount1 = GetRowsCount();
            int rowsCount2 = matrix.GetRowsCount();

            if (rowsCount1 != rowsCount2 || columnsCount1 != columnsCount2)
            {
                throw new ArgumentException($"Размеры текущей матрицы: {rowsCount1}x{columnsCount1}, входящей: {rowsCount2}x{columnsCount2}. Нельзя складывать или вычитать матрицы разных размерностей.");
            }

            for (int i = 0; i < rowsCount1; i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }
        }

        public Vector MultiplyByVector(Vector vector)
        {
            int vectorLength = vector.GetSize();
            int rowsCount = GetRowsCount();
            int columnsCount = GetColumnsCount();

            if (vectorLength != columnsCount)
            {
                throw new ArgumentException($"Размеры текущей матрицы: {rowsCount}x{columnsCount}, размерность вектора: {vectorLength}. Количество столбцов в матрице и размерность вертикального вектора должны совпадать.");
            }

            Vector tmpVector = new Vector(rowsCount);

            for (int i = 0; i < rowsCount; i++)
            {
                double value = Vector.GetScalarMultiplication(rows[i], vector);

                tmpVector.SetComponent(i, value);
            }

            return tmpVector;
        }

        public double GetDeterminant()
        {
            int columnsCount = GetColumnsCount();
            int rowsCount = GetRowsCount();

            if (columnsCount != rowsCount)
            {
                throw new InvalidOperationException($"Размеры матрицы: {rowsCount}x{columnsCount}. Определитель можно найти только для квадратной матрицы.");
            }

            if (rowsCount == 1)
            {
                return rows[0].GetComponent(0);
            }

            Matrix tmpMatrix = new Matrix(this);

            double determinant = 1;

            for (int i = 0; i < rowsCount; i++)
            {
                if (IsEqual(tmpMatrix.GetRow(i).GetComponent(i), 0)) // Если текущий элемент 0, меняем местами текущую строку со следующий, где текущей элемент не 0
                {
                    Vector tmpVector = tmpMatrix.rows[i];

                    for (int j = i; j < rowsCount; j++)
                    {
                        if (IsEqual(tmpMatrix.rows[j].GetComponent(i), 0))
                        {
                            continue;
                        }

                        tmpMatrix.rows[i] = tmpMatrix.rows[j];
                        tmpMatrix.rows[j] = tmpVector;

                        determinant *= -1;

                        break;
                    }
                }

                for (int j = i + 1; j < rowsCount; j++)
                {
                    if (!IsEqual(tmpMatrix.rows[j].GetComponent(i), 0)) // Если текущий элемент не 0, приводим матрицу к верхнетреугольному виду
                    {
                        Vector tmpVector = new Vector(tmpMatrix.rows[i]);
                        tmpVector.MultiplyByNumber(tmpMatrix.rows[j].GetComponent(i) / tmpMatrix.rows[i].GetComponent(i));

                        tmpMatrix.rows[j].Subtract(tmpVector);
                    }
                }
            }

            for (int i = 0; i < rowsCount; i++)
            {
                determinant *= tmpMatrix.rows[i].GetComponent(i);
            }

            return determinant;
        }

        private static bool IsEqual(double a, double b)
        {
            double epsilon = 1.0e-10;

            return Math.Abs(a - b) <= epsilon;
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            int columnsCount1 = matrix1.GetColumnsCount();
            int columnsCount2 = matrix2.GetColumnsCount();

            int rowsCount1 = matrix1.GetRowsCount();
            int rowsCount2 = matrix2.GetRowsCount();

            if (rowsCount1 != rowsCount2 || columnsCount1 != columnsCount2)
            {
                throw new ArgumentException($"Размеры матрицы 1: {rowsCount1}x{columnsCount1}, размеры матрицы 2: {rowsCount2}x{columnsCount2}. Нельзя складывать или вычитать матрицы разных размерностей.");
            }

            Matrix newMatrix = new Matrix(matrix1);
            newMatrix.Add(matrix2);

            return newMatrix;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            int columnsCount1 = matrix1.GetColumnsCount();
            int columnsCount2 = matrix2.GetColumnsCount();

            int rowsCount1 = matrix1.GetRowsCount();
            int rowsCount2 = matrix2.GetRowsCount();

            if (rowsCount1 != rowsCount2 || columnsCount1 != columnsCount2)
            {
                throw new ArgumentException($"Размеры матрицы 1: {rowsCount1}x{columnsCount1}, размеры матрицы 2: {rowsCount2}x{columnsCount2}. Нельзя складывать или вычитать матрицы разных размерностей.");
            }

            Matrix newMatrix = new Matrix(matrix1);
            newMatrix.Subtract(matrix2);

            return newMatrix;
        }

        public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
        {
            int columnsCount1 = matrix1.GetColumnsCount();
            int columnsCount2 = matrix2.GetColumnsCount();

            int rowsCount1 = matrix1.GetRowsCount();
            int rowsCount2 = matrix2.GetRowsCount();

            if (columnsCount1 != rowsCount2)
            {
                throw new ArgumentException($"Размеры матрицы 1: {rowsCount1}x{columnsCount1}, размеры матрицы 2: {rowsCount2}x{columnsCount2}. Количество столбцов первой матрицы должно быть равно количеству строк второй.");
            }

            Matrix newMatrix = new Matrix(rowsCount1, columnsCount2);

            for (int i = 0; i < rowsCount1; i++)
            {
                Vector newVector = new Vector(columnsCount2);

                for (int j = 0; j < columnsCount2; j++)
                {
                    double value = Vector.GetScalarMultiplication(matrix1.rows[i], matrix2.GetColumn(j));

                    newVector.SetComponent(j, value);
                }

                newMatrix.SetRow(i, newVector);
            }

            return newMatrix;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("{");

            int rowsCount = GetRowsCount();

            for (int i = 0; i < rowsCount; i++)
            {
                stringBuilder.Append(rows[i]);

                if (i != rowsCount - 1)
                {
                    stringBuilder.AppendLine(", ");
                }
            }

            stringBuilder.AppendLine();
            stringBuilder.AppendLine("}");

            return stringBuilder.ToString();
        }
    }
}