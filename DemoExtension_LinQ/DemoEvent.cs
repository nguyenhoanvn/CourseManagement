using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExtension_LinQ
{
    public delegate void AddEvent(object sender, Course c);
    internal class DemoEvent
    {
        List<Course> courses = new List<Course>();
        // Kich hoat su kien them course moi
        public event AddEvent AddCourseEvent;
        public void AddCourse(Course c)
        {
            courses.Add(c);
            // Kich hoat su kien
            OnAddCourse(c);
        }
        public void OnAddCourse(Course c)
        {
            AddCourseEvent?.Invoke(this, c);
        }

    }
}
