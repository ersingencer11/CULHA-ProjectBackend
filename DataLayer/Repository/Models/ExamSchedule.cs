using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("ExamSchedule")]
    public partial class ExamSchedule
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int ItemNo { get; set; }
        [StringLength(255)]
        public string CourseCode { get; set; } = null!;
        [StringLength(255)]
        public string ClassroomCode { get; set; } = null!;
        [StringLength(255)]
        public string Supervisor { get; set; } = null!;
        [StringLength(1)]
        [Unicode(false)]
        public string Section { get; set; } = null!;
        public int? TimeSlotId { get; set; }

        [ForeignKey("TimeSlotId")]
        [InverseProperty("ExamSchedules")]
        public virtual TimeSlot? TimeSlot { get; set; }
    }
}
