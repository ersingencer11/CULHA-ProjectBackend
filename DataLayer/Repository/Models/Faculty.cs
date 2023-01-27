using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("Faculty")]
    public partial class Faculty
    {
        public Faculty()
        {
            Departments = new HashSet<Department>();
        }

        [StringLength(128)]
        public string Name { get; set; } = null!;
        [Key]
        public int Id { get; set; }

        [InverseProperty("Faculty")]
        public virtual ICollection<Department> Departments { get; set; }
    }
}
