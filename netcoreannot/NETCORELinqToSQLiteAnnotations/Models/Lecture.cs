using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NETCORELinqToSQLiteAnnotations.Models
{
    [Table("Lecture")]
    public partial class Lecture
    {
        public Lecture()
        {
            StudentLectures = new HashSet<StudentLecture>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }

        [InverseProperty(nameof(StudentLecture.Lecture))]
        public virtual ICollection<StudentLecture> StudentLectures { get; set; }
    }
}
