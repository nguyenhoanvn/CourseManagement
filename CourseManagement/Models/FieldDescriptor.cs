using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Models
{
    public class FieldDescriptor
    {
        public string Label { get; set; }
        public string PropertyName { get; set; }
        public Type DataType { get; set; }
    }

}
