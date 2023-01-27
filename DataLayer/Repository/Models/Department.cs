using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("Department")]
    public partial class Department
    {
        public Department()
        {
            CourseOffereds = new HashSet<CourseOffered>();
            CourseCodes = new HashSet<Course>();
        }

        [StringLength(255)]
        public string Name { get; set; } = null!;
        public int? FacultyId { get; set; }
        public int? DepartmentChair { get; set; }
        [StringLength(128)]
        public string? Email { get; set; }
        [Key]
        [StringLength(8)]
        public string DepartmentCode { get; set; } = null!;

        [ForeignKey("DepartmentChair")]
        [InverseProperty("Department")]
        public virtual Academician? DepartmentChairNavigation { get; set; }
        [ForeignKey("FacultyId")]
        [InverseProperty("Departments")]
        public virtual Faculty? Faculty { get; set; }
        [InverseProperty("DepartmentCodeNavigation")]
        public virtual ICollection<CourseOffered> CourseOffereds { get; set; }

        [ForeignKey("DepartmentCode")]
        [InverseProperty("DepartmentCodes")]
        public virtual ICollection<Course> CourseCodes { get; set; }
    }
}
