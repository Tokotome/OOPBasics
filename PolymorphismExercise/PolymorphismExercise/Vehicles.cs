//Write a program that models 2 vehicles(Car and Truck) and will be able to simulate driving and refueling them.
//Car and truck both have fuel quantity, fuel consumption in liters per km and can be driven given distance and 
//refueled with given liters. But in the summer both vehicles use air conditioner and their fuel consumption per km 
//is increased by 0.9 liters for the car and with 1.6 liters for the truck. Also the truck has a tiny hole in his 
//tank and when it gets refueled it gets only 95% of given fuel.The car has no problems when refueling and adds all 
//given fuel to its tank.If vehicle cannot travel given distance its fuel does not change.
//Use your solution of the previous task for starting point and add more functionality. Add new vehicle – Bus.
//Now every vehicle has tank capacity and fuel quantity cannot fall below 0 (If fuel quantity become less than 0 
//print on the console “Fuel must be a positive number”). The car and the bus cannot be filled with fuel more than their 
//tank capacity.If you try to put more fuel in the tank than the available space, print on the console “Cannot fit fuel 
//in tank” and do not add any fuel in vehicles tank. Add new command for the bus.The bus can drive with or without people.
//If the bus is driving with people, the air-conditioner is turned on and its fuel consumption per kilometer is increased 
//with 1.4 liters.If there are no people in the bus when driving the air-conditioner is turned off and does not increase 
//the fuel consumption.
//                                                                                                                     Output
//After each Drive command print whether the Car/Truck was able to travel given distance in format if it’s successful:
//Car/Truck/Bus travelled { distance}
//km
//Or if it is not:
//Car/Truck/Bus needs refueling
//If given fuel is ≤ 0 print “Fuel must be a positive number”.
//If given fuel cannot fit in car or bus tank print “Cannot fit in tank”
//Finally print the remaining fuel for both car and truck rounded 2 digits after floating point in format:
//Car:{liters} Truck: {liters} Bus:{liters}

namespace _01.Vehicles
{
    using PolymorphismExercise.Models;
    using System;

    public class Vehicles
    {
        static void Main()
        {

            string[] inputCar = Console.ReadLine().Split(' ');
            string[] inputTruck = Console.ReadLine().Split(' ');
            string[] inputBus = Console.ReadLine().Split(' ');
            double carFuelQuantity = double.Parse(inputCar[1]);
            double carFuelPerKM = double.Parse(inputCar[2]);
            double carFuelCapcity = double.Parse(inputCar[3]);
            Vehicle car = new Car(carFuelQuantity, carFuelPerKM, carFuelCapcity);

            double truckFuelQuantity = double.Parse(inputTruck[1]);
            double truckFuelPerKM = double.Parse(inputTruck[2]);
            double truckFuelCapacity = double.Parse(inputTruck[3]);
            Vehicle truck = new Truck(truckFuelQuantity, truckFuelPerKM, truckFuelCapacity);

            double busFuelQuantity = double.Parse(inputBus[1]);
            double busfuelPerKM = double.Parse(inputBus[2]);
            double busfuelCapacity = double.Parse(inputBus[3]);
            Vehicle bus = new Bus(busFuelQuantity, busfuelPerKM, busfuelCapacity);


            int countOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCommands; i++)
            {
                string[] commands = Console.ReadLine().Split(' ');

                switch (commands[1])
                {
                    case "Car":
                        {
                            if (commands[0].Equals("Drive"))
                            {
                                double distance = double.Parse(commands[2]);
                                car.CanDriveGivenDistance(distance, "Car", true);
                            }
                            else
                            {
                                double fuel = double.Parse(commands[2]);
                                car.Refuel(fuel);
                            }
                            break;
                        }
                    case "Truck":
                        {
                            if (commands[0].Equals("Drive"))
                            {
                                double distance = double.Parse(commands[2]);
                                truck.CanDriveGivenDistance(distance, "Truck", true);
                            }
                            else
                            {
                                double fuel = double.Parse(commands[2]);
                                truck.Refuel(fuel);
                            }
                            break;
                        }
                    case "Bus":
                        {
                            if (commands[0].Equals("Drive"))
                            {
                                double distance = double.Parse(commands[2]);
                                bus.CanDriveGivenDistance(distance, "Bus", true);
                            }
                            else if (commands[0].Equals("DriveEmpty"))
                            {

                                double distance = double.Parse(commands[2]);
                                bus.CanDriveGivenDistance(distance, "Bus", false);
                            }
                            else
                            {
                                double fuel = double.Parse(commands[2]);
                                bus.Refuel(fuel);
                            }

                            break;
                        }

                }
            }
            Console.WriteLine("Car: {0:f2}", car.FuelQuantity);
            Console.WriteLine("Truck: {0:f2}", truck.FuelQuantity);
            Console.WriteLine("Bus: {0:f2}", bus.FuelQuantity);
        }
    }
}
