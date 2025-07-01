using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Student(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public virtual void Show()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Address: " + Address);
        }

        public override bool Equals(object obj)
        {
            if (obj is Student student)
            {
                return Id == student.Id && Name == student.Name && Address == student.Address;
            }
            return false;
        }
    }

    public class SEStudent : Student
    {
        public String Major { get; set; }

        public SEStudent(int id, string name, string address, string major) : base(id, name, address)
        {
            Major = major;
        }
        
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Major: " + Major);
        }
    }
}
