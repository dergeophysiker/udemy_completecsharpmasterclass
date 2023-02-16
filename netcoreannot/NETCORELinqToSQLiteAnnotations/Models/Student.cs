using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NETCORELinqToSQLiteAnnotations.Models
{
    [Table("Student")]
    public partial class Student
    {
        public Student()
        {
            StudentLectures = new HashSet<StudentLecture>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        public long UniversityId { get; set; }

        [ForeignKey(nameof(UniversityId))]
        [InverseProperty("Students")]
        public virtual University University { get; set; }
        [InverseProperty(nameof(StudentLecture.Student))]
        public virtual ICollection<StudentLecture> StudentLectures { get; set; }
    }
}
