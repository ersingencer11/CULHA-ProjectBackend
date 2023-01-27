using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("EducationArea")]
    public partial class EducationArea
    {
        [Key]
        public int Id { get; set; }
        [StringLength(8)]
        [Unicode(false)]
        public string ClassroomCode { get; set; } = null!;
        [StringLength(15)]
        public string CourseCode { get; set; } = null!;

        [ForeignKey("ClassroomCode")]
        [InverseProperty("EducationAreas")]
        public virtual Classroom ClassroomCodeNavigation { get; set; } = null!;
        [ForeignKey("CourseCode")]
        [InverseProperty("EducationAreas")]
        public virtual Course CourseCodeNavigation { get; set; } = null!;
    }
}
