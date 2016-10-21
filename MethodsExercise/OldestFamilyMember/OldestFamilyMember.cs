//Create class Person with fields name and age.Create a class Family. 
//The class should have list of people, method for adding members
//(void AddMember(Person member)) and a method returning the oldest family 
//member(Person GetOldestMember()). Write a program that reads name and age for 
//N people and add them to the family.Then print the name and age of the oldest member.

namespace OldestFamilyMember
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    class OldestFamilyMember
    {
        static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                family.AddMember(new Person(name, age));
            }

            Console.WriteLine($"{family.GetOldestMember().name} {family.GetOldestMember().age}");
        }
    }

    public class Person
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    public class Family
    {
        public IList<Person> members;

        public Family()
        {
            this.members = new List<Person>();
        }

        public void AddMember(Person p)
        {
            this.members.Add(p);
        }

        public Person GetOldestMember()
        {
            return this.members.OrderByDescending(x => x.age).FirstOrDefault();
        }

    }
}
