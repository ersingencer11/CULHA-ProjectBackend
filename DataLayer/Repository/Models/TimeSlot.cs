using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("TimeSlot")]
    public partial class TimeSlot
    {
        public TimeSlot()
        {
            AcademicianConstraints = new HashSet<AcademicianConstraint>();
            ClassSchedules = new HashSet<ClassSchedule>();
            ClassroomConstraints = new HashSet<ClassroomConstraint>();
            CourseConstraints = new HashSet<CourseConstraint>();
            ExamSchedules = new HashSet<ExamSchedule>();
        }

        public int Slot { get; set; }
        public int Day { get; set; }
        [StringLength(255)]
        public string Description { get; set; } = null!;
        [Key]
        public int Id { get; set; }

        [InverseProperty("TimeSlot")]
        public virtual ICollection<AcademicianConstraint> AcademicianConstraints { get; set; }
        [InverseProperty("TimeSlot")]
        public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }
        [InverseProperty("TimeSlot")]
        public virtual ICollection<ClassroomConstraint> ClassroomConstraints { get; set; }
        [InverseProperty("TimeSlot")]
        public virtual ICollection<CourseConstraint> CourseConstraints { get; set; }
        [InverseProperty("TimeSlot")]
        public virtual ICollection<ExamSchedule> ExamSchedules { get; set; }
    }
}
