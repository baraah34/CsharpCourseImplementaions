namespace LibraryManagmentSystem
{
    internal class Program
    {
        static string memberName = "";
        static string memberId = "";
        static string memberEmail = "";
        static string membershipExpiryDate = "";
        static string memberTier = "";
        static bool memberRegistered = false;

        // Book storage fields
        static string bookTitle = "";
        static string bookAuthor = "";
        static string bookGenre = "";
        static int availableCopies = 0;
        static int maxBookCopies = 0;
        static bool bookRegistered = false;

        static void mainMenu()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("  LIBRARY MANAGEMENT SYSTEM");
            Console.WriteLine("========================================");
            Console.WriteLine("0)  Register Member");
            Console.WriteLine("1)  Display Member Profile");
            Console.WriteLine("2)  Search Book by Title");
            Console.WriteLine("3)  Borrow a Book");
            Console.WriteLine("4)  Return a Book");
            Console.WriteLine("5)  Calculate Late Fine");
            Console.WriteLine("6)  Apply Member Discount");
            Console.WriteLine("7)  Check Borrowing Eligibility");
            Console.WriteLine("8)  Register Book");
            Console.WriteLine("9)  Generate Member ID");
            Console.WriteLine("10) Display Book Details");
            Console.WriteLine("11) Calculate Renewal Fee");
            Console.WriteLine("12) Update Member Email");
            Console.WriteLine("13) Session Summary");
            Console.WriteLine("14) Exit");

        }

        static void Main(string[] args)
        {
            
            while (true)
            {


                mainMenu();

                Console.Write("Enter your choice: ");
                int Mainchoice = int.Parse(Console.ReadLine()); 

                switch (Mainchoice)
                {
                    case 0://registration

                        break;

                    case 1:// profile display

                        break;

                    case 2://book search

                        break;

                    case 3://borrow book

                        break;

                    case 4://Return a Book 

                        break;

                    case 5://Calculate Late Fine

                        break;

                    case 6://Apply Member Discount

                        break;

                    case 7://Check Borrowing Eligibility

                        break;

                    case 8://Register Book

                        break;

                    case 9://Generate Member ID

                        break;

                    case 10://Display Book Details

                        break;

                    case 11://Calculate Renewal Fee

                        break;

                    case 12://Update Member Email

                        break;

                    case 13://Session Summary
                        break;


                    default:
                        Console.WriteLine("Invalid choice.");
                        break;

                    
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

        }
    }
}
