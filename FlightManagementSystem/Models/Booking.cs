using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Booking
    {
        public int bookingId { get; set; } // Auto Generated 
        public int passengerId { get; set; } // From Passenger List
        public int flightId { get; set; } // From Flight List
        public string seatNumber { get; set; } // System Generated
        public string bookingDate { get; set; } // Default Value
        public decimal totalPrice { get; set; } // Calculated From Flight
        public string status { get; set; } // Default Value
    }
}
