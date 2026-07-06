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
        public int productId { get; set; }

        [Required]
        [MaxLength(150)]
        public string productName { get; set; }

        [MaxLength(1000)]
        public string? description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int stockQuantity { get; set; } = 0;

        [MaxLength(300)]
        public string? imageUrl { get; set; }

        [Required]
        public DateTime createdDate { get; set; } = DateTime.Now;

        public bool isAvailable { get; set; } = true;
    }
}
