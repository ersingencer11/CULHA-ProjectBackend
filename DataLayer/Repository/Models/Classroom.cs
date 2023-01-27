using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("Classroom")]
    public partial class Classroom
    {
        public Classroom()
        {
            ClassSchedules = new HashSet<ClassSchedule>();
            ClassroomConstraints = new HashSet<ClassroomConstraint>();
            EducationAreas = new HashSet<EducationArea>();
        }

        public int ClassCapacity { get; set; }
        public bool IsEnabled { get; set; }
        public int ExamCapacity { get; set; }
        public int? CampusId { get; set; }
        [Key]
        [StringLength(8)]
        [Unicode(false)]
        public string ClassroomCode { get; set; } = null!;
        [StringLength(128)]
        public string Building { get; set; } = null!;
        [StringLength(32)]
        public string Type { get; set; } = null!;

        [ForeignKey("CampusId")]
        [InverseProperty("Classrooms")]
        public virtual Campus? Campus { get; set; }
        [InverseProperty("ClassroomCodeNavigation")]
        public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }
        [InverseProperty("ClassroomCodeNavigation")]
        public virtual ICollection<ClassroomConstraint> ClassroomConstraints { get; set; }
        [InverseProperty("ClassroomCodeNavigation")]
        public virtual ICollection<EducationArea> EducationAreas { get; set; }
    }
}
