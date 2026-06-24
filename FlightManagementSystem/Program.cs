using FlightManagementSystem.Models;
using System.Security.Cryptography.X509Certificates;

namespace FlightManagementSystem
{
    internal class Program
    {
        //system variables
        public static bool flag = true;
        public static int choice;
        public static bool validationFlag = true;


        //Passenger variables
        public static string passengerName;

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
        public static string ReadName(string name)
        {
            if(name == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Field Can't be Empty!!");
                validationFlag = false;
                Console.ResetColor();
                return null;
            }
            return name;
        }

        public static void PassengerRegister()
        {
            Console.Write("Enter the Passenger Name: ");
            try
            {
                passengerName = Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
                return;
            }

            ReadName(passengerName);
        }

        static void Main(string[] args)
        {
            while (flag) 
            {
                PrintMainMenu();

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + ex.Message);
                    Console.ResetColor();
                    choice = -1;
                }

                switch (choice)
                {
                    //Register a Passenger
                    case 1:
                        break;
                    //Add an Aircraft
                    case 2:
                        break;
                    //Register a Pilot
                    case 3:
                        break;
                    //View All Flights
                    case 4:
                        break;
                    //Schedule a Flight
                    case 5:
                        break;
                    //Book a Flight
                    case 6:
                        break;
                    //Cancel a Booking
                    case 7:
                        break;
                    //Depart a Flight
                    case 8:
                        break;
                    //Cancel a Flight
                    case 9:
                        break;
                    //Passenger Booking History
                    case 10:
                        break;
                    //Flight Revenue & Load Factor Report
                    case 11:
                        break;
                    //For Catching The Errors
                    case -1:
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Option!!");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}
