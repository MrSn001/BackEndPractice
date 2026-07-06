using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystem.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; } // System Generated

        [Required]
        [MaxLength(150)]
        public string productName { get; set; } // User Input

        [MaxLength(1000)]
        public string? description { get; set; } // User Input

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal price { get; set; } // User Input

        [Required]
        [Range(0, int.MaxValue)]
        public int stockQuantity { get; set; } = 0; // Default Value

        [MaxLength(300)]
        public string? imageUrl { get; set; } // User Input

        [Required]
        public DateTime createdDate { get; set; }; // System Calculated

        public bool isAvailable { get; set; } = true; // Default Value


        public virtual List<OrderItem> OrderItems { get; set; } // Navigation Property

        [ForeignKey("Category")]
        public int categoryId { get; set; } // ForeignKey Property
        public virtual Category Category { get; set; } // Navigation Property

        public virtual List<Review> Reviews { get; set; } // Navigation Property
    }
}
