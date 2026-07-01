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
        public int departmentId {  get; set; }

        [Required]
        [MaxLength(100)]
        public string departmentName { get; set; }

        [MaybeNull]
        [MaxLength(50)]
        public string building {  get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal budget { get; set; }

    }
}
