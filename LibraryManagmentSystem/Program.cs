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
        static bool IsRegistered = false;

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
        //first case regestration function 
        static void RegisterMember()
        {
            if (memberRegistered)
            {
                Console.WriteLine("member is already registered.");
                return;
            }

            Console.Write("Enter member name: ");
            memberName = Console.ReadLine();

            Console.Write("Enter member email: ");
            memberEmail = Console.ReadLine();

            Console.Write("Enter membership expiry date yyyy-MM-dd: ");
            membershipExpiryDate = Console.ReadLine();
            string registerTime = DateTime.Now.ToString("yyyyMMdd HHmmss");



            Console.Write("Enter member tier Standard/Premium: ");
            memberTier = Console.ReadLine();

           


            Console.Write("Enter member ID: ");
            memberId = Console.ReadLine();

          

            memberRegistered = true;
            Console.WriteLine("Member registered successfully.");
            
        }
        // Displays member profile.
        static void MemberProfile()
        {
            if (!memberRegistered)
            {
                Console.WriteLine("No member registered.");
                return;
            }

            

            Console.WriteLine("========================================");
            Console.WriteLine(" MEMBER PROFILE");
            Console.WriteLine("========================================");
            Console.WriteLine("Name:".PadLeft(20) + " " + memberName);
            Console.WriteLine("Member ID:".PadLeft(20) + " " + memberId);
            Console.WriteLine("Email:".PadLeft(20) + " " + memberEmail);
            Console.WriteLine("Expiry Date:".PadLeft(20) + " " + membershipExpiryDate);
            Console.WriteLine("Tier:".PadLeft(20) + " " + memberTier);
           
        }

        static void SearchBook()
        {
            if (IsRegistered == false)
            {
                Console.WriteLine("No book registered.");
                return;
            }

            Console.Write("Enter keyword to search: ");
            string keyword = Console.ReadLine().ToLower();

            string title = bookTitle.ToLower();

            if (title.Contains(keyword))
            {
                Console.WriteLine("Book found: " + bookTitle);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        //book regestration
        static void RegisterBook(string title, string author, int copies, string genre = "Uncategorized")
        {
            if (title.Length == 0 || author.Length == 0 || copies <= 0)// if empty
            {
                Console.WriteLine("Invalid book information.");
                return;
            }

            bookTitle = title;
            bookAuthor = author;
            availableCopies = copies;
            maxBookCopies = copies;
            bookGenre = genre;

            IsRegistered = true;

            Console.WriteLine("Book registered successfully.");
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
                        RegisterMember();
                        break;

                    case 1:// profile display
                        MemberProfile();
                        break;

                    case 2://book search
                        SearchBook();
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
