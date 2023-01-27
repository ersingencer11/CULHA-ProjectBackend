using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("Course")]
    public partial class Course
    {
        public Course()
        {
            CourseConstraints = new HashSet<CourseConstraint>();
            CourseOffereds = new HashSet<CourseOffered>();
            EducationAreas = new HashSet<EducationArea>();
            Exams = new HashSet<Exam>();
            DepartmentCodes = new HashSet<Department>();
        }

        [Key]
        [StringLength(15)]
        public string CourseCode { get; set; } = null!;
        [StringLength(128)]
        public string CourseName { get; set; } = null!;
        public int Quota { get; set; }
        [Required]
        public bool? CourseType { get; set; }
        public double PracticalHour { get; set; }
        public double TheoreticalHour { get; set; }
        public double Credit { get; set; }
        [Column("ECTS")]
        public double Ects { get; set; }

        [InverseProperty("CourseCodeNavigation")]
        public virtual ICollection<CourseConstraint> CourseConstraints { get; set; }
        [InverseProperty("CourseCodeNavigation")]
        public virtual ICollection<CourseOffered> CourseOffereds { get; set; }
        [InverseProperty("CourseCodeNavigation")]
        public virtual ICollection<EducationArea> EducationAreas { get; set; }
        [InverseProperty("CourseCodeNavigation")]
        public virtual ICollection<Exam> Exams { get; set; }

        [ForeignKey("CourseCode")]
        [InverseProperty("CourseCodes")]
        public virtual ICollection<Department> DepartmentCodes { get; set; }
    }
}
