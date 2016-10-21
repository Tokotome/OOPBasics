using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeDemo
{
    class Dog
    {
        private string name;
        private int age;
        public Dog()
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get { return this.name; }
            set { name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { age = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dog pesho = new Dog ();

            pesho.Name = "Sharo";
            pesho.Age = 5;
        }
    }
}
