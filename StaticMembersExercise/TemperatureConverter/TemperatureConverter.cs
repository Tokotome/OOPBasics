//Create a program that converts temperature from Celsius to Fahrenheit and vice versa.Use 
//static methods.The input data will be in format: {temperature} {unit}. Temperatures will be 
//in integer number and units will be one of these two values: Celsius / Fahrenheit.Output value 
//must be double value following of empty space and the converted unit.You are going to receive 
//input, until you receive command “End”. The output must be formatted 2 digits after floating point.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ConvertsTempreture
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            while (!input.Equals("End"))
            {
                string[] parameters = input.Split(' ');
                switch (parameters[1])
                {
                    case "Fahrenheit":
                        Console.WriteLine(FaremheitToCelsuis(int.Parse(parameters[0])));
                        break;
                    case "Celsius":
                        Console.WriteLine(CelsuisToFarenhiet(int.Parse(parameters[0])));
                        break;
                }

                input = Console.ReadLine();
            }


        }


        static string CelsuisToFarenhiet(int tempreture)
        {
            double result = tempreture * 1.8 + 32;
            return string.Format("{0:f2} Fahrenheit", result);
        }

        static string FaremheitToCelsuis(int tempreture)
        {
            double result = (tempreture - 32) / 1.8;
            return string.Format("{0:f2} Celsius", result);
        }

    }
}