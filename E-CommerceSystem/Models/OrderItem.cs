using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystem.Models
{
    public class OrderItem
    {
        public int orderItemId { get; set; } // System Generated

        [Required]
        [Range(1, 999)]
        public int quantity { get; set; } // User Input

        [ForeignKey("Order")]
        public int orderId { get; set; } // ForeignKey Property
        public virtual Order Order { get; set; } // Navigation Property


        [ForeignKey("Product")]
        public int productId { get; set; } // ForeignKey Property
        public virtual Product Product { get; set; } // Navigation Property
    }
}
