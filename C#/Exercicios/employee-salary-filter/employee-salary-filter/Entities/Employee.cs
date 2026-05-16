using System;
using System.Collections.Generic;
using System.Text;

namespace employee_salary_filter.Entities
{
    class Employee
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public double Salary { get; set; }

        public Employee()
        { 
        }

        public Employee(string name, string email, double salary)
        {
            Name = name;
            Email = email;
            Salary = salary;
        }
    }
}
