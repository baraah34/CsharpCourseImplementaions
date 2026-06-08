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

        // Queue for passengers who checked in
        // WAITING => Queue means First In First Out
        static Queue<string> checkedInQueue = new Queue<string>();

        // Stack for boarding passengers
        // Stack means last checked-in, first to board
        static Stack<string> boardingStack = new Stack<string>();

        // Dictionary to store passenger seats
        // Key = passenger name
        // Value = seat number
        static Dictionary<string, string> passengerSeatMap = new Dictionary<string, string>();

        // Queue for waitlist passengers
        static Queue<string> waitlistQueue = new Queue<string>();

        // List to store cancelled tickets
        static List<string> cancelledTickets = new List<string>();


        //==================================================================================
        //case 0
        static void RegisterNewPassenger()
        {
            Console.WriteLine(" Register New Passenger ");

            Console.Write("Enter passenger full name: ");
            string name = Console.ReadLine(); // Read passenger name

            if (name != null)
            {
                name = name.Trim(); // Remove spaces from start and end
            }

            // Check if name is empty
            if (name == null || name.Length == 0)
            {
                Console.WriteLine("Error: Passenger name cannot be empty.");
                return; // Stop function
            }

            // Check duplicate name
            for (int i = 0; i < passengerNames.Count; i++)
            {
                if (passengerNames[i].ToLower() == name.ToLower())
                {
                    Console.WriteLine("Error: Passenger name already exists.");
                    return;
                }
            }

            // Generate next ticket number
            int nextNumber = passengerNames.Count + 1;

            // D3 means 3 digits with zeros
            string newTicket = "TKT-" + nextNumber.ToString("D3");

            // Add passenger name to passenger list
            passengerNames.Add(name);

            // Add ticket to ticket list
            ticketNumbers.Add(newTicket);

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
                    (i + 1).ToString() +
                    passengerNames[i] +
                    ticketNumbers[i]+
                    status
                );
            }

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Total passengers: " + passengerNames.Count);

        }//============================================================================================
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
                Console.WriteLine("This ticket already has a booking. Use update booking instead.");
                return;
            }

            Console.WriteLine("\nAvailable Flights:");

            // Display flight array
            for (int i = 0; i < flightNumbers.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + flightNumbers[i]);
            }
            Console.WriteLine("Select flight number: ");
            int flightChoice = int.Parse(Console.ReadLine());

         

            // Validate flight choice
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

            Console.WriteLine("Select  date: ");
            int dateChoice = int.Parse(Console.ReadLine());

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
            // ====from book flight function====
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

        static void Main(string[] args)
        {
            bool mainMenu = true; //  main menu loop

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
                    case 1:
                        RegisterNewPassenger();
                        break;

                    case 2:
                        ViewAllPassengers();
                        break;

                    case 3:
                        BookFlightTicket();
                        break;

                    case 4:
                        ViewBookingDetails();
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    case 7:
                        break;

                    case 8:
                        break;

                    case 9:
                        break;

                    case 10:
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