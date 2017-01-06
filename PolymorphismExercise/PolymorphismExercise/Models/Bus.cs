using _01.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismExercise.Models
{
    public class Bus : Vehicle
    {
        private const double airConditionerConsumption = 1.4;


        public Bus(double fuelQuantity, double fuelConsumtion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                Console.WriteLine("Cannot fit fuel in tank");
            }
            else
            {
                base.Refuel(liters);
            }
        }




        protected override void DriveDistance(double distance, string type, bool isEmpty)
        {
            if (isEmpty)
            {
                this.FuelConsumtion += airConditionerConsumption;
            }

            base.DriveDistance(distance, type, isEmpty);
        }


    }
}
