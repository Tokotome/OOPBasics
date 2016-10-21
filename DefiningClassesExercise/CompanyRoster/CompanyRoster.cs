//Define a class Employee that holds the following information: name, salary, position, department, 
//email and age.The name, salary, position and department are mandatory while the rest are optional.
//Your task is to write a program which takes N lines of employees from the console and calculates the 
//department with the highest average salary and prints for each employee in that department his name, 
//salary, email and age – sorted by salary in descending order. If an employee doesn’t have an email – 
//in place of that field you should print “n/a” instead, if he doesn’t have an age – print “-1” instead.
//The salary should be printed to two decimal places after the seperator.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRoster
{
    public class Employee
    {
        public Employee(string name,
            decimal salary,
            string position,
            string department)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.email = "n/a";
            this.age = -1;
        }
        public string name;
        public decimal salary;
        public string position;
        public string department;
        public string email;
        public int age;
    }
    class CompanyRoster
    {
        static void Main(string[] args)
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());
            var employees = new List<Employee>();

            for (int i = 0; i < numberOfEmployees; i++)
            {
                var employeeInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var employee = new Employee(
                    employeeInfo[0],
                    decimal.Parse(employeeInfo[1]),
                    employeeInfo[2],
                    employeeInfo[3]);

                if (employeeInfo.Length > 4)
                {
                    var ageOrEmail = employeeInfo[4];
                    if (ageOrEmail.Contains("@"))
                    {
                        employee.email = ageOrEmail;
                    }
                    else
                    {
                        employee.age = int.Parse(ageOrEmail);
                    }
                }
                if (employeeInfo.Length > 5)
                {
                    employee.age = int.Parse(employeeInfo[5]);
                }
                employees.Add(employee);
            }
            var result = employees
                .GroupBy(e => e.department)
                .Select(e => new
                {
                    Department = e.Key,
                    AverageSalary = e.Average(emp => emp.salary),
                    Employees = e.OrderByDescending(emp => emp.salary)
                })
                .OrderByDescending(dep => dep.AverageSalary)
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {result.Department}");
            foreach (var employee in result.Employees)
            {
                Console.WriteLine($"{employee.name} {employee.salary:F2} {employee.email} {employee.age}");
            }
        }
    }
}
