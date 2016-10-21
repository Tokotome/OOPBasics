//You are the owner of a courier company and want to make a system for tracking your cars and their cargo.Define a class Car 
//that holds information about model, engine, cargo and a collection of exactly 4 tires.The engine, cargo and tire should be 
//separate classes, create a constructor that receives all information about the Car and creates and initializes its inner 
//components(engine, cargo and tires). On the first line of input you will receive a number N - the amount of cars you have, 
//on each of the next N lines you will receive information about a car in the format “<Model> <EngineSpeed> <EnginePower> 
//<CargoWeight> <CargoType> <Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> 
//<Tire4Age>” where the speed, power, weight and tire age are integers, tire pressure is a double. After the N lines you will 
//receive a single line with one of 2 commands “fragile” or “flamable” , if the command is “fragile” print all cars whose Cargo 
//Type is “fragile” with a tire whose pressure is  < 1, if the command is “flamable” print all cars whose Cargo Type is “flamable” 
//and have Engine Power > 250. The cars should be printed in order of appearing in the input.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    class RawData
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carDetails = Console.ReadLine().Split();
                string carModel = carDetails[0];
                int engineSpeed = int.Parse(carDetails[1]);
                int enginePower = int.Parse(carDetails[2]);

                double cargoWeight = double.Parse(carDetails[3]);
                string cargoType = carDetails[4];

                double tire1Pressure = double.Parse(carDetails[5]);
                int tire1Age = int.Parse(carDetails[6]);
                double tire2Pressure = double.Parse(carDetails[7]);
                int tire2Age = int.Parse(carDetails[8]);
                double tire3Pressure = double.Parse(carDetails[9]);
                int tire3Age = int.Parse(carDetails[10]);
                double tire4Pressure = double.Parse(carDetails[11]);
                int tire4Age = int.Parse(carDetails[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[4];
                tires[0] = new Tire(tire1Pressure, tire1Age);
                tires[1] = new Tire(tire2Pressure, tire2Age);
                tires[2] = new Tire(tire3Pressure, tire3Age);
                tires[3] = new Tire(tire4Pressure, tire4Age);

                Car car = new Car(carModel, engine, cargo, tires);
                cars.Add(car);
            }
            string cargoTypeForPrint = Console.ReadLine();
            List<Car> sortedCars = new List<Car>();
            if (cargoTypeForPrint == "fragile")
            {
                sortedCars = cars
                    .Where(c => c.cargo.type == "fragile" &&
                    c.tires.Any(t => t.pressure < 1)).ToList();
            }
            else
            {
                sortedCars = cars
                    .Where(c => c.cargo.type == "flamable" && 
                    c.engine.power > 250).ToList();
            }
            foreach (var sortedCar in sortedCars)
            {
                Console.WriteLine(sortedCar.model);
            }
        }
    }

    class Car
    {
        public string model;
        public Engine engine;
        public Cargo cargo;
        public Tire[] tires;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
        }
    }

    class Engine
    {
        public int speed;
        public int power;

        public Engine(int speed, int power)
        {
            this.speed = speed;
            this.power = power;
        }
    }

    class Cargo
    {
        public double weight;
        public string type;

        public Cargo(double weight, string type)
       {
            this.weight = weight;
            this.type = type;
       }
    }

    class Tire
    {
        public double pressure;
        public int age;

        public Tire(double pressure, int age)
        {
            this.pressure = pressure;
            this.age = age;
        }
    }
}
