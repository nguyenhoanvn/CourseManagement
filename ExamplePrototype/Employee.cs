using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplePrototype
{
    internal class Employee : IPrototype<Employee>
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public Address Address { get; set; }
        public Employee(string name, string role, Address address)
        {
            Name = name;
            Role = role;
            Address = address;
        }
        public Employee Clone()
        {
            return new Employee(Name, Role, Address.Clone());
        }
        public void Display()
        {
            Console.WriteLine($"Employee: {Name}, Role: {Role}, Address: {Address.Street}, {Address.City}");
        }
    }
}
