using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesMan
{
    class Program
    {
        static void main()
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();
            int numberOfEngines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineInfo = Console.ReadLine().Split();
                Engine engine = null;
                int displacement = 0;
                if (engineInfo.Length == 2)
                {
                    engine = new Engine(engineInfo[0], int.Parse(engineInfo[1]));
                }
                else if (engineInfo.Length == 4)
                {
                    engine = new Engine(engineInfo[0], int.Parse(engineInfo[1]),
                    int.Parse(engineInfo[2]), engineInfo[3]);
                }
                else if (engineInfo.Length == 3 && int.TryParse(engineInfo[2], out displacement))
                {
                    engine = new Engine(engineInfo[0], int.Parse(engineInfo[1]), displacement);
                }
                else
                {
                    engine = new Engine(engineInfo[0], int.Parse(engineInfo[1]), engineInfo[2]);
                }
                engines.Add(engine);
            }
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carsInfo = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                Engine engine = engines.First(e => e.model == carsInfo[1]);
                Car car = null;
                int weight = 0;

                if (carsInfo.Length == 2)
                {
                    car = new Car(carsInfo[0], engine);
                }
                else if (carsInfo.Length == 4)
                {
                    car = new Car(carsInfo[0], engine, int.Parse(carsInfo[2]), carsInfo[3]);
                }
                else if (carsInfo.Length == 3 && int.TryParse(carsInfo[2], out weight))
                {
                    car = new Car(carsInfo[0], engine, weight);
                }
                else
	            {
                    car = new Car(carsInfo[0], engine, carsInfo[2]);
                }
                cars.Add(car);
            }
            foreach (var car in cars)
            {
                Console.WriteLine(" {0}:", car.model);
                Console.WriteLine("  : {0}", car.engine.model);
                Console.WriteLine("    Power: {0}", car.engine.power);
                Console.WriteLine("    Displacement: {0}", 
                car.engine.displacement == -1 ? @"n/a" : car.engine.displacement.ToString());
                Console.WriteLine("    Efficiency: {0}", car.engine.efficiency);
                Console.WriteLine("  Weight: {0}", car.weight == -1 ? @"n/a" : car.weight.ToString());
                Console.WriteLine("  Color: {0}", car.color);
            }
        }
    }
}
    public class Engine
    {
        public string model;
        public int power;
        public int displacement;
        public string efficiency;
        private string v;

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public Engine(string model, int power) 
            : this(model, power, -1, @"n/a")
        {
            
        }

        public Engine(string model, int power, int displacement )
            : this(model, power, displacement, @"n/a")
        {

        }

        public Engine(string model, string efficiency, int power)
            : this(model, power, -1, efficiency)
        {

        }

        public Engine(string model, int power, string v) : this(model, power)
        {
            this.v = v;
        }
    }

    public class Car
    {
        public string model;
        public Engine engine;
        public int weight;
        public string color;

        public Car(string model, Engine engine)
            :this(model, engine, -1, @"n/a")
        {

        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine, weight, @"n/a")
        {

        }

        public Car(string model, Engine engine, string color)
            : this(model, engine, -1, @"n/a")
        {

        }

        public Car(string model, Engine engine, int weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }
     }

