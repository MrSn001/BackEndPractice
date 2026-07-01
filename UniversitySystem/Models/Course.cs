using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace UniversitySystem.Models
{
    [Index(nameof(courseCode),IsUnique = true)]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [NotNull]
        public int courseId {  get; set; }

        [Required]
        [MaxLength(10)]
        public string courseCode { get; set; }

        [Required]
        [MaxLength(150)]
        public string courseTitle { get; set; }

        [Required]
        [Range(1, 6)]
        public int creditHours { get; set; }

        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^(Fall|Spring|Summer|Winter)\s\d{4}$")]
        public string semesterOffered { get; set; }
    }
}
