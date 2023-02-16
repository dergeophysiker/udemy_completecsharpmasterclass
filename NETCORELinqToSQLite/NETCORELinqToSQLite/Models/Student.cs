using System;
using System.Collections.Generic;

#nullable disable

namespace NETCORELinqToSQLite.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentLectures = new HashSet<StudentLecture>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public long UniversityId { get; set; }

        public virtual University University { get; set; }
        public virtual ICollection<StudentLecture> StudentLectures { get; set; }
    }
}
