using System;


namespace Geometry
{
    public interface IForm
    {
        double GetArea();
    }
    public class Triangle : IForm
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public Triangle(double SideA, double SideB, double SideC)
        {
            if (SideA + SideB <= SideC || SideA + SideC <= SideB || SideB + SideC <= SideA)
                throw new Exception("The provided sides don`t allow to construct a triangle." +
                    "The triangle inequality rule has been violated.");

            if (SideA < 0 || SideB < 0 || SideC < 0) throw new Exception("The sides must have positive values.");

            this.SideA = SideA;
            this.SideB = SideB;
            this.SideC = SideC;
        }
        public double GetArea()
        {
            var semiperimeter = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(semiperimeter * (semiperimeter - SideA) * 
                (semiperimeter - SideB) * (semiperimeter - SideC));
        }

        public bool IsRightTriangle()
        {
            double[] sides = { SideA, SideB, SideC };
            Array.Sort(sides);

            var squareLegsSumm = Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2);
            var squareHypothenus = Math.Pow(sides[2], 2);

            return Math.Abs(squareLegsSumm - squareHypothenus) < 1e-8;
        }
    }

    public class Circle : IForm
    {
        public double Radius { get; }

        public Circle(double Radius)
        {
            if (Radius <= 0)
                throw new ArgumentException("Radius must have positive value.");

            this.Radius = Radius;
        }
        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    public class Factory
    {
        public static IForm CreateForm(double sideA, double sideB, double sideC)
        {

            return new Triangle(sideA, sideB, sideC);
        }

        public static IForm CreateForm(double radius)
        {
            return new Circle(radius);
        }
    }

}
