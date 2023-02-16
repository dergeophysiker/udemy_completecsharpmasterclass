using System;
using System.Collections.Generic;

#nullable disable

namespace NETCORELinqToSQLite.Models
{
    public partial class Lecture
    {
        public Lecture()
        {
            StudentLectures = new HashSet<StudentLecture>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentLecture> StudentLectures { get; set; }
    }
}
