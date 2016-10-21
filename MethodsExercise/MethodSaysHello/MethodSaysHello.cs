//You will receive the person name as an input.Write a class Person that 
//only has a name and a method.The method should describe a greeting by the 
//person, returning a string "<Person name> says Hello!". Print the result of the method call.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;



public class Person
{
    public string name;

    public Person(string name)
    {
        this.name = name;
    }

    public void Greetings()
    {
        Console.WriteLine(this.name + " says \"Hello\"!");
    }
}

    class Program
    {
        static void Main(string[] args)
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] methods = personType.GetMethods(System.Reflection.BindingFlags.Public | BindingFlags.Instance);

            if (fields.Length != 1 || methods.Length != 5)
            {
                throw new Exception();
            }

            string personName = Console.ReadLine();
            Person person = new Person(personName);

            person.Greetings();
            }
    }

