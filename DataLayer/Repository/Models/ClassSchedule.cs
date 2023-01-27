using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("ClassSchedule")]
    public partial class ClassSchedule
    {
        [Key]
        public int Id { get; set; }
        public int ClassScheduleItemNo { get; set; }
        [StringLength(8)]
        [Unicode(false)]
        public string? ClassroomCode { get; set; }
        public int? TimeSlotId { get; set; }
        public int? CourseOfferedId { get; set; }

        [ForeignKey("ClassroomCode")]
        [InverseProperty("ClassSchedules")]
        public virtual Classroom? ClassroomCodeNavigation { get; set; }
        [ForeignKey("CourseOfferedId")]
        [InverseProperty("ClassSchedules")]
        public virtual CourseOffered? CourseOffered { get; set; }
        [ForeignKey("TimeSlotId")]
        [InverseProperty("ClassSchedules")]
        public virtual TimeSlot? TimeSlot { get; set; }
    }
}
