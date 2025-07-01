using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplePrototype
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            EmployeeManager manager = new EmployeeManager();

            manager.AddPrototype("developer", new Employee("Nguyen Van A", "admin", new Address("123 Main St", "Hanoi")));
            manager.AddPrototype("tester", new Employee("Lo Van B", "developer", new Address("321 Sub St", "Ho Chi Minh")));

            Employee e1 = manager.GetClone("developer");
            e1.Name = "Hoang";
            e1.Address.City = "Ca Mau";

            Employee e2 = manager.GetClone("tester");

            Console.WriteLine("Cloned Employees:");
            e1.Display();
            e2.Display();

            Console.WriteLine("\nOriginal Prototypes (Unchanged):");
            manager.GetClone("developer").Display();
            manager.GetClone("tester").Display();

        }
    }
}
