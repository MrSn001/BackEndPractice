using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    internal class Pilot
    {
        public int pilotId { get; set; } // System Generated 
        public string pilotName { get; set; } // User Input
        public string pilotPhone { get; set; } // User Input
        public string licenseNumber { get; set; } // User Input 
        public int flightHours { get; set; } // User Input
        public bool isAvailable { get; set; } // Default Value
    }
}
