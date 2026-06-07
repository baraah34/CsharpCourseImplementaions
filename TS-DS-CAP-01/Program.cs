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
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
