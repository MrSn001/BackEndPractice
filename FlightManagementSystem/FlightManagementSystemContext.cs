using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem
{
    public class FlightManagementSystemContext
    {
        public List<Aircraft> aircrafts { get; set; }
        public List<Booking> bookings { get; set; }
        public List<Flight> flights { get; set; }
        public List<Passenger> passengers { get; set; }
        public List<Pilot> pilots { get; set; }
    }
}
