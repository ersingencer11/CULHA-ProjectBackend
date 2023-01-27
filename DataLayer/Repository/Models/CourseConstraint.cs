using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("Course_Constraint")]
    public partial class CourseConstraint
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Description { get; set; } = null!;
        [StringLength(15)]
        public string? CourseCode { get; set; }
        public int? TimeSlotId { get; set; }

        [ForeignKey("CourseCode")]
        [InverseProperty("CourseConstraints")]
        public virtual Course? CourseCodeNavigation { get; set; }
        [ForeignKey("TimeSlotId")]
        [InverseProperty("CourseConstraints")]
        public virtual TimeSlot? TimeSlot { get; set; }
    }
}
