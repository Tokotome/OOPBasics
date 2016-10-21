using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesExercises
{
    public class Person
    {
        public string Name;
        public int Age;
    }
    


    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.Name = "Gosho";
            person.Age = 20;
            var secondPerson = new Person();
            secondPerson.Name = "Pesho";
            secondPerson.Age = 24;


            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);
        }
    }
}


