using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("Campus")]
    public partial class Campus
    {
        public Campus()
        {
            Classrooms = new HashSet<Classroom>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(128)]
        public string Name { get; set; } = null!;

        [InverseProperty("Campus")]
        public virtual ICollection<Classroom> Classrooms { get; set; }
    }
}
