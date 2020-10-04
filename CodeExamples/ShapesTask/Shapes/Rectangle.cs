namespace Academits.Dorosh.ShapesTask.Shapes
{
    class Rectangle : IShape
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetArea()
        {
            return Height * Width;
        }

        public double GetPerimeter()
        {
            return 2 * (Height + Width);
        }

        public override string ToString()
        {
            return string.Format("Прямоугольник (длина: {0:#.##}, ширина: {1:#.##})", Height, Width);
        }

        public override int GetHashCode()
        {
            int prime = 13;
            int hash = 1;

            hash = prime * hash + Height.GetHashCode();
            hash = prime * hash + Width.GetHashCode();

            return hash;
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

            Rectangle tmpRectangle = (Rectangle)obj;

            return Height == tmpRectangle.Height && Width == tmpRectangle.Width;
        }
    }
}