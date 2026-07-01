using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;

namespace UniversitySystem.Models
{
    [Index(nameof(email), IsUnique = true)]
    public class Instructor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotNull]
        public int instructorId { get; set; } // Auto Generated 

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; } // User Input

        [Required]
        [MaxLength(150)]
        public string email { get; set; } // User Input

        [MaybeNull]
        [MaxLength(20)]
        public string officeNumber { get; set; } // User Input

        [Required]
        public DateTime hireDate { get; set; } // Calculated

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal salary { get; set; } // User Input

        [Required]
        [MaxLength(50)]
        [EnumDataType(typeof(AcademicTitle))]
        public AcademicTitle academicTitle { get; set; } // User Input

    }
}
