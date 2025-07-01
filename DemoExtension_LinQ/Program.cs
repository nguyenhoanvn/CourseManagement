using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExtension_LinQ
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Demo phương thức mở rộng cho List<Course>
            demoExtensionMethod();
            // Demo phương thức mở rộng cho Course
            demoCourseExtension();
            Console.ReadKey();
        }

        public static void demoExtensionMethod()
        {
            List<Course> courses = new List<Course>();
            {
                new Course(1, "C# Programming", new DateTime(2023, 10, 1));
                new Course(2, "Java Programming", new DateTime(2023, 11, 1));
                new Course(3, "Python Programming", new DateTime(2023, 12, 1));
                new Course(4, "JavaScript Programming", new DateTime(2023, 10, 15));
            };
            // Gọi phương thức mở rộng để hiển thị danh sách khóa học
            courses.Display();
        }

        public static void demoCourseExtension()
        {
            Course course = new Course(1, "C# Programming", new DateTime(2023, 10, 1));
            // Gọi phương thức mở rộng để hiển thị thông tin khóa học
            course.display(3);
        }
        public static void demoUsingEvent()
        {
            DemoEvent demoEvent = new DemoEvent();
            demoEvent.AddCourseEvent += OnAdd;
            Course c = new Course(1, "C# Programming", new DateTime(2023, 10, 1));
            demoEvent.AddCourse(c);
        }

        public static void OnAdd(object sender, Course c)
        {
            Console.WriteLine($"A new course has been added: {c.Title} on {c.StartDate.ToString("dd/MM/yyyy")}.");
        }
    }

}
