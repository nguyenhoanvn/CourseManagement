using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPrototype
{
    internal class Program
    {
        public interface IPrototype<T>
        {
            T Clone();
        }

        public class Address
        {
            public string City { get; set; }
        }

        public class Employee : IPrototype<Employee>
        {
            public string Name { get; set; }
            public Address Address { get; set; }

            public Employee Clone()
            {
                return new Employee
                {
                    Name = this.Name,
                    Address = new Address
                    {
                        City = this.Address.City
                    }
                };
            }
        }
    }
}
