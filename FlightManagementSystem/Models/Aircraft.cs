using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    internal class Aircraft
    {
        public int aircraftId {  get; set; } // System Generated
        public string model {  get; set; } // User Input
        public int totalSeats { get; set; } // User Input
        public bool isOperational { get; set; } // Default Value
    }
}
