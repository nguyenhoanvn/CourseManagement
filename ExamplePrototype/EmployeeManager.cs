using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplePrototype
{
    internal class EmployeeManager
    {
        private Dictionary<string, Employee> prototypes = new Dictionary<string, Employee>();

        public void AddPrototype(string key, Employee prototype)
        {
            prototypes[key] = prototype;
        }

        public Employee GetClone(string key)
        {
            if (prototypes.ContainsKey(key))
            {
                return prototypes[key].Clone();
            }
            throw new ArgumentException("Prototype not found");
        }
    }
}
