//Define class BeerCounter holding static field beerInStock that shows how many beers you bought and static 
//field beersDrankCount that shows how many beers you have drunk.Manipulate the static fields through static 
//methods BuyBeer(int bottlesCount) and DrinkBeer(int bottlesCount). On every input line you will get pair of 
//beers you bought and beers you drank, until you receive command “End”. 
//•	BuyBeer – add beers to the beers in stock
//•	DrinkBeer – add beers to the drunk beers counter and subtract beers in stock
//After that print beersInStock and beersDrankCount on the same line separated by 1 space.


namespace _04.BeerCounter
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            while (!input.Equals("End"))
            {
                int[] p = input.Split(' ').Select(int.Parse).ToArray();
                BeerCounter.BuyBeer(p[0]);
                BeerCounter.DrinkBeer(p[1]);

                input = Console.ReadLine();
            }

            Console.WriteLine($"{BeerCounter.beersInStock} {BeerCounter.beersDrank}");
        }
    }

    public class BeerCounter
    {
        public static int beersInStock;
        public static int beersDrank;

        public static void BuyBeer(int bottles)
        {
            beersInStock += bottles;
        }

        public static void DrinkBeer(int bottles)
        {
            beersDrank += bottles;
            beersInStock -= bottles;
        }

    }
}
