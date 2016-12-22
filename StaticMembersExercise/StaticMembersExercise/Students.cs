//Define class Student. Add string field for a student’s name that you are going to receive 
//as a console input.Then add a static Integer field to keep track of how many students’ instances 
//are created.Initialize the static field with 0 (zero) and increment in the constructor.When you receive 
//command “End” stop reading more students names and print their total count on the console.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMembersExercise
{
    class Students
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            while (name!= "End")
            {
                var student = new Student(name);
                name = Console.ReadLine();
            }
            Console.WriteLine(Student.numberOfStudents);
        }
    }

    public class Student
    {
        public string name;
        public static int numberOfStudents;
        public Student(string name)
        {
            this.name = name;
            numberOfStudents++;
        }
    } 
}
