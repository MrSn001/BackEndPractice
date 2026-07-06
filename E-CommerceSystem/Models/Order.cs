using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceSystem.Models
{
    public class Order
    {
        public int orderId {  get; set; } // System Generated
        public DateTime orderDate { get; set; } = DateTime.Now // System Calculated
        public decimal totalAmount { get; set; } // System Calculated
        public string status { get; set; } = "Pending" // default value
        public string shippingAddress { get; set; } // User Input
        public string paymentMethod { get; set; } // User Input
    }
}
