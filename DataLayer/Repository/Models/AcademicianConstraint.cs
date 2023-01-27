using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("Academician_Constraint")]
    public partial class AcademicianConstraint
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Description { get; set; } = null!;
        public int? AcademicianId { get; set; }
        public int? TimeSlotId { get; set; }

        [ForeignKey("AcademicianId")]
        [InverseProperty("AcademicianConstraints")]
        public virtual Academician? Academician { get; set; }
        [ForeignKey("TimeSlotId")]
        [InverseProperty("AcademicianConstraints")]
        public virtual TimeSlot? TimeSlot { get; set; }
    }
}
