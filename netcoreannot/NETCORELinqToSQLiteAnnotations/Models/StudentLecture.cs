using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NETCORELinqToSQLiteAnnotations.Models
{
    [Table("StudentLecture")]
    public partial class StudentLecture
    {
        [Key]
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long LectureId { get; set; }

        [ForeignKey(nameof(LectureId))]
        [InverseProperty("StudentLectures")]
        public virtual Lecture Lecture { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty("StudentLectures")]
        public virtual Student Student { get; set; }
    }
}
