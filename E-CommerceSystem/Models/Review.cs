using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystem.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reviewId { get; set; }// System Generated 

        [Required]
        [Range(1,5)]
        public int rating { get; set; } // User Input

        [MaxLength(1000)]
        public string? comment { get; set; } // User Input

        [Required]
        public DateTime reviewDate { get; set; } = DateTime.Now; // Default value

        [ForeignKey("Product")]
        public int productId { get; set; } // ForeignKey Property
        public virtual Product Product { get; set; } // Navigation Property

        [ForeignKey("User")]
        public int userId { get; set; } // ForeignKey Property
        public virtual User User { get; set; } // Navigation Property
    }
}
