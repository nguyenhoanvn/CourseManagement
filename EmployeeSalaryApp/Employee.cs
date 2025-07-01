using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseManager;

namespace EmployeeSalaryApp
{
    public class Employee
    {
        
        Validation validation = new Validation();

        private int id;
        private string name;
        private double salary;
        private string position;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Salary { get => salary; set => salary = value; }
        public string Position { get => position; set => position = value; }

        public Employee()
        {
            Id = 0;
            Name = "";
            Salary = 0.0;
            Position = "";
        }

        public Employee(int id, string name, double salary, string position)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
            this.position = position;
        }

        public Employee Input(List<Employee> employees)
        {
            while (true)
            {
                int id = validation.InputInteger("Enter Id: ", 1, int.MaxValue); ;
                bool exists = false;
                foreach (var e in employees)
                {
                    if (e.Id == id)
                    {
                        Console.WriteLine("ID already exists. Please enter a different ID.");
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    Id = id;
                    break;
                }
            }

            Name = validation.InputString("Enter Name: ");

            Salary = validation.InputDouble("Enter Monthly Salary: ", 0.0, double.MaxValue);

            while (true)
            {
                Position = validation.InputString("Enter Position: ").ToLower();
                if (Position == "manager" || Position == "developer" || Position == "dev" || Position == "tester")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid position. Please enter 'manager', 'developer', 'dev', or 'tester'.");
                    continue;
                }
            }
            return this;
        }

        public override string ToString()
        {
            SalaryDelegate salaryCalc = CalculateSalaryYear;
            return $"Employee ID: {Id}, Name: {Name}, Monthly Salary: {Salary}, Position: {Position}, Yearly Salary: {salaryCalc(Salary, Position)}";

        }

        public double CalculateSalaryYear(double salary, string position)
        {
            switch (position)
            {
                case "manager":
                    return salary * 18;
                case "developer":
                case "dev":
                    return salary * 14;
                case "tester":
                    return salary * 12;
                default:
                    return salary * 12;
            }
        }
    }
}
