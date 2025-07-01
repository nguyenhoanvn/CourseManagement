using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Models
{
    public class AddEditViewModel
    {
        public object Entity { get; set; }
        public List<FieldDescriptor> Fields { get; set; }
    }
}
