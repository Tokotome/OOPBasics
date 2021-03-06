﻿//You should first print the info about the student following a single blank line and the info about the worker in the 
//given formats:
//•	Print the student info in the following format: 
//	First Name: {student's first name}
//	Last Name: {student's last name}
//	Faculty number: {student's faculty number}

//•	Print the worker info in the following format:
//	First Name: {worker's first name}
//Last Name: {worker's second name}
//Week Salary: {worker's salary}
//Hours per day: {worker's working hours}
//Salary per hour: {worker's salary per hour}
//Print exactly two digits after every double value's decimal separator (e.g. 10.00)





namespace Mankind
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public abstract class Person
    {
        private string firstName;
        private string secondName;

        public Person(string firstName, string secondName)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
        }

        public virtual string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }

                this.firstName = value;
            }
        }

        public string SecondName
        {
            get
            {
                return this.secondName;
            }

            set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }

                this.secondName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format(
                "First Name: {0}", this.FirstName));
            result.AppendLine(string.Format(
                "Last Name: {0}", this.SecondName));

            return result.ToString();
        }
    }

    public class Student : Person
    {
        private string facultyNumber;

        public Student(string firstName, string secondName, string facultyNumber)
            : base(firstName, secondName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                if (IsNumberInvalid(value))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public override string FirstName
        {
            set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }

                base.FirstName = value;
            }
        }

        private bool IsNumberInvalid(string value)
        {
            bool isNumberInvalid = false;

            string numberPattern = @"^([0-9a-zA-Z]{5,10})$";

            var regex = new Regex(numberPattern);

            var match = regex.Match(value);

            if (match.Success)
            {
                return isNumberInvalid;
            }

            return !isNumberInvalid;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());

            result.AppendLine(string.Format(
                "Faculty number: {0}", this.FacultyNumber));

            return result.ToString().Trim();
        }
    }

    public class Worker : Person
    {
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string secondName, double weekSalary, double workHoursPerDay)
            : base(firstName, secondName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value > 12 || value < 1)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        public double CalcSalary()
        {
            double sal = this.weekSalary / 5 / this.WorkHoursPerDay;

            return sal;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());

            result.AppendLine(string.Format(
                "Week Salary: {0:F2}", this.WeekSalary));
            result.AppendLine(string.Format(
                "Hours per day: {0:F2}", this.WorkHoursPerDay));
            result.AppendLine(string.Format(
                "Salary per hour: {0:F2}", this.CalcSalary()));

            return result.ToString().Trim();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] parametersStudent = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder result = new StringBuilder();

            try
            {
                var student = new Student(parametersStudent[0], parametersStudent[1], parametersStudent[2]);
                result.AppendLine(student.ToString());
                result.AppendLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

                Environment.Exit(0);
            }

            string[] parametersWorker = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var worker = new Worker(parametersWorker[0], parametersWorker[1], double.Parse(parametersWorker[2]), double.Parse(parametersWorker[3]));
                result.AppendLine(worker.ToString());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

                Environment.Exit(0);
            }

            Console.WriteLine(result.ToString());
        }
    }
}
