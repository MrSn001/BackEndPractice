using FlightManagementSystem.Models;
using System.Security.Cryptography.X509Certificates;

namespace FlightManagementSystem
{
    internal class Program
    {
        public static FlightManagementSystemContext context = new FlightManagementSystemContext
        {
            Aircrafts = new List<Aircraft>(),
            Bookings = new List<Booking>(),
            Flights = new List<Flight>(),
            Passengers = new List<Passenger>(),
            Pilots = new List<Pilot>()
        };
        static void Main(string[] args)
        {
           
        }
    }
}
