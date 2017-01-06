namespace WildFarm
{
    using System;
    using FoodClasses;
    using AnimalClasses;
    using global::AnimalClasses;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                var parameters = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string animalType = parameters[0];
                string animalName = parameters[1];
                double animalWeight = double.Parse(parameters[2]);
                string region = parameters[3];
                string breed = "";

                if (animalType == "Cat")
                {
                    breed = parameters[4];
                }

                Mammal animal;
                if (animalType == "Mouse")
                {
                    animal = new Mouse(animalName, animalType, animalWeight, region);
                }
                else if (animalType == "Tiger")
                {
                    animal = new Tiger(animalName, animalType, animalWeight, region);
                }
                else if (animalType == "Cat")
                {
                    animal = new Cat(animalName, animalType, animalWeight, region, breed);
                }
                else
                {
                    animal = new Zebra(animalName, animalType, animalWeight, region);
                }

                input = Console.ReadLine();
                parameters = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string foodType = parameters[0];
                int foodQuantity = int.Parse(parameters[1]);

                Food food;
                if (foodType == "Vegetable")
                {
                    food = new Vegetable(foodQuantity);
                }
                else
                {
                    food = new Meat(foodQuantity);
                }


                animal.MakeSound();
                animal.Eat(food);

                Console.WriteLine(animal);

                input = Console.ReadLine();
            }
        }
    }
}
