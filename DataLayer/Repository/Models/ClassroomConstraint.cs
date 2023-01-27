using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("Classroom_Constraint")]
    public partial class ClassroomConstraint
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Description { get; set; } = null!;
        [StringLength(8)]
        [Unicode(false)]
        public string? ClassroomCode { get; set; }
        public int? TimeSlotId { get; set; }

        [ForeignKey("ClassroomCode")]
        [InverseProperty("ClassroomConstraints")]
        public virtual Classroom? ClassroomCodeNavigation { get; set; }
        [ForeignKey("TimeSlotId")]
        [InverseProperty("ClassroomConstraints")]
        public virtual TimeSlot? TimeSlot { get; set; }
    }
}
