using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NETCORELinqToSQLiteAnnotations.Models
{
    [Table("University")]
    public partial class University
    {
        public University()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }

        [InverseProperty(nameof(Student.University))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
