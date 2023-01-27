using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("Exam")]
    public partial class Exam
    {
        [Key]
        public int Id { get; set; }
        public int Duration { get; set; }
        [Key]
        [StringLength(15)]
        public string CourseCode { get; set; } = null!;

        [ForeignKey("CourseCode")]
        [InverseProperty("Exams")]
        public virtual Course CourseCodeNavigation { get; set; } = null!;
    }
}
