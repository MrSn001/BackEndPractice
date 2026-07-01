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
        public int enrollmentId; // System Generated 

        [Required]
        public DateTime enrollmentDate; //Calculated

        [MaybeNull]
        [MaxLength(2)]
        public string finalGrade; // Default Value/ Calculated

        [Required]
        [MaxLength(20)]
        [DefaultValue("In Progress")]
        public string status; // Default Value/ Calculated
    }
}
