using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class School
    {
        public School()
        {
            this.Students = new List<Student>();
            this.Courses = new List<Course>();
        }

        public ICollection<Student> Students { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
