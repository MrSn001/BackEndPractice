using FlightManagementSystem.Models;
using System.Security.Cryptography.X509Certificates;

namespace FlightManagementSystem
{
    internal class Program
    {
        public static bool flag = true;
        public static int choice;

        public static FlightManagementSystemContext context = new FlightManagementSystemContext
        {
            Aircrafts = new List<Aircraft>(),
            Bookings = new List<Booking>(),
            Flights = new List<Flight>(),
            Passengers = new List<Passenger>(),
            Pilots = new List<Pilot>()
        };

        public static void PrintMainMenu()
        {
            Console.WriteLine("""
                =============================================================
                            Welcome To Our Flight Managment System
                =============================================================
                1. Register a Passenger
                2. Add an Aircraft
                3. Register a Pilot
                4. View All Flights
                5. Schedule a Flight
                6. Book a Flight
                7. Cancel a Booking 
                8. Depart a Flight
                9. Cancel a Flight
                10. Passenger Booking History
                11. Flight Revenue & Load Factor Report
                =============================================================
                Choose a Number: 
                """);
        }


        static void Main(string[] args)
        {
            while (flag) 
            {
                PrintMainMenu();
              

            }
        }
    }
}
