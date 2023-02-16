using System;
using System.Collections.Generic;

#nullable disable

namespace NETCORELinqToSQLite.Models
{
    public partial class StudentLecture
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long LectureId { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual Student Student { get; set; }
    }
}
