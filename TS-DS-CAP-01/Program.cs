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


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
