using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Models
{
    [Table("User")]
    public partial class User
    {
        [StringLength(20)]
        public string? Username { get; set; }
        [StringLength(20)]
        public string? Password { get; set; }
        [StringLength(20)]
        public string? Role { get; set; }
        [MaxLength(200)]
        public byte[]? PasswordHash { get; set; }
        [MaxLength(200)]
        public byte[]? PasswordSalt { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
