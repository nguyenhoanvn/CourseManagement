using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExtension_LinQ
{
    static class ExtensionMethod
    {
        public static void Display(this List<Course> courses)
        {
            Console.WriteLine("Course List:");
            foreach(Course course in courses)
            {
                Console.WriteLine(course);
            }
        }
    }
}
