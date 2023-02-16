using System;
using System.Collections.Generic;

#nullable disable

namespace NETCORELinqToSQLite.Models
{
    public partial class University
    {
        public University()
        {
            Students = new HashSet<Student>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
