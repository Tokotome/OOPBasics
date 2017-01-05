//You are given a geometric figure box with parameters length, width and height.Model a class Box that that 
//can be instantiated by the same three parameters.Expose to the outside world only methods for its surface area, 
//lateral surface area and its volume. On the first three lines you will get the length, width and height.
//On the next three lines print the surface area, lateral surface area and the volume of the box.
//A box’s side should not be zero or a negative number.Expand your class from the previous problem by adding data validation
//for each parameter given to the constructor.Make a private setter that performs data validation internally.


namespace EncapsulationLab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    class ClassBox
    {
        static void Main(string[] args)
        {

            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            try
            {
                Box box = new Box(lenght, width, height);

                Console.WriteLine(box);
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }

        }
    }

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double GetSurfaceArea()
        {
            return   (2*this.length*this.width)
                  +  (2*this.length*this.height)
                  +  (2*this.width*this.height);
        }

        public double GetLateralSurfaceArea()
        {
            return   (2 * this.length * this.height)
                   + (2 * this.width * this.height);
        }

        public double GetVolume()
        {
            return (this.length * this.width * this.height);
        }

        public override string ToString()
        {
            string result =
                           $"Surface Area - {this.GetSurfaceArea():f2}\r\n" +
                           $"Lateral Surface Area - {this.GetLateralSurfaceArea():f2}\r\n" +
                           $"Volume - {this.GetVolume():f2}";

            return result;
        }

        public double Length
        {
            get { return this.length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }

                this.height = value;
            }
        }
    }
   
}
