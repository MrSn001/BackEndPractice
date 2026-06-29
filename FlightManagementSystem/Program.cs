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
        public static int count;
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
        public static int pilotFlightNumber;
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
        public static string CheckIfNullOrEmpty(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Field Can't be Empty!!");
                validationFlag = false;
                Console.ResetColor();
                return null;
            }
            return value;
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
            passengerName = CheckIfNullOrEmpty(passengerName);
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
            passengerNationality = CheckIfNullOrEmpty(passengerNationality);

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
            int id = context.Aircrafts.Max(a => a.aircraftId) + 1;
            return id;
        }
        public static void AddAircraft()
        {
            validationFlag = true;
            //Aircraft model name
            Console.Write("Enter Aircraft Model Name: ");
            ErrorCatch(ref aircraftModel);
            if (!validationFlag) { return; }
            aircraftModel = CheckIfNullOrEmpty(aircraftModel);
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

            //Enter Pilot Name
            Console.Write("Enter the pilot name: ");
            ErrorCatch(ref pilotName);
            if (!validationFlag) { return; }
            pilotName = CheckIfNullOrEmpty(pilotName);
            if (!validationFlag) { return; }

            //Enter Pilot Phone Number
            Console.Write("Enter the Pilot Phone Number: ");
            ErrorCatch(ref pilotPhoneNumber);
            if (!validationFlag) { return; }
            CheckIsUnique(pilotPhoneNumber);
            if (!validationFlag)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This phone number is already Registered!!");
                Console.ResetColor();
                return;
            }
            pilotPhoneNumber = PhoneNumberFormatCheck(pilotPhoneNumber);
            if (!validationFlag) { return; }

            //Enter Pilot License Number
            Console.Write("Enter the Pilot License Number: ");
            ErrorCatch(ref pilotlicenseNumber);
            if (!validationFlag) { return; }
            pilotlicenseNumber = CheckIfNullOrEmpty(pilotlicenseNumber);
            CheckIsUnique(pilotlicenseNumber);
            if (!validationFlag)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This license number is already Registered!!");
                Console.ResetColor();
                return;
            }

            pilotId = GeneratePilotId();
            pilotFlightNumber = 0;
            context.Pilots.Add(
                new Pilot
                {
                    pilotId = pilotId,
                    pilotName = pilotName,
                    pilotPhone = pilotPhoneNumber,
                    flightHours = pilotFlightNumber,
                    licenseNumber = pilotlicenseNumber,
                    isAvailable = true
                }
                );

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pilot Added Successfully!!");
            Console.Write("Pilot ID: " + pilotId + " | Name: " + pilotName);
            Console.WriteLine(" | Phone Number: " + pilotPhoneNumber + " | License Number: " + pilotlicenseNumber + " | Flight Hours: " + pilotFlightNumber);
            Console.ResetColor();

        }

        //View All Flights
        public static void ViewAllFlights()
        {
            if(context.Flights.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no Schedule Flight!! ");
                Console.ResetColor();
                return;
            }
            const int codeW = -13;
            const int origW = -10;
            const int destW = -13;
            const int dateW = -16;
            const int timeW = -16;
            const int seatW = -17;
            const int pricW = -14;
            const int statW = -8;

            Console.WriteLine($"{"Flight Code",codeW} | {"Origin",origW} | {"Destination",destW} | {"Departure Date",dateW} | {"Departure Time",timeW} | {"Available Seats",seatW} | {"Ticket Price",pricW} | {"Status",statW}");
            Console.WriteLine(new string('-', 125));

            foreach (Flight flight in context.Flights)
            {
                Console.WriteLine($"{flight.flightCode,codeW} | {flight.origin,origW} | {flight.destination,destW} | {flight.departureDate,dateW} | {flight.departureTime,timeW} | {flight.availableSeats,seatW} | {flight.ticketPrice,pricW} | {flight.status,statW}");
            }
        }

        //Schedule a Flight
        public static void PrintAvailableAircraftForScheduling()
        {
            validationFlag = true;
            if(context.Aircrafts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no Aircraft Added.");
                Console.ResetColor();
                validationFlag = false;
                return;
            }
            Console.WriteLine("=========================================================");
            Console.WriteLine("        The Operational and Available AirCrafts");
            Console.WriteLine("=========================================================");

            List<Aircraft> operational = context.Aircrafts.Where(a => a.isOperational == true).ToList();

            count = 1;
            foreach(Aircraft aircraft in operational)
            {
                Console.WriteLine("Number: " + count + "  Aircraft ID: " + aircraft.aircraftId + " | Aircraft Name: " + aircraft.model + " | Aircraft Number of seats: " + aircraft.totalSeats);
                count++;
            }

        }
        public static void CheckIfAircraftIsAvailable(int num)
        {
            if (context.Aircrafts.Any(a => a.aircraftId != num))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no Aircraft ID with the number " + num);
                Console.ResetColor();
                validationFlag = false;
            }
            aircraftId = num;
        }

        public static void PrintAvailablePilots()
        {
            validationFlag = true;
            if (context.Pilots.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no Pilot Registred.");
                Console.ResetColor();
                validationFlag = false;
                return;
            }
            Console.WriteLine("=========================================================");
            Console.WriteLine("                  The Available Pilots");
            Console.WriteLine("=========================================================");

            List<Pilot> available = context.Pilots.Where(p=> p.isAvailable == true).ToList();

            count = 1;
            foreach (Pilot pilot in available)
            {
                Console.WriteLine("Number: " + count + "  Pilot ID: " + pilot.pilotId + " | Pilot Name: " + pilot.pilotName );
                count++;
            }
        }

        public static void CheckIfPilotIsAvailable(int num)
        {
            if (context.Pilots.Any(p => p.pilotId != num))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no Pilot ID with the number " + num);
                Console.ResetColor();
                validationFlag = false;
            }
        }

        public static void ScheduleFlight()
        {
            PrintAvailableAircraftForScheduling();
            Console.Write("Choose Aircraft ID: ");
            ErrorCatch(ref choice);
            if (!validationFlag) { return; }
            CheckIfAircraftIsAvailable(choice);
            if (!validationFlag) { return; }

            PrintAvailablePilots();
            Console.Write("Choose Pilot ID: ");
            ErrorCatch(ref choice);
            if (!validationFlag) { return; }
            CheckIfPilotIsAvailable(choice);
            if (!validationFlag) { return; }


        }


        static void Main(string[] args)
        {
            while (flag) 
            {
                validationFlag = true;
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
                        ViewAllFlights();
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
