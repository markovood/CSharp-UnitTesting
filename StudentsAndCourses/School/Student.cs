using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student
    {
        private string name;
        private int id;

        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be NULL or EMPTY!");
                }

                this.name = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("ID", "Id must be within 10000 and 99999");
                }

                this.id = value;
            }
        }
    }
}
