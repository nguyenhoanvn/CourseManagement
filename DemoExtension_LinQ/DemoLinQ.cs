using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExtension_LinQ
{
    internal class DemoLinQ
    {
        List<Course> courses = new List<Course>
        {
            new Course(1, "C# Programming", new DateTime(2023, 10, 1)),
            new Course(2, "Java Programming", new DateTime(2023, 11, 1)),
            new Course(3, "Python Programming", new DateTime(2023, 12, 1)),
            new Course(4, "JavaScript Programming", new DateTime(2023, 10, 15)),
            new Course(5, "C++ Programming", new DateTime(2023, 9, 20)),
            new Course(6, "Ruby Programming", new DateTime(2023, 10, 5)),
            new Course(7, "PHP Programming", new DateTime(2023, 11, 10)),
        };
        public List<Course> GetAllCourses()
        {
            return courses;
        }
        public Course GetCourseByIdUsingMethod(int id)
        {
            return courses.First(c => c.Id == id);
        }

        public List<Course> GetCourseByTitleUsingMethod(string pattern)
        {
            return courses.Where(c => c.Title.Contains(pattern)).ToList();
        }

        /*public List<Course> GetCourseByStartDateUsingMethod(DateTime startDate, DateTime endDate)
        {
            return courses.Where(c => c.StartDate >= startDate && c.StartDate <= endDate).ToList();
        }*/
        public void GetCourseByStartDateUsingMethod(DateTime startDate, DateTime endDate)
        {

            var select = courses.Where(c => c.StartDate >= startDate && c.StartDate <= endDate)
                .Select(c => (c.Title, c.StartDate));
            foreach (var course in select)
            {
                Console.WriteLine($"Title: {course.Title}, Start Date: {course.StartDate.ToString("dd/MM/yyyy")}");
            }
        }

        public Course GetCourseByIdUsingQuery(int id)
        {
            var query = from c in courses
                        where c.Id == id
                        select c;
            return query.First();
        }

        public List<Course> GetCourseByTitleUsingQuery(string pattern)
        {
            var query = from c in courses
                        where c.Title.Contains(pattern)
                        select c;
            return query.ToList();
        }

        public void GetCourseByStartDateUsingQuery(DateTime startDate, DateTime endDate)
        {
            var query = from c in courses
                        where c.StartDate >= startDate && c.StartDate <= endDate
                        select new {newTitle = c.Title, Date = c.StartDate};
            foreach (var course in query)
            {
                Console.WriteLine($"Title: {course.newTitle}, Start Date: {course.Date.ToString("dd/MM/yyyy")}");
            }
        }
}
