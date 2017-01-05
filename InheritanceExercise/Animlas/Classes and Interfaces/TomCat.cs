namespace Animals
{
    using Animlas.Classes;
    using Animlas.Classes_and_Interfaces;
    using System;

    class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, age, Gender.Male)
        {
        }
    }
}