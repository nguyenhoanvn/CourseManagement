using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest
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

        public override string ToString()
        {
            return $"{base.ToString()}, Link Meet: {LinkMeet}";
        }
    }
}
