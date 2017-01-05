namespace Animals
{
    using Animlas.Classes;
    using System;

    class Dog : Animal
    {
        public Dog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Bark!");
        }
    }
}
