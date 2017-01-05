namespace Animals
{
    using Animlas.Classes;
    using System;

    class Frog : Animal
    {
        public Frog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Crooooaaaaaaak!");
        }
    }
}