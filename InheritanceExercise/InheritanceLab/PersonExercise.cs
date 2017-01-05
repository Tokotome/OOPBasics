//You are asked to model an application for storing data about people.You should be able to have a person and a child. 
//The child is derived of the person. Your task is to model the application. The only constraints are:
//People should not be able to have negative age
//Children should not be able to have age more than 15.

//Person – represents the base class by which all others are implemented
//Child - represents a class which is derived by the Person.



namespace InheritanceLab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class PersonExercise
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                Child child = new Child(name, age);
                Console.WriteLine(child);
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
        }

       
    }

    public class Person
    {
        string name;
        int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length <= 3)
                {
                    throw new ArgumentException("Name’s length should not be less than 3 symbols!");                
                }

                name = value;
            }
        }

        public virtual int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }

                age = value;
            }
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString();
        }

    }

    public class Child : Person
    {
        

        public Child(string name, int age)
            :base(name, age)
        {
        }

        public override string Name
        {
            get
            {
                return base.Name;
            }

            set
            {
                if (value.Length <= 3)
                {
                    throw new ArgumentException( "Name’s length should not be less than 3 symbols!");
                }

                base.Name = value;
            }
        }

        public override int Age
        {
            get
            {
                return base.Age;
            }

            set
            {
                if (value > 15)
                {
                    throw new ArgumentException("Child’s age must be less than 15!");
                }

                base.Age = value;
            }
        }
    }
}
