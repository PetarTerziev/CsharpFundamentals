using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyRoster
{
    class CompanyRoster
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<Employee> employies = new List<Employee>();

            for (int i = 0; i < num; i++)
            {
                string[] employeeInfo = Console.ReadLine().Split().ToArray();
                Employee newEmployee = new Employee(employeeInfo[0], 
                                                    decimal.Parse(employeeInfo[1]), 
                                                    employeeInfo[2]);
                employies.Add(newEmployee);
            }

            string department = Employee.HighestSalaryDepartment(employies);

            Console.WriteLine($"Highest Average Salary: {department}");

            Console.WriteLine(string.Join(Environment.NewLine,employies.OrderByDescending(x => x.Salary)
                                                     .Where(x => x.Department == department)));

        }
        class Employee
        {
            public string Name { get; set; }
            public decimal Salary { get; set; }
            public string Department { get; set; }

            public Employee(string name, decimal salary, string department)
            {
                this.Name = name;
                this.Salary = salary;
                this.Department = department;
            }

            public static string HighestSalaryDepartment(List<Employee> employies) 
            {
                string[] uniqueDepartments = employies.Select(x => x.Department).Distinct().ToArray();
                decimal maxSum = decimal.MinValue;
                int index = -1;

                for (int i = 0; i < uniqueDepartments.Length; i++)
                {
                    decimal sum = 0;

                    foreach (var employee in employies.Where(x => x.Department == uniqueDepartments[i]))
                    {
                        sum += employee.Salary;
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        index = i;
                    }
                }

                return uniqueDepartments[index];
            }
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();

                str.Append(this.Name);
                str.Append($" {this.Salary:f2}");
                
                return str.ToString();
            }
        }
    }
}
