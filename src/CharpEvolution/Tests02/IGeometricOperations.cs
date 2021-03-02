using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpEvolution
{
    public interface IGeometricOperations
    {
        double TriangleArea(double width, double height);
        double CircleArea(double radius);
        double SquareArea(double width, double height);
        double Volume(double area, double lenght, double height);
    }
    public class GeometricOperations : IGeometricOperations
    {
        public double CircleArea(double radius)
        {
            return Math.Round(Math.PI * Math.Pow(radius, 2));
        }

        public double SquareArea(double width, double height)
        {
            return Math.Round(width * height, 2);
        }

        public double TriangleArea(double width, double height)
        {
            return Math.Round((width * height) / 2, 2);
        }

        public double Volume(double area, double lenght, double height)
        {
            return Math.Round(area * lenght * height, 2);
        }
    }
}
