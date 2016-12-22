//Define class TriangularPrism that has base side, height from base side and length.Define class Cube that has side 
//length and class Cylinder that has radius and height.Define class VolumeCalculator that holds static methods for calculating 
//the volume of these three figures.The input will be read from the console until command “End” is received and will be in some 
//of these formats: 
//•	TriangularPrism<base side> <height> <length>
//•	Cube<side length>
//•	Cylinder<radius> <height>
//The volume in the output must be rounded 3 digits after the floating point.



namespace ShapesVolume
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            while (!input.Equals("End"))
            {
                string[] parameters = input.Split(' ');
                switch (parameters[0])
                {
                    case "Cylinder":
                        Cylinder cyl = new Cylinder(double.Parse(parameters[1]), double.Parse(parameters[2]));
                        Console.WriteLine("{0:f3}", VolumeCalculator.CalculateVolume(cyl));
                        break;
                    case "Cube":
                        Cube c = new Cube(double.Parse(parameters[1]));
                        Console.WriteLine("{0:f3}", VolumeCalculator.CalculateVolume(c));
                        break;
                    case "TrianglePrism":
                        TrianglePrism t = new TrianglePrism(double.Parse(parameters[1]), double.Parse(parameters[2]), double.Parse(parameters[3]));
                        Console.WriteLine("{0:f3}", VolumeCalculator.CalculateVolume(t));
                        break;

                }

                input = Console.ReadLine();
            }
        }
    }

    public class TrianglePrism
    {
        public double baseSide;
        public double h;
        public double w;

        public TrianglePrism(double baseSide, double h, double w)
        {
            this.baseSide = baseSide;
            this.h = h;
            this.w = w;
        }
    }

    public class Cube
    {
        public double sideL;

        public Cube(double sideL)
        {
            this.sideL = sideL;
        }
    }

    public class Cylinder
    {
        public double radius;
        public double h;

        public Cylinder(double radius, double h)
        {
            this.radius = radius;
            this.h = h;
        }
    }

    public static class VolumeCalculator
    {
        public static double CalculateVolume(Cylinder c)
        {
            return Math.PI * Math.Pow(c.radius, 2) * c.h;
        }

        public static double CalculateVolume(Cube c)
        {
            return Math.Pow(c.sideL, 3);
        }

        public static double CalculateVolume(TrianglePrism c)
        {
            return (0.5 * c.baseSide * c.h) * c.w;


        }
    }
}
