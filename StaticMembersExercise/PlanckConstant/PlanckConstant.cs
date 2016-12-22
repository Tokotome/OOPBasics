//Create class Calculation. Define static constant with value 6.62606896e-34 (Planck constant) and 3.14159 (Pi). Add static method that returns reduced Planck constant by the formula: 
//{Planck constant} / (2 * {Pi constant})
//Print the result of the method on a single line on the console.Do not format in any way the result.


namespace PlackConstant
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine(Calculation.Cals());
        }
    }

    public class Calculation
    {
        public const double plank = 6.62606896e-34;
        public const double pi = 3.14159;

        public static double Cals()
        {
            return plank / (2 * pi);
        }
    }
}
