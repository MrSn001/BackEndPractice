using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_CommerceSystem.Models
{
    public class OrderItem
    {
        public int orderItemId { get; set; } // System Generated

        [Required]
        [Range(1, 999)]
        public int quantity { get; set; } // User Input
    }
}
