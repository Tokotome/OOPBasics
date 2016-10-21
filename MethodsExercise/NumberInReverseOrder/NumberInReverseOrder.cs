//Write a class DecimalNumber that has a method that prints all its digits in reversed order.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberInReverseOrder
{
    public class DecimalNumber
    {
        public decimal Reversed(string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i =  input.Length-1; i>=0;  i--)
            {
                sb.Append(input[i]);
            }
            return decimal.Parse(sb.ToString());
        }
    }
    class NumberInReverseOrder
    {
        static void Main(string[] args)
        {
            DecimalNumber n = new DecimalNumber();
            string someInput = Console.ReadLine();
            Console.WriteLine(n.Reversed(someInput));
        }
    }
}
