using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("Academician")]
    public partial class Academician
    {
        public Academician()
        {
            AcademicianConstraints = new HashSet<AcademicianConstraint>();
            CourseOffereds = new HashSet<CourseOffered>();
        }

        [Key]
        public int Id { get; set; }
        public bool IsAssistant { get; set; }
        [StringLength(128)]
        public string FirstName { get; set; } = null!;
        [StringLength(128)]
        public string LastName { get; set; } = null!;
        [StringLength(128)]
        public string Email { get; set; } = null!;
        [StringLength(128)]
        public string Title { get; set; } = null!;
        [StringLength(11)]
        public string IdentityNo { get; set; } = null!;

        [InverseProperty("DepartmentChairNavigation")]
        public virtual Department? Department { get; set; }
        [InverseProperty("Academician")]
        public virtual ICollection<AcademicianConstraint> AcademicianConstraints { get; set; }
        [InverseProperty("Academician")]
        public virtual ICollection<CourseOffered> CourseOffereds { get; set; }
    }
}
