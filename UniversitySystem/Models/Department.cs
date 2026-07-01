using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace UniversitySystem.Models
{
    [Index(nameof(departmentName), IsUnique = true)]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotNull]
        public int departmentId {  get; set; } // System Generated

        [Required]
        [MaxLength(100)]
        public string departmentName { get; set; } // User Input

        [AllowNull]
        [MaxLength(50)]
        public string building {  get; set; } // User Input
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal budget { get; set; } // User Input

        [AllowNull]
        [ForeignKey("Instructor")]
        public int headInstructorId { get; set; } // Foreign key property
        public Instructor instructor { get; set; } // Navigation property

        public List<Course> courses { get; set; } // Navigation property

    }
}
