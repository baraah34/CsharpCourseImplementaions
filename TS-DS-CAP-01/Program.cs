using System;
using System.Collections.Generic;
using System.IO;   // Files
using System.Linq; // LINQ

namespace TS_DS_CAP_01
{
    internal class Program
    {
        // List of passenger names
        static List<string> passengerNames = new List<string>()
        {
            "Baraah Said",
            "Wejdan Said ",
            "Rahaf Said",
            "Hidaya Nasser ",
            "Hafisa A "
        };

        // List of ticket numbers
        // Each ticket matches the passenger with the same index
        // Example: Baraah Said is index 0, so her ticket is TKT-001 index 0
        static List<string> ticketNumbers = new List<string>()
        {
            "TKT-001",
            "TKT-002",
            "TKT-003",
            "TKT-004",
            "TKT-005"
        };

        // Array of fixed flight numbers
        static string[] flightNumbers = new string[]
        {
            "OA101",
            "OA102",
            "OA103",
            "OA104",
            "OA105",
            "OA106"
        };

        // List of available dates
        static List<string> availableDates = new List<string>()
        {
            "12-MAR-2026",
            "15-MAR-2026",
            "18-APR-2026",
            "22-APR-2026"
        };

        // Dictionary to store bookings
        // Key = ticket number
        // Value = flight number + date
        // Example: TKT-001 -> OA101|12-MAR-2026
        static Dictionary<string, string> bookingRecord = new Dictionary<string, string>();

        // List to store cancelled tickets
        static List<string> cancelledTickets = new List<string>();

        // Passengers who have checked in, awaiting boarding
        static Queue<string> checkedInQueue = new Queue<string>();

        // Passengers boarding the aircraft (last checked-in, first to board)
        static Stack<string> boardingStack = new Stack<string>();

        // Dictionary to store passenger seats
        // Key = passengerName, Value = assigned seat (e.g. '14A')
        static Dictionary<string, string> passengerSeatMap = new Dictionary<string, string>();

        // Queue for waitlist passengers
        static Queue<string> waitlistQueue = new Queue<string>();

        // Seat row starts from 10
        static int seatRow = 10;

        // Seat number starts from 0
        // 0 = A, 1 = B, 2 = C, 3 = D, 4 = E, 5 = F
        static int seatNumber = 0;





        //  this file saves passenger name and ticket ID
        static string passengerFile = "passengers.txt";



        // ============================================================
        // file function: Save passenger details
        // append true means it will add new passenger without deleting old data
        static void SavePassengerToFile(string name, string ticket)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(passengerFile, true))
                {
                    writer.WriteLine(name + "|" + ticket);
                }
            }
            catch
            {
                Console.WriteLine("Error: Could not save passenger to file.");
            }
        }

        // ===========================================================
        // file function: Load passenger details
        // this reads passengers.txt when the program starts
        static void LoadPassengersFromFile()
        {
            try
            {
                if (!File.Exists(passengerFile))
                {
                    return;
                }

             

                using (StreamReader reader = new StreamReader(passengerFile))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');

                        if (parts.Length == 2)
                        {
                            passengerNames.Add(parts[0]);
                            ticketNumbers.Add(parts[1]);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error: Could not load passengers from file.");
            }
        }

    

        // ============================================================
        //case 1
        static void RegisterNewPassenger()
        {
            Console.WriteLine(" Register New Passenger ");

            Console.Write("Enter passenger full name: ");
            string name = Console.ReadLine();

            if (name != null)
            {
                name = name.Trim();
            }

            // Check if name is empty
            if (name == null || name.Length == 0)
            {
                Console.WriteLine("Error: Passenger name cannot be empty.");
                return;
            }

            // Check duplicate name
            //for (int i = 0; i < passengerNames.Count; i++)
            //{
            //    if (passengerNames[i].ToLower() == name.ToLower())
            //    {
            //        Console.WriteLine("Error: Passenger name already exists.");
            //        return;
            //    }
            //}

            //--------------------------------------------------
            // NEW CODE USING LINQ Any()

            //For each passenger name p, remove spaces, change it to lowercase, and compare it with the new name.
            //So this  asks:
            //Is there any passenger name already equal to the new name?
            bool nameExists = passengerNames.Any(p => p.Trim().ToLower() == name.ToLower());

            if (nameExists)
            {
                Console.WriteLine("Error: Passenger name already exists.");
                return;
            }
            //-----------------------------------------------------

            // Generate next ticket number
            int nextNumber = passengerNames.Count + 1;

            // D3 means 3 digits with zeros
            string newTicket = "TKT-" + nextNumber.ToString("D3");

            // Add passenger name to passenger list
            passengerNames.Add(name);

            // Add ticket to ticket list
            ticketNumbers.Add(newTicket);

            // NEW FILE CODE:
            // Save passenger details in passengers.txt
            SavePassengerToFile(name, newTicket);

            //WriteActivityLog("New passenger registered: " + name + " | Ticket: " + newTicket);

            Console.WriteLine("Passenger registered successfully.");
            Console.WriteLine("Passenger Name: " + name);
            Console.WriteLine("Ticket ID: " + newTicket);
        }

        //=============================================================================================
        // CASE 02
        static void ViewAllPassengers()
        {
            Console.WriteLine("===== View All Passengers =====");

            if (passengerNames.Count == 0)
            {
                Console.WriteLine("No passengers registered yet.");
                return;
            }

            Console.WriteLine("No. | Passenger Name           | Ticket ID | Status");
            Console.WriteLine("----------------------------------------------------");

            for (int i = 0; i < passengerNames.Count; i++)//start from zero then repeat it 
            {
                string status = "Active";

                if (cancelledTickets.Contains(ticketNumbers[i])) //If TKT-001 exists inside cancelledTickets, that means the ticket is cancelled.
                {
                    status = "CANCELLED";
                }

                Console.WriteLine(
                     (i + 1).ToString().PadRight(4) + "| " +
                     passengerNames[i].PadRight(25) + "| " +
                     ticketNumbers[i].PadRight(10) + "| " +
                      status
                       );
            }

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Total passengers: " + passengerNames.Count);
        }

        //============================================================================================
        //case 3
        static void BookFlightTicket()
        {
            Console.WriteLine("===== Book a Flight Ticket =====");

            Console.Write("Enter ticket ID: ");
            string ticket = Console.ReadLine();

            if (ticket != null)
            {
                ticket = ticket.Trim().ToUpper();
            }

            // Find ticket index
            int index = ticketNumbers.IndexOf(ticket);

            // If index is -1, ticket does not exist
            if (index == -1)
            {
                Console.WriteLine("Error: Ticket ID not found.");
                return;
            }

            // Cancelled ticket cannot be booked
            if (cancelledTickets.Contains(ticket))
            {
                Console.WriteLine("Error: Cancelled tickets cannot be booked.");
                return;
            }

            // If ticket already exists in bookingRecord, it already has booking
            if (bookingRecord.ContainsKey(ticket))
            {
                Console.WriteLine("This ticket already has a booking");
                return;
            }

            Console.WriteLine("\nAvailable Flights:");

            // Display flight array
            for (int i = 0; i < flightNumbers.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + flightNumbers[i]);
            }

            // Console.WriteLine("Select flight number: ");
            //int flightChoice = int.Parse(Console.ReadLine());

            //----------------------------------------------------------
            // NEW CODE USING TRY/CATCH ERROR HANDLING
            int flightChoice;

            try
            {
                Console.Write("Select flight number: ");
                flightChoice = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }
            //---------------------------------------------------------------

            // Validate flight choice
            //if user choice less than 1 and user choice bigger than avalibale flight number 
            // i use length to know  number of flight inside the array
            if (flightChoice < 1 || flightChoice > flightNumbers.Length)
            {
                Console.WriteLine("Invalid flight selection.");
                return;
            }

            // Get selected flight using index
            string selectedFlight = flightNumbers[flightChoice - 1];

            Console.WriteLine("\nAvailable Dates:");

            // Display available dates
            for (int i = 0; i < availableDates.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + availableDates[i]);
            }

            // Console.WriteLine("Select  date: ");
            //int dateChoice = int.Parse(Console.ReadLine());

            //----------------------------------------------------------
            // NEW CODE USING TRY/CATCH ERROR HANDLING
            int dateChoice;

            try
            {
                Console.Write("Select date: ");
                dateChoice = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }
            //-----------------------------------------------------------------

            // Validate date choice
            if (dateChoice < 1 || dateChoice > availableDates.Count)
            {
                Console.WriteLine("Invalid date selection.");
                return;
            }

            // Get selected date
            string selectedDate = availableDates[dateChoice - 1];

            // Store booking in dictionary
            // Key is ticket
            // Value is flight|date
            bookingRecord.Add(ticket, selectedFlight + "|" + selectedDate);


            Console.WriteLine("\nBooking confirmed successfully.");
            Console.WriteLine("Passenger Name: " + passengerNames[index]);
            Console.WriteLine("Ticket ID: " + ticket);
            Console.WriteLine("Flight: " + selectedFlight);
            Console.WriteLine("Date: " + selectedDate);
        }

        //=============================================================================
        //case 4
        static void ViewBookingDetails()
        {
            Console.WriteLine("===== View Booking Details =====");
            // ====THIS CODE from book flight function====
            Console.Write("Enter ticket ID: ");
            string ticket = Console.ReadLine();

            if (ticket != null)
            {
                ticket = ticket.Trim().ToUpper();
            }

            int index = ticketNumbers.IndexOf(ticket);

            // Validate ticket exists
            if (index == -1)
            {
                Console.WriteLine("Error: Ticket ID not found.");
                return;
            }

            // Check if ticket is cancelled
            if (cancelledTickets.Contains(ticket))
            {
                Console.WriteLine("This ticket has been cancelled.");
                return;
            }

            // Check if booking exists
            if (!bookingRecord.ContainsKey(ticket))
            {
                Console.WriteLine("No booking found for this ticket.");
                return;
            }

            // Get booking value from dictionary
            string bookingValue = bookingRecord[ticket];

            // Split flight and date using |
            //flight = "OA101"
            //date = "12-MAR-2026"
            //bookingValue = "OA101|12-MAR-2026"
            string[] parts = bookingValue.Split('|');

            string flight = parts[0];
            string date = parts[1];

            Console.WriteLine("=================================");
            Console.WriteLine("BOOKING SUMMARY");
            Console.WriteLine("=================================");
            Console.WriteLine("Passenger Name: " + passengerNames[index]);
            Console.WriteLine("Ticket ID: " + ticket);
            Console.WriteLine("Flight Number: " + flight);
            Console.WriteLine("Date: " + date);
            Console.WriteLine("=================================");
        }

        //======================================================================
        //case 5
        static void UpdateBooking()
        {
            Console.WriteLine("===== Update a Booking =====");

            Console.Write("Enter ticket ID: ");
            string ticket = Console.ReadLine();

            if (ticket != null)
            {
                ticket = ticket.Trim().ToUpper();
            }

            // Ticket must exist
            if (!ticketNumbers.Contains(ticket))
            {
                Console.WriteLine("Error: Ticket ID not found.");
                return;
            }

            // Cancelled ticket cannot be updated
            if (cancelledTickets.Contains(ticket))
            {
                Console.WriteLine("Error: Cancelled tickets cannot be updated.");
                return;
            }

            if (!bookingRecord.ContainsKey(ticket))
            {
                Console.WriteLine("Error: This ticket has no booking to update.");
                return;
            }

            // Get old booking value
            string oldValue = bookingRecord[ticket];

            // Split old booking into flight and date
            string[] oldParts = oldValue.Split('|');

            string oldFlight = oldParts[0];
            string oldDate = oldParts[1];

            // New values start as old values
            string newFlight = oldFlight;
            string newDate = oldDate;

            Console.WriteLine("Current Flight: " + oldFlight);
            Console.WriteLine("Current Date: " + oldDate);

            Console.WriteLine("\n1. Change flight only");
            Console.WriteLine("2. Change date only");
            Console.WriteLine("3. Change both");
            Console.WriteLine("0. Cancel update");

            // Console.Write("Choose update option:");
            //int choice = int.Parse(Console.ReadLine());

            //------------------------------------------------------------------
            // NEW CODE USING TRY/CATCH ERROR HANDLING
            int choice;

            try
            {
                Console.Write("Choose update option: ");
                choice = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }
            //----------------------------------------------------------------------------

            if (choice == 0)
            {
                Console.WriteLine("Update cancelled,No changes made.");
                return;
            }

            if (choice < 0 || choice > 3)
            {
                Console.WriteLine("Invalid update option.");
                return;
            }

            // If user wants to change flight
            if (choice == 1 || choice == 3)
            {
                Console.WriteLine("\nAvailable Flights:");

                for (int i = 0; i < flightNumbers.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + flightNumbers[i]);
                }

                // Console.Write("Select new flight:");
                // int flightChoice = int.Parse(Console.ReadLine());

                //----------------------------------------------------------------
                // NEW CODE USING TRY/CATCH ERROR HANDLING
                int flightChoice;

                try
                {
                    Console.Write("Select new flight: ");
                    flightChoice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    return;
                }
                //-----------------------------------------------------------------------

                if (flightChoice < 1 || flightChoice > flightNumbers.Length)
                {
                    Console.WriteLine("Invalid flight selection.");
                    return;
                }

                newFlight = flightNumbers[flightChoice - 1];
            }

            // If user wants to change date
            if (choice == 2 || choice == 3)
            {
                Console.WriteLine("\nAvailable Dates:");

                for (int i = 0; i < availableDates.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + availableDates[i]);
                }

                //Console.Write("Select new date: ");
                // int dateChoice = int.Parse(Console.ReadLine());

                //--------------------------------------------------------
                // NEW CODE USING TRY/CATCH ERROR HANDLING
                int dateChoice;

                try
                {
                    Console.Write("Select new date: ");
                    dateChoice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    return;
                }
                //---------------------------------------------------------------

                if (dateChoice < 1 || dateChoice > availableDates.Count)
                {
                    Console.WriteLine("Invalid date selection.");
                    return;
                }

                newDate = availableDates[dateChoice - 1];
            }

            bookingRecord[ticket] = newFlight + "|" + newDate;


            Console.WriteLine("\nBooking updated successfully.");
            Console.WriteLine("Old Flight: " + oldFlight + " | Old Date: " + oldDate);
            Console.WriteLine("New Flight: " + newFlight + " | New Date: " + newDate);
        }

        //===========================================================================================================
        //case 6 
        static void CancelTicket()
        {
            Console.WriteLine("===== Cancel a Booking =====");

            Console.Write("Enter ticket ID: ");
            string ticket = Console.ReadLine();

            if (ticket != null)
            {
                ticket = ticket.Trim().ToUpper();
            }

            int index = ticketNumbers.IndexOf(ticket);

            if (index == -1)
            {
                Console.WriteLine("Error: Ticket ID not found.");
                return;
            }

            if (!bookingRecord.ContainsKey(ticket))
            {
                Console.WriteLine("Error: This ticket has no booking to cancel.");
                return;
            }

            string passengerName = passengerNames[index];

            string removedBooking = bookingRecord[ticket];

            bookingRecord.Remove(ticket);


            Console.WriteLine("Booking cancelled successfully.");
            Console.WriteLine("Passenger Name: " + passengerName);
            Console.WriteLine("Ticket ID: " + ticket);
            Console.WriteLine("Removed Booking: " + removedBooking);
        }

        //============================================================================
        //case  7
        static void PassengerCheckIn()
        {
            bool checkInMenu = true;

            while (checkInMenu)
            {
                Console.Clear();

                Console.WriteLine("===== Passenger Check-In =====");
                Console.WriteLine("1. Check in a passenger");
                Console.WriteLine("2. View check-in queue");
                Console.WriteLine("3. Process next passenger");
                Console.WriteLine("0. Back");

                //Console.Write("Enter your choice: ");
                // int choice = int.Parse(Console.ReadLine());

                //-----------------------------------------------------------
                // NEW CODE USING TRY/CATCH ERROR HANDLING
                int choice;

                try
                {
                    Console.Write("Enter your choice: ");
                    choice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                //----------------------------------------------------------------

                switch (choice)
                {
                    case 1:
                        CheckInPassenger();
                        break;

                    case 2:
                        ViewCheckInQueue();
                        break;

                    case 3:
                        ProcessNextPassenger();
                        break;

                    case 0:
                        checkInMenu = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                if (checkInMenu)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void CheckInPassenger()
        {
            Console.Write("Enter ticket ID: ");
            string ticket = Console.ReadLine();

            if (ticket != null)
            {
                ticket = ticket.Trim().ToUpper();
            }

            int index = ticketNumbers.IndexOf(ticket);

            if (index == -1)
            {
                Console.WriteLine("Error: Ticket ID not found.");
                return;
            }

            if (cancelledTickets.Contains(ticket))
            {
                Console.WriteLine("Error: Cancelled ticket cannot check in.");
                return;
            }

            if (!bookingRecord.ContainsKey(ticket))
            {
                Console.WriteLine("Error: Passenger must have a booking before check-in.");
                return;
            }

            string passengerName = passengerNames[index];

            // Passenger cannot be added twice
            if (checkedInQueue.Contains(passengerName))
            {
                Console.WriteLine("Error: Passenger is already in the check-in queue.");
                return;
            }

            if (waitlistQueue.Contains(passengerName))
            {
                Console.WriteLine("Error: Passenger is already in the waitlist.");
                return;
            }

            // If queue has space, add to check-in queue
            if (checkedInQueue.Count < 10)
            {
                checkedInQueue.Enqueue(passengerName);
                Console.WriteLine(passengerName + " has been added to the check-in queue.");
            }
            else
            {
                // If queue is full, add to waitlist
                waitlistQueue.Enqueue(passengerName);
                Console.WriteLine("Check-in queue is full. Passenger added to waitlist.");
            }
        }

        static void ViewCheckInQueue()
        {
            Console.WriteLine("===== Current Check-In Queue =====");

            if (checkedInQueue.Count == 0)
            {
                Console.WriteLine("Check-in queue is empty.");
            }
            else
            {
                //int position = 1;

                //// foreach displays queue without removing items
                //foreach (string passenger in checkedInQueue)
                //{
                //    Console.WriteLine(position + ". " + passenger);
                //    position++;
                //}

                //-------------------------------------------------------------
                // NEW CODE USING LINQ Select()
                var queueList = checkedInQueue
                    .Select((passenger, index) => new
                    {
                        Position = index + 1,
                        Name = passenger
                    })
                    .ToList();

                foreach (var passenger in queueList)
                {
                    Console.WriteLine(passenger.Position + ". " + passenger.Name);
                }
            }

            //---------------------------------------------------------------
            Console.WriteLine("Waitlist count: " + waitlistQueue.Count);
        }

        static void ProcessNextPassenger()
        {
            if (checkedInQueue.Count == 0)
            {
                Console.WriteLine("No passenger in check-in queue.");
                return;
            }

            // Remove first passenger from queue
            string processedPassenger = checkedInQueue.Dequeue();


            Console.WriteLine("Processed passenger: " + processedPassenger);

            // If waitlist has passengers, move first waitlist passenger to queue
            if (waitlistQueue.Count > 0)
            {
                string movedPassenger = waitlistQueue.Dequeue();
                checkedInQueue.Enqueue(movedPassenger);


                Console.WriteLine("Moved from waitlist to check-in queue: " + movedPassenger);
            }
        }

        //==================================================================================================
        //CASE 8 
        static void BoardPassengers()
        {
            bool boardingMenu = true;

            while (boardingMenu)
            {
                Console.Clear();

                Console.WriteLine("===== Board Passengers =====");
                Console.WriteLine("1. Load boarding stack from check-in queue");
                Console.WriteLine("2. Board next passenger");
                Console.WriteLine("3. View boarding stack");
                Console.WriteLine("4. View boarding log");
                Console.WriteLine("0. Back");

                //Console.Write("Enter your choice: ");
                //int choice = int.Parse(Console.ReadLine());

                //----------------------------------------------------------
                // NEW CODE USING TRY/CATCH ERROR HANDLING
                int choice;

                try
                {
                    Console.Write("Enter your choice: ");
                    choice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                //-------------------------------------------------------------------- 

                switch (choice)
                {
                    case 1:
                        LoadBoardingStack();
                        break;

                    case 2:
                        BoardNextPassenger();
                        break;

                    case 3:
                        ViewBoardingStack();
                        break;

                    case 4:
                        ViewBoardingLog();
                        break;

                    case 0:
                        boardingMenu = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                if (boardingMenu)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        // This function moves all passengers from checkedInQueue to boardingStack.
        // Queue = First In First Out.
        // Stack = Last In First Out.
        // the last passenger moved into the stack will board first.
        static void LoadBoardingStack()
        {
            // If queue is empty but stack has passengers,
            // this means the stack was already loaded before.
            if (checkedInQueue.Count == 0 && boardingStack.Count > 0)
            {
                Console.WriteLine("Warning: Boarding stack is already loaded.");
                return;
            }

            // If no passengers checked in, there is nothing to load
            if (checkedInQueue.Count == 0)
            {
                Console.WriteLine("Check-in queue is empty. Nothing to load.");
                return;
            }

            int count = 0;// Count how many passengers were loaded

            // Move all passengers from queue to stack
            while (checkedInQueue.Count > 0)
            {
                string passenger = checkedInQueue.Dequeue();// Remove passenger from front of queue
                boardingStack.Push(passenger);// Add passenger to top of stack
                count++;// Increase
            }


            Console.WriteLine(count + " passengers loaded into boarding stack.");
        }

        // This function generates seats automatically.
        // Example: 10A, 10B, 10C, 10D, 10E, 10F, then 11A.
        static string GenerateNextSeat()
        {
            // Convert seatNumber to a letter.
            // If seatNumber = 0, seatLetter = A.
            char seatLetter = (char)('A' + seatNumber);

            // Combine row number and seat letter.
            string seat = seatRow.ToString() + seatLetter;

            seatNumber++;

            // If seatNumber reaches 6  that means A to F are finished.
            // Then go back to A and move to the next row.
            if (seatNumber == 6)
            {
                seatNumber = 0;
                seatRow++;
            }

            if (seatRow > 40)
            {
                seatRow = 40;
                seatNumber = 5;
            }

            return seat;
        }

        // This function boards the next passenger.
        // It removes one passenger from the top of the stack
        // and gives them an automatic seat.
        static void BoardNextPassenger()
        {
            if (boardingStack.Count == 0)
            {
                Console.WriteLine("Boarding stack is empty.");
                return;
            }

            // Pop removes the top passenger from stack
            string passenger = boardingStack.Pop();

            // Generate automatic seat
            string seat = GenerateNextSeat();

            // Store the passenger and seat in passengerSeatMap dictionary.
            // Key = passenger name
            // Value = seat
            if (passengerSeatMap.ContainsKey(passenger))
            {
                passengerSeatMap[passenger] = seat;
            }
            else
            {
                passengerSeatMap.Add(passenger, seat);
            }


            Console.WriteLine("Passenger boarded successfully.");
            Console.WriteLine("Passenger Name: " + passenger);
            Console.WriteLine("Assigned Seat: " + seat);
        }

        static void ViewBoardingStack()
        {
            Console.WriteLine("===== Boarding Stack =====");

            if (boardingStack.Count == 0)
            {
                Console.WriteLine("Boarding stack is empty.");
                return;
            }

            int position = 1;

            // foreach displays stack without removing items
            foreach (string passenger in boardingStack)
            {
                Console.WriteLine(position + ". " + passenger);
                position++;
            }
        }

        // This function displays all passengers who already boarded.
        // It reads from passengerSeatMap dictionary.
        static void ViewBoardingLog()
        {
            Console.WriteLine("===== Boarding Log =====");

            if (passengerSeatMap.Count == 0)
            {
                Console.WriteLine("No boarded passengers yet.");
                return;
            }

            // Display each boarded passenger and seat
            foreach (KeyValuePair<string, string> entry in passengerSeatMap)
            {
                Console.WriteLine(entry.Key + " - Seat: " + entry.Value);
            }
        }

        static void Main(string[] args)
        {
            // NEW FILE CODE:
            // Load saved passengers when the program starts
            LoadPassengersFromFile();

            bool mainMenu = true; // main menu loop

            while (mainMenu)
            {
                Console.Clear();

                Console.WriteLine("========================================");
                Console.WriteLine("SKY WINGS FLIGHT MANAGEMENT SYSTEM");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Register New Passenger");
                Console.WriteLine("2. View All Passengers");
                Console.WriteLine("3. Book a Flight Ticket");
                Console.WriteLine("4. View Booking Details");
                Console.WriteLine("5. Update a Booking");
                Console.WriteLine("6. Cancel a Ticket");
                Console.WriteLine("7. Passenger Check-In");
                Console.WriteLine("8. Board Passengers (Boarding Stack)");
                Console.WriteLine("9. Generate Flight Manifest");
                Console.WriteLine("10. Manage Waitlist & Seat Assignment");
                Console.WriteLine("0. Exit");
                Console.WriteLine("========================================");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (choice)
                {
                    case 1:// Register New Passenger
                        RegisterNewPassenger();
                        break;

                    case 2://View All Passengers
                        ViewAllPassengers();
                        break;

                    case 3:// Book a Flight Ticket
                        BookFlightTicket();
                        break;

                    case 4://View Booking Details
                        ViewBookingDetails();
                        break;

                    case 5:// Update a Booking
                        UpdateBooking();
                        break;

                    case 6:// Cancel a Ticket
                        CancelTicket();
                        break;

                    case 7:// Passenger Check-In
                        PassengerCheckIn();
                        break;

                    case 8:// Board Passengers (Boarding Stack)
                        BoardPassengers();
                        break;

                    case 9://Generate Flight Manifest
                        break;

                    case 10:// Manage Waitlist & Seat Assignment
                        break;

                    case 0:
                        mainMenu = false; // Stop
                        Console.WriteLine("Thank you for using Sky Wings Flight Management System.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select from the menu.");
                        break;
                }

                if (mainMenu)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}