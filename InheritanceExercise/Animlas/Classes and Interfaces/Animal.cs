


namespace Animlas.Classes
{
    using Classes_and_Interfaces;
    using System;

    public enum Gender
    {
        Male,
        Female
    }
    public abstract class Animal : ISound

    {
        public Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        private string name;
        private int age;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be a negative number");
                }
                this.age = value;
            }
        }

        public Gender Gender { get; set; }

        public abstract void MakeSound();
        
    }
}
