using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("CourseOffered")]
    [Index("CourseCode", "Term", "Section", "DepartmentCode", "AcademicianId", Name = "pk_course_offered", IsUnique = true)]
    public partial class CourseOffered
    {
        public CourseOffered()
        {
            ClassSchedules = new HashSet<ClassSchedule>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Term { get; set; } = null!;
        [Column("COYear")]
        public int Coyear { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string Section { get; set; } = null!;
        public bool IsOnline { get; set; }
        public int StudentCount { get; set; }
        [Required]
        public bool? IsAssigned { get; set; }
        public int SemesterCount { get; set; }
        [StringLength(15)]
        public string? CourseCode { get; set; }
        [StringLength(8)]
        public string? DepartmentCode { get; set; }
        public int? AcademicianId { get; set; }

        [ForeignKey("AcademicianId")]
        [InverseProperty("CourseOffereds")]
        public virtual Academician? Academician { get; set; }
        [ForeignKey("CourseCode")]
        [InverseProperty("CourseOffereds")]
        public virtual Course? CourseCodeNavigation { get; set; }
        [ForeignKey("DepartmentCode")]
        [InverseProperty("CourseOffereds")]
        public virtual Department? DepartmentCodeNavigation { get; set; }
        [InverseProperty("CourseOffered")]
        public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }
    }
}
