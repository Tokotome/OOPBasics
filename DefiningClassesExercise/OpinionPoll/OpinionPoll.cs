//Using the Person class, write a program that reads from the console N lines of personal information and then 
//prints all people whose age is more than 30 years, sorted in alphabetical order.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpinionPoll
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public string Name
        {
            get { return this.name; }
        }
        public int Age
        {
            get { return this.age; }
        }
    }

    public class OpinionPoll
    {
        static void Main()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            var people = new List<Person>();
            for (int i = 0; i < numberOfPeople; i++)
            {
                var personInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var person = new Person(personInfo[0], int.Parse(personInfo[1]));

                people.Add(person);
            }

            people
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(p => { Console.WriteLine($"{p.Name} - {p.Age}"); });
        }
    }
}
