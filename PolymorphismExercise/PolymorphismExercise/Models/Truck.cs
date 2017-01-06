using _01.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismExercise.Models
{
    public class Truck : Vehicle
    {
        private const double SummerConsumption = 1.6;
        private const double percentOfInfusionInTank = 0.95;


        public Truck(double fuelQuantity, double fuelConsumtion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {
        }

        public override double FuelConsumtion
        {
            set { base.FuelConsumtion = value + SummerConsumption; }
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * percentOfInfusionInTank);
        }
    }
}
