using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        private ICollection<Student> students;

        public Course()
        {
            this.students = new List<Student>();
        }

        public ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public void JoinStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }

            if (this.Students.Contains(student))
            {
                throw new InvalidOperationException("Cannot add the same student twice!");
            }

            if (this.Students.Count >= 30)
            {
                throw new ArgumentException("Students in a course should be less than 30");
            }

            this.Students.Add(student);
        }

        public void LeaveStudent(Student student)
        {
            this.Students.Remove(student);
        }
    }
}
