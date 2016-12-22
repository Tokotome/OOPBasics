//Define class Student containing a single field – name.Now Define class StudentGroup with HashSet<String> 
//field that will keep all unique students.You are going to receive user input containing student’s names as 
//single parameter on the line until you receive command “End”. Create new instances of Students class and 
//keep track of all unique names using static counter within the StudentGroup class. Then print the count of unique names.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueStudentNames
{
    class UniqueStudentNames
    {
        static void Main(string[] args)
        {
            string inputName = Console.ReadLine();
            while (inputName != "End")
            {
                
                Student.students.Add(new Student(inputName));
                inputName = Console.ReadLine();
            }
            Console.WriteLine(Student.students.Count());
        }
    }

    public class Student
    {
        public string name;
        public static HashSet<Student> students;
        static Student()
        {
            
            students = new HashSet<Student>();
        }

        public Student(string name)
        {
            this.name = name;
        }

        public override bool Equals(object other)
        {
            return this.GetHashCode().Equals(other.GetHashCode());
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
