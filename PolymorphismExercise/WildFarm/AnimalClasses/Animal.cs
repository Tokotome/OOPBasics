namespace AnimalClasses
{
    using WildFarm.FoodClasses;

    public abstract class Animal
    {
        private string animalName;
        private string animalType;
        private double animalWeight;
        private int foodEaten;

        public Animal(string animalName, string animalType, double animalWeight)
        {
            this.AnimalName = animalName;
            this.AnimalType = animalType;
            this.AnimalWeight = animalWeight;
        }

        public virtual string AnimalName
        {
            get
            {
                return animalName;
            }

            set
            {
                animalName = value;
            }
        }

        public virtual string AnimalType
        {
            get
            {
                return animalType;
            }

            set
            {
                animalType = value;
            }
        }

        public virtual double AnimalWeight
        {
            get
            {
                return animalWeight;
            }

            set
            {
                animalWeight = value;
            }
        }

        public virtual int FoodEaten
        {
            get
            {
                return foodEaten;
            }

            set
            {
                foodEaten = value;
            }
        }

        public abstract void MakeSound();
        public abstract void Eat(Food food);
    }
}
