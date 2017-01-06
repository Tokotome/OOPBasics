namespace _01.Vehicles
{
    using System;

    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumtion;
        private double drivenDistance;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumtion, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumtion = fuelConsumtion;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }

            set
            {
                this.fuelQuantity = value;
            }
        }

        public virtual double FuelConsumtion
        {
            get
            {
                return this.fuelConsumtion;
            }

            set
            {
                this.fuelConsumtion = value;
            }
        }

        public double DrivenDistance => this.drivenDistance;

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }

            set
            {
                this.tankCapacity = value;
            }
        }

        public virtual void Refuel(double liters)
        {
            this.fuelQuantity += liters;
        }

        protected virtual void DriveDistance(double distance, string type, bool isEmpty)
        {
            this.fuelQuantity -= (distance) * this.fuelConsumtion;
            this.drivenDistance = distance;
            Console.WriteLine("{0} travelled {1} km", type, distance);
        }


        public void CanDriveGivenDistance(double distance, string type, bool isEmpty)
        {
            if (this.FuelQuantity - (distance) * this.fuelConsumtion > 0)
            {
                this.DriveDistance(distance, type, isEmpty);
            }
            else
            {
                Console.WriteLine("{0} needs refueling", type);
            }
        }
    }
}
