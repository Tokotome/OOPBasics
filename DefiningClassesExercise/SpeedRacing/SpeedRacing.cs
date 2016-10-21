//Your task is to implement a program that keeps track of cars and their fuel and supports methods for moving the cars.
//Define a class Car that keeps track of a car’s Model, fuel amount, fuel cost for 1 kilometer and distance traveled.
//A Car’s Model is unique - there will never be 2 cars with the same model. On the first line of the input you will 
//receive a number N – the number of cars you need to track, on each of the next N lines you will receive information 
//for a car in the following format “<Model> <FuelAmount> <FuelCostFor1km>”, all cars start at 0 kilometers traveled.
//After the N lines until the command “End” is received, you will receive a commands in the following format “Drive<CarModel>  
//<amountOfKm>”, implement a method in the Car class to calculate whether or not a car can move that distance, if it can the car’s 
//fuel amount should be reduced by the amount of used fuel and its distance traveled should be increased by the amount of kilometers 
//traveled, otherwise the car should not move(Its fuel amount and distance traveled should stay the same) and you should print 
//on the console “Insufficient fuel for the drive”. After the “End” command is received, print each car and its current fuel amount and 
//distance traveled in the format “<Model> <fuelAmount>  <distanceTraveled>”, where the fuel amount should be printed to two decimal places after the separator.



namespace SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Car
    {
        public string model;
        public double fuel;
        public double fuelConsumption;
        public double distanceTraveled;

        public Car(string model, double fuel, double fuelConsumption)
        {
            this.model = model;
            this.fuel = fuel;
            this.fuelConsumption = fuelConsumption;
            this.distanceTraveled = 0;
        }

        public void Drive(int ammountOfKilometeres)
        {
            if (ammountOfKilometeres <= this.fuel / this.fuelConsumption)
            {
                this.distanceTraveled += ammountOfKilometeres;
                this.fuel -= this.fuelConsumption * ammountOfKilometeres;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }

    class SpeedRacing
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string model = input[0];
                double fuel = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);
                Car car = new Car(model, fuel, fuelConsumption);
                cars.Add(car);
            }
            string driveCommand = Console.ReadLine();
            while (driveCommand != "End")
            {
                string[] driveCommandArgs = driveCommand.Split(' ');
                string carModel = driveCommandArgs[1];
                int ammountOfKilometers = int.Parse(driveCommandArgs[2]);
                Car carToDrive = cars.First(x => x.model == carModel);
                carToDrive.Drive(ammountOfKilometers);
                driveCommand = Console.ReadLine();
            }
            foreach (var car in cars)
            {
                Console.WriteLine("{0} {1:F2} {2}", car.model, car.fuel, car.distanceTraveled);
            }
        }
    }
}
