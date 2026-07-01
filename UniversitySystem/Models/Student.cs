using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace UniversitySystem.Models
{
    [Index(nameof(email), IsUnique = true)]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotNull]
        public int studentId {  get; set; }

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; }

        [Required]
        [MaxLength (150)]
        public string email { get; set; }

        [AllowNull]
        [MaxLength(20)]
        public string phoneNumber { get; set; }

        [Required]
        public DateTime dateOfBirth { get; set; }

        [Required]
        [Range(2000,2030)]
        public int enrollmentYear { get; set; }

        [DefaultValue(0.0)]
        [Range(0.0,4.0)]
        public decimal gpa { get; set; }
    }
}
