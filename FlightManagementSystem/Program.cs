using FlightManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;


namespace FlightManagementSystem
{
    internal class Program
    {
        //system variables
        public static bool flag = true;
        public static int choice;
        public static bool validationFlag = true;
        public static EmailAddressAttribute attribute = new EmailAddressAttribute();





        //Passenger variables
        public static int passengerId;
        public static string passengerName;
        public static string passengerEmail;
        public static string passengerPhoneNumber;
        public static string passengerPassportNumber;
        public static string passengerNationality;

        //Aircraft Variables
        public static int aircraftId;
        public static string aircraftModel;
        public static int totalSeats;
        public static bool isOperational;

        //Pilot Variables
        public static int pilotId;
        public static string pilotName;
        public static string pilotPhoneNumber;
        public static string pilotlicenseNumber;
        public static int flightHours;
        public static bool isAvailable;

        public static FlightManagementSystemContext context = new FlightManagementSystemContext
        {
            Aircrafts = new List<Aircraft>(),
            Bookings = new List<Booking>(),
            Flights = new List<Flight>(),
            Passengers = new List<Passenger>(),
            Pilots = new List<Pilot>()
        };

        //Setup Method
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
                
                """);
            Console.Write("Choose a Number: ");
        }
        public static string ReadName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Field Can't be Empty!!");
                validationFlag = false;
                Console.ResetColor();
                return null;
            }
            return name;
        }
        public static void ErrorCatch(ref string s)
        {
            try
            {
                s = Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
                validationFlag = false;
                return;
            }
        }
        public static void ErrorCatch(ref int i)
        {
            try
            {
                i = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
                validationFlag = false;
                return;
            }
        }
        public static void CheckIsUnique(string value)
        {
            if (context.Passengers.Any(p => p.passengerEmail == value))
            {
                validationFlag = false;
                return;
            }
        }
        public static int CheckIfZeroOrLess(int num)
        {
            if(num <= 0) 
            {
                validationFlag = false;
                return 0;
            }
            return num;
        }



        //Register Passenger Method
        public static string EmailFormatCheck(string email)
        {
            if (!attribute.IsValid(email))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid email format!");
                Console.ResetColor();
                validationFlag |= false;
                return null;
            }
            return email;
        }
        public static string PhoneNumberFormatCheck(string phoneNumber)
        {
            if (!Regex.IsMatch(phoneNumber, @"^[79]\d{7}$"))
            {
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine("The Phone Number should be 8 digits and it have to start with 7 or 9!!");
                Console.ResetColor();
                validationFlag = false;
                return null;
            }
            return phoneNumber;
        }
        public static int GeneratePassengerId()
        {
            if(context.Passengers.Count == 0)
            {
                int id2 = 1;
                return id2;
            }
        int id = context.Passengers.Max(p =>p.passengerId) + 1;
            return id;
        }
        public static void PassengerRegister()
        {
            validationFlag = true;
            //Enter Passenger Name
            Console.Write("Enter the Passenger Name: ");
            ErrorCatch(ref passengerName);
            if (!validationFlag) { return; }
            passengerName = ReadName(passengerName);
            if (!validationFlag) { return; }
           
            //Enter Passenger Email
            Console.Write("Enter the Passenger Email: ");
            ErrorCatch(ref passengerEmail);
            if (!validationFlag) { return; }
            CheckIsUnique(passengerEmail);
            if (!validationFlag)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("This email is already Registered!!");
                Console.ResetColor();
                return;
            }
            passengerEmail = EmailFormatCheck(passengerEmail);
            if (!validationFlag) { return; }

          
            //Enter Passenger Phone Number
            Console.Write("Enter the Passenger Phone Number: ");
            ErrorCatch (ref passengerPhoneNumber);
            if (!validationFlag) { return; }
            CheckIsUnique(passengerPhoneNumber);
            if (!validationFlag)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This phone number is already Registered!!");
                Console.ResetColor();
                return;
            }
            passengerPhoneNumber = PhoneNumberFormatCheck(passengerPhoneNumber);
            if (!validationFlag) { return; }

            //Enter Passenger Passport Number
            Console.Write("Enter the Passport Number: ");
            ErrorCatch(ref passengerPassportNumber);
            if (!validationFlag) { return; }
            CheckIsUnique(passengerPassportNumber);
            if (!validationFlag)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This passport number is already registered");
                Console.ResetColor();
            }

            //Enter Passenger Nationality
            Console.Write("Enter the Passenger Nationality: ");
            ErrorCatch(ref passengerNationality);
            if (!validationFlag) { return; }
            passengerNationality = ReadName(passengerNationality);

            passengerId = GeneratePassengerId();

            context.Passengers.Add(
                new Passenger
                {
                    passengerId = passengerId,
                    passengerName = passengerName,
                    passengerEmail = passengerEmail,
                    passengerPhone = passengerPhoneNumber,
                    passportNumber = passengerPassportNumber,
                    nationality = passengerNationality
                }
                );

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Passenger Added Successfully!!");
            Console.Write("Passenger ID: " + passengerId + " | Passenger Name: " + passengerName + " | Passenger Email: " + passengerEmail );
            Console.WriteLine(" | Passenger Phone Number: " + passengerPhoneNumber + " | Passenger Passport Number: " + passengerPassportNumber + " | Passenger Nationality: " + passengerNationality);
            Console.ResetColor();

        }
        //Add an Aircraft
        public static int GenerateAircraftId()
        {
            if (context.Aircrafts.Count == 0)
            {
                int id2 = 1;
                return id2;
            }
            int id = context.Aircrafts.Max(a => a.aircraftId);
            return id;
        }
        public static void AddAircraft()
        {
            validationFlag = true;
            //Aircraft model name
            Console.Write("Enter Aircraft Model Name: ");
            ErrorCatch(ref aircraftModel);
            if (!validationFlag) { return; }
            aircraftModel = ReadName(aircraftModel);
            if (!validationFlag) { return; }

            //Aircraft total Seats
            Console.Write("Enter Number of aircraft seat: ");
            ErrorCatch(ref totalSeats);
            if(!validationFlag) { return; }
            totalSeats = CheckIfZeroOrLess(totalSeats);

            aircraftId = GenerateAircraftId();

            context.Aircrafts.Add(
                new Aircraft
                {
                    aircraftId = aircraftId,
                    model = aircraftModel,
                    totalSeats = totalSeats,
                    isOperational = true
                });

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Aircraft Added Successfully!!");
            Console.WriteLine("Aircraft ID: " + aircraftId + " | Aircraft Name: " + aircraftModel + " | Aircraft Number of seats: " + totalSeats);
            Console.ResetColor();

        }

        //Register a pilot
        public static int GeneratePilotId()
        {
            if (context.Pilots.Count == 0)
            {
                int id2 = 1;
                return id2;
            }
            int id = context.Pilots.Max(pi => pi.pilotId);
            return id;
        }
        
        public static void RegisterPilot()
        {
            validationFlag = true;
            Console.Write("Enter the pilot name: ");
            ErrorCatch(ref pilotName);
            if (!validationFlag) { return; }
            pilotName = ReadName(pilotName);
            if (!validationFlag) { return; }

        }
        

        static void Main(string[] args)
        {
            while (flag) 
            {
                PrintMainMenu();

                ErrorCatch(ref choice);
                if (!validationFlag)
                {
                    choice = -1;
                }
                switch (choice)
                {
                    //Register a Passenger
                    case 1:
                        PassengerRegister();
                        break;
                    //Add an Aircraft
                    case 2:
                        AddAircraft();
                        break;
                    //Register a Pilot
                    case 3:
                        RegisterPilot();
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
