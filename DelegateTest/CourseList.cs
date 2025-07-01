using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest
{
    public class CourseList
    {
        List<Course> courses;
        public CourseList() {
            courses = new List<Course>();
        }
        public void initData()
        {
            courses.Add(new Course(6, "C# Programming", new DateTime(2023, 1, 15)));
            courses.Add(new Course(2, "Java Programming", new DateTime(2023, 2, 20)));
            courses.Add(new Course(5, "Python Programming", new DateTime(2023, 3, 10)));
            courses.Add(new Course(4, "JavaScript Programming", new DateTime(2023, 4, 5)));
            courses.Add(new Course(36, "C++ Programming", new DateTime(2023, 5, 25)));
        }

        public void showCourse()
        {
            foreach (var course in courses)
            {
                Console.WriteLine(course);
            }
        }

        public int TitleCompare(Course c1, Course c2)
        {
            return c1.Title.CompareTo(c2.Title);
        }

        public void SortByTitle()
        {
            //courses.Sort(TitleCompare);
            courses.Sort((c1, c2) => c1.Title.CompareTo(c2.Title)); //Lambda expression
        }
    }
}
