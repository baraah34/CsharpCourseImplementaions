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
        }


        static void Main(string[] args)
        {
            bool mainMenu = true; // Controls the main menu loop

            while (mainMenu)
            {
                Console.Clear(); // Clears screen before showing menu

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
                        break;

                    case 4:
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
                        mainMenu = false; // Stop the loop
                        Console.WriteLine("Thank you for using Sky Wings Flight Management System.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select from the menu.");
                        break;
                }

                // If user did not exit, pause before returning to menu
                if (mainMenu)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}