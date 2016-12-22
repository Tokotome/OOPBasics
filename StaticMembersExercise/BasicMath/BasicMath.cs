//Define MathUtil class that supports basic mathematical operations:
//•	Sum<first number> <second number>
//•	Subtract<first number> <second number>
//•	Multiply<first number> <second number>
//•	Divide<dividend> <divisor>
//•	Percentage<total number> <percent of that number>
//Use static methods and make sure that the application will work with floating point numbers.
//Read from the console until you receive command “End”. Results must be formatted with 2 digits after the floating point.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicMath
{
    class BasicMath
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            string input = Console.ReadLine();
            while (!input.Equals("End"))
            {
                string[] parameters = input.Split(' ');
                string operation = parameters[0];
                double a = double.Parse(parameters[1]);
                double b = double.Parse(parameters[2]);

                if (operation == "Sum")
                {
                    Console.WriteLine("{0:f2}", MathUtil.Summing(a, b)); 
                }

                else if (operation == "Multiply")
                {
                    Console.WriteLine("{0:f2}", MathUtil.Multiply(a, b)); 
                }

                else if (operation == "Divide")
                {
                    Console.WriteLine("{0:f2}", MathUtil.Dividing(a, b));
                }

                else if (operation == "Percentage")
                {
                    Console.WriteLine("{0:f2}", MathUtil.Percentage(a, b));
                }

                else if (operation == "Subtract")
                {
                    Console.WriteLine("{0:f2}", MathUtil.Subtracting(a, b));
                }

                else
                {
                    throw new ArgumentException("Sorry, you need to enter a valid mathematical operation!");
                }

                input = Console.ReadLine();
            }
        }
    }

    public class MathUtil
    {
        public static double Summing(double a, double b)
        {
            return a + b;
        }

        public static double Dividing(double a, double b)
        {
            return a / b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Percentage(double a, double b)
        {
            return a * (b / 100);
        }

        public static double Subtracting(double a, double b)
        {
            return a - b;
        }

    }
}