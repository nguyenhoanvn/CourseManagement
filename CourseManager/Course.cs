using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }

        public Course() { }
        public Course(int id, string title, DateTime startDate)
        {
            Id = id;
            Title = title;
            StartDate = startDate;
        }

        Validation validation = new Validation();

        public virtual Course Input(int id)
        {
            Id = id;
            Title = validation.InputString("Enter Course Title: ");
            StartDate = validation.InputDate("Enter Course Start Date (dd/MM/yyyy): ", DateTime.MinValue);
            return this;
        }

        public virtual Course AInput(List<Course> courseList)
        {
            while (true)
            {
                int id = validation.InputInteger("Enter Course ID: ", 1, int.MaxValue);
                bool exists = false;
                foreach (var c in courseList)
                {
                    if (c.Id == id)
                    {
                        Console.WriteLine("ID already exists. Please enter a different ID.");
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    Id = id;
                    break;
                }
            }          
            Title = validation.InputString("Enter Course Title: ");
            StartDate = validation.InputDate("Enter Course Start Date (dd/MM/yyyy): ", DateTime.MinValue);
            return this;
        }
        public override string ToString()
        {
            return $"Course ID: {Id}, Title: {Title}, Start Date: {StartDate.ToString("dd/MM/yyyy")}";
        }
    }

    public class OnlineCourse : Course
    {
        public string LinkMeet { get; set; }
        public OnlineCourse() { }
        public OnlineCourse(int id, string title, DateTime startDate, string linkMeet) : base(id, title, startDate)
        {
            LinkMeet = linkMeet;
        }
        Validation validation = new Validation();

        public override OnlineCourse Input(int id)
        {
            base.Input(id);
            LinkMeet = validation.InputString("Enter Course Link Meet: ");
            Console.WriteLine($"Online Course added successfully with information: {Id} - {Title} - {StartDate.ToString("dd/MM/yyyy")} - {LinkMeet}");
            return this;
        }

        public override Course AInput(List<Course> courseList)
        {
            base.AInput(courseList);
            LinkMeet = validation.InputString("Enter Course Link Meet: ");
            Console.WriteLine($"Online Course added successfully with information: {Id} - {Title} - {StartDate.ToString("dd/MM/yyyy")} - {LinkMeet}");
            return this;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Link Meet: {LinkMeet}";
        }
    }
}
