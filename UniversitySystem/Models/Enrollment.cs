using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace UniversitySystem.Models
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotNull]
        public int enrollmentId { get; set; } // System Generated 

        [ForeignKey("Student")]
        [NotNull]
        public int studentId {  get; set; } // Foreign key property

        [ForeignKey("Course")]
        [NotNull]
        public int courseId { get; set; } // Foreign key property

        [Required]
        public DateTime enrollmentDate { get; set; } //Calculated

        [AllowNull]
        [MaxLength(2)]
        public string finalGrade { get; set; } // Default Value/ Calculated

        [Required]
        [MaxLength(20)]
        [DefaultValue("In Progress")]
        public string status { get; set; } // Default Value/ Calculated
    }
}
