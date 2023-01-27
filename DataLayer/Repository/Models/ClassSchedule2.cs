using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("ClassSchedule2")]
    public partial class ClassSchedule2
    {
        [Key]
        public int Id { get; set; }
        public int ClassScheduleItemNo { get; set; }
        [StringLength(8)]
        [Unicode(false)]
        public string? ClassroomCode { get; set; }
        public int? TimeSlotId { get; set; }
        public int? CourseOfferedId { get; set; }
    }
}
