using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceSystem.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int stockQuantity { get; set; }
        public string imageUrl { get; set; }
        public DateTime createdDate { get; set; } = DateTime.Now;
        public bool isAvailable { get; set; } = true;
    }
}
