using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Models
{
    public class StudentAttendanceViewModel
    {
        public int RollCallBookId { get; set; }
        public int StudentId { get; set; }
        public string Roll { get; set; }
        public string FullName { get; set; }
        public bool? IsAbsent { get; set; }
        public string Comment { get; set; }
    }
}
