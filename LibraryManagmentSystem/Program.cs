using System;

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
            Console.WriteLine("========================================");
        }

        // first case registration function
        static void RegisterMember()
        {
            if (memberRegistered)
            {
                Console.WriteLine("Member is already registered.");
                return;
            }

            Console.Write("Enter member name: ");
            memberName = Console.ReadLine();

            Console.Write("Enter member email: ");
            memberEmail = Console.ReadLine();

            Console.Write("Enter membership expiry date yyyy-MM-dd: ");
            membershipExpiryDate = Console.ReadLine();

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
            Console.WriteLine("Name:".PadLeft(5) + " " + memberName);
            Console.WriteLine("Member ID:".PadLeft(5) + " " + memberId);
            Console.WriteLine("Email:".PadLeft(5)+ " " + memberEmail);
            Console.WriteLine("Expiry Date:".PadLeft(5) + " " + membershipExpiryDate);
            Console.WriteLine("Tier:".PadLeft(5) + " " + memberTier);
        }

        // Search book function
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
           

            keyword = keyword.Substring(0, keyword.Length);//Substring(start, length) =>baraah (0,2)=>ba

            if (title.Contains(keyword))
            {
                Console.WriteLine("Book found: " + bookTitle);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        // Book registration
        static void RegisterBook()
        {
            if (IsRegistered)
            {
                Console.WriteLine("Book is already registered.");
                return;
            }

            Console.Write("Enter book title: ");
            string title = Console.ReadLine().Trim();

            Console.Write("Enter book author: ");
            string author = Console.ReadLine().Trim();

            Console.Write("Enter number of copies: ");
            int copies = int.Parse(Console.ReadLine());

            Console.Write("Enter book genre or press Enter to skip: ");
            string genre = Console.ReadLine().Trim();

            if (genre.Length == 0)
            {
                genre = "Uncategorized";
            }

            if (title.Length == 0 || author.Length == 0 || copies <= 0)
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

        // Borrow books
        static void BorrowBook()
        {
            if (!IsRegistered)
            {
                Console.WriteLine("No book registered in the system.");
                return;
            }

            if (availableCopies == 0)
            {
                Console.WriteLine("Sorry, there are no available copies of this book to borrow.");
                return;
            }

            DeductCopy(ref availableCopies);//call it

            Console.WriteLine("Book borrowed successfully! Remaining copies: " + availableCopies);
        }

        // Deducts one copy from available copies using ref
        static void DeductCopy(ref int currentCopies)// currentCopies => copy of availableCopies
        {
            currentCopies--;
        }

        // Return a borrowed book
        static void ReturnBook()
        {
            if (!IsRegistered)
            {
                Console.WriteLine("No book registered in the system.");
                return;
            }

            if (availableCopies == maxBookCopies)
            {
                Console.WriteLine("All copies are already returned.");
                return;
            }

            AddCopy(ref availableCopies);

            Console.WriteLine("Book returned successfully! Available copies: " + availableCopies);
        }
        // Adds one copy using ref
        static void AddCopy(ref int currentCopies)
        {
            currentCopies = Math.Min(maxBookCopies, currentCopies + 1);
        }


        //  calculating late fine
        static void CalculateLateFine()
        {
            Console.Write("Enter overdue days: ");
            int days = int.Parse(Console.ReadLine());

            double fine = CalculateLateFine(days);

            Console.WriteLine("Late fine: " + fine.ToString("F2") + " OMR");
        }

        // Calculates late fine and returns double
        static double CalculateLateFine(int days)
        {
            double fine = Math.Sqrt(days) * 2.5;
            return Math.Round(fine, 2);
        }

        // function for member discount
        static void ApplyMemberDiscount()
        {
            Console.Write("Enter amount: ");
            double amount = double.Parse(Console.ReadLine());

            double finalAmount = ApplyDiscount(amount, memberTier);

            Console.WriteLine("Amount after discount: " + finalAmount.ToString("F2") + " OMR");
        }

        // Discount function for normal discount
        static double ApplyDiscount(double amount)
        {
            double finalAmount = amount - (amount * 0.10);
            return Math.Round(finalAmount, 2);
        }

        // Discount function based on member tier
        static double ApplyDiscount(double amount, string tier)
        {
            tier = tier.ToUpper();

            double discount = 0.10;

            if (tier == "PREMIUM")
            {
                discount = 0.20;
            }

            double finalAmount = amount - (amount * discount);

            return Math.Round(finalAmount, 2);
        }

        // Handles borrowing eligibility.
        static void CheckEligibility()
        {
            if (!memberRegistered)
            {
                Console.WriteLine("No member registered.");
                return;
            }

            bool eligible = CheckBorrowingEligibility(membershipExpiryDate);

            if (eligible)
            {
                Console.WriteLine("Member is eligible to borrow books.");
            }
            else
            {
                Console.WriteLine("Member is not eligible. Membership expired.");
            }
        }
        // Checks if the member can borrow based on expiry date.
        static bool CheckBorrowingEligibility(string expiryDate)
        {
            DateTime expiry = DateTime.Parse(expiryDate);

            return expiry >= DateTime.Today;
        }

        // Handles member ID generation.
        static void HandleGenerateMemberId()
        {
            if (!memberRegistered)
            {
                Console.WriteLine("No member registered.");
                return;
            }

            memberId = GenerateMemberId();

            Console.WriteLine("Generated Member ID: " + memberId);
        }

        // Generates a member ID.
        static string GenerateMemberId()
        {
            string cleanName = memberName.Trim().Replace(" ", "").ToUpper();

            if (cleanName.Length < 3)
            {
                cleanName = cleanName + "XXX";
            }

            string namePart = cleanName.Substring(0, 3);

            long timeNumber = DateTime.Now.Ticks % 1000000;
            double numberPart = Math.Sqrt(timeNumber);

            return namePart + "-" + Math.Round(numberPart, 0);
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
                    case 0: // registration
                        RegisterMember();
                        break;

                    case 1: // profile display
                        MemberProfile();
                        break;

                    case 2: // book search
                        SearchBook();
                        break;

                    case 3: // borrow book
                        BorrowBook();
                        break;

                    case 4: // Return a Book
                        ReturnBook();
                        break;

                    case 5: // Calculate Late Fine
                        CalculateLateFine();
                        break;

                    case 6: // Apply Member Discount
                        ApplyMemberDiscount();
                        break;

                    case 7: // Check Borrowing Eligibility

                        CheckEligibility();
                        break;

                    case 8: // Register Book
                        RegisterBook();
                        break;

                    case 9: // Generate Member ID
                        HandleGenerateMemberId();

                        break;

                    case 10: // Display Book Details

                        break;

                    case 11: // Calculate Renewal Fee

                        break;

                    case 12: // Update Member Email

                        break;

                    case 13: // Session Summary

                        break;

                    case 14: // Exit
                        Console.WriteLine("Thank you for using the Library Management System.");
                        return;

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