using Animlas.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animlas.Classes_and_Interfaces
{
    abstract class Cat : Animal
    {
        public Cat(string name, int age, Gender gender)
                   : base(name, age, gender)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Miaow!");
        }
    }
}
