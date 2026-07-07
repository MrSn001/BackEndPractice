using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystem.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId {  get; set; } // System Generated

        [Required]
        [ForeignKey("User")]
        public int userId { get; set; } // Foreign key property 
        [Required]
        public DateTime orderDate { get; set; } = DateTime.Now; // System Calculated

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal totalAmount { get; set; } // System Calculated

        [Required]
        [MaxLength(30)]
        public string status { get; set; } = "Pending"; // default value

        [Required]
        [MaxLength(300)]
        public string shippingAddress { get; set; } // User Input

        [Required]
        [MaxLength(50)]
        public string paymentMethod { get; set; } // User Input

        public User User { get; set; } // Navigation property
        public virtual List<OrderItem> OrderItems { get; set; } // Navigation Property
    }
}
