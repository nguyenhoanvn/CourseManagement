using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CourseManager;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeSalaryApp
{
    /*
 * - Doc dl tu file:
 * 1 | Hoang | 1000 | manager
 * 2 | Nga | 950 | developer
 * 3 | Duong | 500 | Tester
 * 
 * - Tim employee theo id, name, position (using LinQ)
 * - Tim employee theo: salary theo khoang nhap vao
 * - Tim employee theo getSalaryYear theo khoang nhap vao
 */
    public class Function
    {
        Validation validation = new Validation();
        public List<Employee> LoadEmployeesFromFile()
        {
            string filePath = "data.txt";

            Console.Write("Enter file path (or press Enter for default 'data.txt'): ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                filePath = input;
            }

            Console.WriteLine($"Attempting to load file: {Path.GetFullPath(filePath)}");
            List<Employee> list = new List<Employee>();
            StreamReader sr;
            try
            {
                sr = File.OpenText(filePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
                return list;
            }
            int count = 0;
            using (sr)
            {
                string line;
                
                while ((line = sr.ReadLine()) != null)
                {

                    string[] parts = line.Split('|');
                    count++;

                    if (!validation.ValidateFileLength(parts, 4, count, line)) continue;

                    if (!validation.ValidateFileInteger(parts[0], out int id, count, line, "ID")) continue;

                    if (list.Any(e => e.Id == id))
                    {
                        Console.WriteLine($"\nLine {count}: Duplicate ID: {id} at line {line}\n");
                        continue;
                    }

                    string name = parts[1].Trim();
                    if (!validation.ValidateFileString(name, count, line, "Name")) continue;

                    if (!validation.ValidateFileDoubleNonNegative(parts[2], out double salary, count, line, "Salary")) continue;

                    if (!validation.ValidateFileValueInSet(parts[3], new[] { "manager", "developer", "dev", "tester" }, out string position, count, line, "Position")) continue;

                    list.Add(new Employee(id, name, salary, position));
                }
            }
            Console.WriteLine($"\nSuccessfully loaded {list.Count}/{count} employees from file.\n");
            return list;
        }

        public List<Employee> InputEmployees(List<Employee> employees = null)
        {
            employees = employees ?? new List<Employee>();
            List<Employee> employeeList = employees;
            int count = 1;
            bool addMore = true;
            while (addMore)
            {
                if (count >= 2)
                {
                    Console.Write("Do you want to add more employee? (Y/N): ");
                    string input = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.Write("Input cannot be empty. Please enter Y or N: ");
                        continue;
                    }
                    if (input.ToUpper() == "N")
                    {
                        addMore = false;
                        break;
                    }
                    else if (input.ToUpper() != "Y")
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N.");
                        continue;
                    }
                }
                Employee e = new Employee();
                employeeList.Add(e.Input(employeeList));
                count++;
            }
            return employeeList;
        }

        public void PrintEmployees(List<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
            {
                Console.WriteLine("\nNo employees found.\n");
                return;
            }
            else
            {
                Console.WriteLine($"\n{employees.Count} Employees Found: ");
                foreach (var e in employees)
                {
                    Console.WriteLine(e.ToString());
                }
                Console.WriteLine("");
            }
        }

        public List<Employee> InitializeEmployeeList()
        {
            List<Employee> employees = new List<Employee>();
            while (true)
            {
                Console.Write("Do you want to load by file (Y/N): ");
                string input = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(input))
                {
                    Console.Write("Input cannot be empty. Please enter Y or N: ");
                    continue;
                }
                if (input.ToUpper() == "N")
                {
                    employees = InputEmployees();
                    break;
                }
                else if (input.ToUpper() == "Y")
                {
                    // Load courses from file
                    employees = LoadEmployeesFromFile();
                    if (employees.Count == 0)
                    {
                        Console.WriteLine("No employees found in the file. Please enter employee manually.");
                        employees = InputEmployees();
                    }
                    break;
                }
                else if (input.ToUpper() != "Y")
                {
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                    continue;
                }
            }
            return employees;
        }

        public void Menu(List<Employee> employees)
        {
            while (true)
            {
                Console.WriteLine("1. Add more employee");
                Console.WriteLine("2. Print Employees");
                Console.WriteLine("3. Find by ID");
                Console.WriteLine("4. Find by Name");
                Console.WriteLine("5. Find by Position");
                Console.WriteLine("6. Find by Salary Range");
                Console.WriteLine("7. Find by Yearly Salary Range");
                Console.WriteLine("8. Exit");
                int choice = validation.InputInteger("Choose an option (1-8): ", 1, 8);
                switch (choice)
                {
                    case 1:
                        List<Employee> addingEmployeeList = InputEmployees(employees);
                        int size = employees.Count;
                        employees.AddRange(addingEmployeeList);
                        if (employees.Count > size)
                        {
                            Console.WriteLine("\nEmployees added successfully.\n");
                        }
                        else
                        {
                            Console.WriteLine("\nNo employees were added.\n");
                        }
                        break;
                    case 2:
                        PrintEmployees(employees);
                        break;
                    case 3:
                        int id = validation.InputInteger("Enter Employee ID: ", 1, int.MaxValue);
                        var employeesById = FindByIdByMethod(employees, id);
                        if (employeesById != null)
                        {
                            Console.WriteLine($"\n{employeesById.ToString()}\n");
                        }
                        else
                        {
                            Console.WriteLine($"\nEmployee not found with id: {id}.\n");
                        }
                        break;
                    case 4:
                        string name = validation.InputString("Enter Employee Name: ");
                        var employeesByName = FindByNameByMethod(employees, name);
                        PrintEmployees(employeesByName);
                        break;
                    case 5:
                        string position = validation.InputString("Enter Employee Position: ");
                        var employeesByPosition = FindByPositionByMethod(employees, position);
                        PrintEmployees(employeesByPosition);
                        break;
                    case 6:
                        double minSalary = validation.InputDouble("Enter Minimum Salary: ", 0.0, double.MaxValue);
                        double maxSalary = validation.InputDouble("Enter Maximum Salary: ", minSalary, double.MaxValue);
                        var employeesBySalaryRange = FindBySalaryRangeByMethod(employees, minSalary, maxSalary);
                        PrintEmployees(employeesBySalaryRange);
                        break;
                    case 7:
                        double minYearlySalary = validation.InputDouble("Enter Minimum Yearly Salary: ", 0.0, double.MaxValue);
                        double maxYearlySalary = validation.InputDouble("Enter Maximum Yearly Salary: ", minYearlySalary, double.MaxValue);
                        SalaryDelegate salaryCalc = new Employee().CalculateSalaryYear;
                        var employeesByYearlySalaryRange = FindByYearlySalaryRangeByMethod(employees, minYearlySalary, maxYearlySalary, salaryCalc);
                        PrintEmployees(employeesByYearlySalaryRange);
                        break;
                    case 8:
                        Console.WriteLine("Exiting...");
                        return;
                }
            }
        }

        //Using Methods
        public Employee FindByIdByMethod(List<Employee> employees, int id)
        {
            return employees.First(e => e.Id == id);
        }
        public List<Employee> FindByNameByMethod(List<Employee> employees, string name)
        {
            return employees.Where(e => e.Name.ToLower().Contains(name.ToLower())).ToList();
        }
        public List<Employee> FindByPositionByMethod(List<Employee> employees, string position)
        {
            return employees.Where(e => e.Position.ToLower().Contains(position.ToLower())).ToList();
        }
        public List<Employee> FindBySalaryRangeByMethod(List<Employee> employees, double minSalary, double maxSalary)
        {
            return employees.Where(e => e.Salary >= minSalary && e.Salary <= maxSalary).ToList();
        }
        public List<Employee> FindByYearlySalaryRangeByMethod(List<Employee> employees, double minYearlySalary, double maxYearlySalary, SalaryDelegate salaryCalc)
        {
            return employees.Where(e => salaryCalc(e.Salary, e.Position) >= minYearlySalary && salaryCalc(e.Salary, e.Position) <= maxYearlySalary).ToList();
        }

        //Using Queries
        public Employee FindByIdByQuery(List<Employee> employees, int id)
        {
            var query = from e in employees
                        where e.Id == id
                        select e;
            return query.First();
        }
        public List<Employee> FindByNameByQuery(List<Employee> employees, string name)
        {
            var query = from e in employees
                        where e.Name.ToLower().Contains(name.ToLower())
                        select e;
            return query.ToList();
        }
        public List<Employee> FindByPositionByQuery(List<Employee> employees, string position)
        {
            var query = from e in employees
                        where e.Position.ToLower().Contains(position.ToLower())
                        select e;
            return query.ToList();
        }
        public List<Employee> FindBySalaryRangeByQuery(List<Employee> employees, double minSalary, double maxSalary)
        {
            var query = from e in employees
                        where e.Salary >= minSalary && e.Salary <= maxSalary
                        select e;
            return query.ToList();
        }
        public List<Employee> FindByYearlySalaryRangeByQuery(List<Employee> employees, double minYearlySalary, double maxYearlySalary, SalaryDelegate salaryCalc)
        {
            var query = from e in employees
                        where salaryCalc(e.Salary, e.Position) >= minYearlySalary && salaryCalc(e.Salary, e.Position) <= maxYearlySalary
                        select e;   
            return query.ToList();
        }
    }
}