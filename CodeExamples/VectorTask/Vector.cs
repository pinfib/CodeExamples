using System;
using System.Text;

namespace Academits.Dorosh.VectorTask
{
    public class Vector
    {
        private double[] components;

        public Vector(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException($"Передано значение размерности [{length}]. Размерность не может быть меньше или равна 0", nameof(length));
            }

            components = new double[length];
        }

        public Vector(Vector vector)
        {
            components = new double[vector.GetSize()];
            vector.components.CopyTo(components, 0);
        }

        public Vector(params double[] components)
        {
            if (components.Length == 0)
            {
                throw new ArgumentException($"Размер массива [{components.Length}]. Размерность не может быть меньше или равна 0", nameof(components.Length));
            }

            this.components = new double[components.Length];
            components.CopyTo(this.components, 0);
        }

        public Vector(int length, params double[] components)
        {
            if (length <= 0)
            {
                throw new ArgumentException($"Передано значение размерности [{length}]. Размерность не может быть меньше или равна 0", nameof(length));
            }

            if (components == null)
            {
                throw new ArgumentNullException(nameof(length), "Переданный массив - null");
            }

            this.components = new double[length];

            if (components != null && components.Length > 0)
            {
                Array.Copy(components, this.components, Math.Min(components.Length, length));
            }
        }

        public int GetSize()
        {
            return components.Length;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("{ ");

            int size = GetSize();

            for (int i = 0; i < size; i++)
            {
                stringBuilder.AppendFormat("{0, -4:0.##}", components[i]);

                if (i != size - 1)
                {
                    stringBuilder.Append("; ");
                }
            }

            stringBuilder.Append(" }");

            return stringBuilder.ToString();
        }

        public void Add(Vector vector)
        {
            int newSize = vector.GetSize();

            if (GetSize() < newSize)
            {
                Array.Resize(ref components, newSize);
            }

            for (int i = 0; i < newSize; i++)
            {
                components[i] += vector.components[i];
            }
        }

        public void Subtract(Vector vector)
        {
            int size = vector.GetSize();

            if (GetSize() < size)
            {
                Array.Resize(ref components, size);
            }

            for (int i = 0; i < size; i++)
            {
                components[i] -= vector.components[i];
            }
        }

        public void MultiplyByNumber(double number)
        {
            int size = GetSize();

            for (int i = 0; i < size; i++)
            {
                components[i] *= number;
            }
        }

        public void Negate()
        {
            MultiplyByNumber(-1);
        }

        public double GetModule()
        {
            double module = 0;

            foreach (double n in components)
            {
                module += Math.Pow(n, 2);
            }

            return Math.Sqrt(module);
        }

        public double GetComponent(int index)
        {
            return components[index];
        }

        public void SetComponent(int index, double value)
        {
            components[index] = value;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector newVector = new Vector(vector1);
            newVector.Add(vector2);

            return newVector;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector newVector = new Vector(vector1);
            newVector.Subtract(vector2);

            return newVector;
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            double result = 0;

            int computationLength = Math.Min(vector1.GetSize(), vector2.GetSize());

            for (int i = 0; i < computationLength; i++)
            {
                result += vector1.components[i] * vector2.components[i];
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Vector tmpVector = (Vector)obj;
            int size = GetSize();

            if (size != tmpVector.GetSize())
            {
                return false;
            }

            for (int i = 0; i < size; i++)
            {
                if (components[i] != tmpVector.components[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 13;
            int hash = 1;

            foreach (double e in components)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }
    }
}