using Academits.Dorosh.ShapesTask.Shapes;
using System.Collections.Generic;

namespace Academits.Dorosh.ShapesTask.Comparers
{
    public class ShapesPerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return shape2.GetPerimeter().CompareTo(shape1.GetPerimeter());
        }
    }
}