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
        public int studentId {  get; set; } // System Generated

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; } // User Input

        [Required]
        [MaxLength (150)]
        public string email { get; set; } // User Input

        [AllowNull]
        [MaxLength(20)]
        public string phoneNumber { get; set; } // User Input

        [Required]
        public DateTime dateOfBirth { get; set; } // User Input

        [Required]
        [Range(2000,2030)]
        public int enrollmentYear { get; set; } // Calculated

        [DefaultValue(0.0)]
        [Range(0.0,4.0)]
        public decimal gpa { get; set; } // DefaultValue / Calculated

        public virtual List<Enrollment> studentEnrollments { get; set; } // Navigation property
    }
}
