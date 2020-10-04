using Academits.Dorosh.ShapesTask.Comparers;
using Academits.Dorosh.ShapesTask.Shapes;
using System;
using System.Collections.Generic;

namespace Academits.Dorosh.ShapesTask
{
    class ShapesProgram
    {
        public static IShape GetShapeByPosition(IShape[] shapes, IComparer<IShape> comparer, int positionNumber)
        {
            Array.Sort(shapes, comparer);

            return shapes[positionNumber];
        }

        public static void Print(IShape shape)
        {
            Console.Write("H: {0, -4:#.##} W: {1, -4:#.##} PERIMETER: {2, -8:#.##} AREA: {3, -8:#.##} ", shape.GetHeight(), shape.GetWidth(), shape.GetPerimeter(), shape.GetArea());
            Console.Write("ToString: {0}", shape);
            //Console.Write("HashCode: {0}", shape.GetHashCode());
            Console.WriteLine();
        }

        static void Main()
        {
            IShape[] shapes =
            {
                new Square(10),
                new Square(10),
                new Square(20),
                new Triangle(0, 0, 3, 1, 1, 4),
                new Triangle(-1, 1, 4, 0, -2, -2),
                new Rectangle(5, 7),
                new Circle(5.5),
                new Circle(7)
            };

            foreach (IShape shape in shapes)
            {
                Print(shape);
            }

            Console.WriteLine();
            Console.WriteLine("Первая по площади фигура:");
            Print(GetShapeByPosition(shapes, new ShapesAreaComparer(), 0));

            Console.WriteLine();
            Console.WriteLine("Вторая по периметру фигура:");
            Print(GetShapeByPosition(shapes, new ShapesPerimeterComparer(), 1));

            Console.ReadLine();
        }
    }
}