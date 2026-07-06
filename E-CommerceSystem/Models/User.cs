using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceSystem.Models
{
    public class User
    {
        public int userId { get; set; } // System Generated
        public string username { get; set; } // User Input
        public string email { get; set; }// User Input
        public string passwordHash { get; set; }// System Calculated
        public string fullName { get; set; } // User Input
        public string phoneNumber { get; set; } // User Input
        public string address { get; set; } // User Input
        public DateTime registartionDate { get; set; } // System Calculated
        public bool isActive { get; set; } // Default Value
    }
}
