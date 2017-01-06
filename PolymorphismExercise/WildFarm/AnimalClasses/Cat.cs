//Your task is to create a class hierarchy like the picture below.All the classes except Vegetable, 
//Meat, Mouse, Tiger, Cat & Zebra should be abstract. Override method ToString(). 
//Input should be read from the console.Every even line will contain information about the Animal in following format:
//{AnimalType} {AnimalName} {AnimalWeight} {AnimalLivingRegion} [{CatBreed} = Only if its cat]
//On the odd lines you will receive information about the food that you should give to the Animal.The line will consist of 
//FoodType and quantity separated by a whitespace.
//You should build the logic to determine if the animal is going to eat the provided food. The Mouse and Zebra should
//check if the food is a Vegetable. If it is they will eat it. Otherwise you should print a message in the format:
//{ AnimalType}
//are not eating that type of food!
//Cats eat any kind of food, but Tigers accept only Meat.If Vegetable is provided to a tiger message like the one above 
//should be printed on the console.
//Override ToString method to print the information about the animal in format:
//{ AnimalType}
//[{AnimalName}, {CatBreed}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]
//After you read information about the Animal and Food then invoke MakeSound method of the current animal and then 
//feed it.At the end print the whole object and proceed reading information about the next animal/food.The input will 
//continue until you receive “End” for animal information.


namespace AnimalClasses
{
    using System;
    using WildFarm.FoodClasses;

    public class Cat : Felime
    {
        private string breed;

        public Cat(string animalName, string animalType, double animalWeight, string livingRegion, string breed) : base(animalName, animalType, animalWeight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get
            {
                return breed;
            }

            set
            {
                breed = value;
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
        }

        public override void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            string output = $"{this.GetType().Name}[{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";

            return output;
        }
    }
}
