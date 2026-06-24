using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Flight
    {
        public int flightId {  get; set; } // System Generated 
        public string flightCode { get; set; } // System Generated 
        public int aircraftId { get; set; } // From Aircraft List
        public int pilotId { get; set; } // From Pilot List
        public string origin {  get; set; } // User Input
        public string destination { get; set; } // User Input
        public string departureDate { get; set; } // User Input
        public string departureTime { get; set; } // User Input
        public string duration { get; set; } // User Input
        public decimal ticketPrice { get; set; } // Calculated
        public int availableSeats { get; set; } // Calculated
        public string status { get; set; } // Default Value
    }
}
