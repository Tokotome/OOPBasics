using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 7;
            something(a, b);
            Console.WriteLine(a);
            Console.WriteLine(b);

        }
        public static void something(int a, int b)
        {
            a = a + b;
            b = 7;
        }
    }
}