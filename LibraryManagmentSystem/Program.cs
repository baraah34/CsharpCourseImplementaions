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

        // Session storage fields
        static int totalBooksBorrowed = 0;
        static double totalFinesPaid = 0.00;

        // Displays the main menu
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
            Console.WriteLine("14) Member Statistics");
            Console.WriteLine("99) Exit");
            Console.WriteLine("========================================");
        }

        // Registers a new member
        static void RegisterMember()
        {
            if (memberRegistered)
            {
                Console.WriteLine("Member is already registered.");
                return;
            }

            Console.Write("Enter member name: ");
            memberName = Console.ReadLine().Trim();

            Console.Write("Enter member email: ");
            memberEmail = Console.ReadLine().Trim();

            Console.Write("Enter membership expiry date yyyy-MM-dd: ");
            DateTime expiryDate = DateTime.Parse(Console.ReadLine());
            membershipExpiryDate = expiryDate.ToString("yyyy-MM-dd");

            Console.Write("Enter member tier Standard/Premium: ");
            memberTier = Console.ReadLine().Trim();

            Console.Write("Enter member ID: ");
            memberId = Console.ReadLine().Trim();

            string registerTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string nameCode = memberName.Substring(0, Math.Min(memberName.Length, 3));

            memberRegistered = true;

            Console.WriteLine("Member registered successfully.");
            Console.WriteLine("Name Code: " + nameCode);
            Console.WriteLine("Registration Time: " + registerTime);
        }

        // Displays member profile
        static void MemberProfile()
        {
            if (!memberRegistered)
            {
                Console.WriteLine("No member registered.");
                return;
            }

            string borrowedText = Convert.ToString(totalBooksBorrowed);
            string finesText = Convert.ToString(Math.Round(totalFinesPaid, 2));

            Console.WriteLine("========================================");
            Console.WriteLine(" MEMBER PROFILE");
            Console.WriteLine("========================================");
            Console.WriteLine("Name:".PadLeft(20) + " " + memberName);
            Console.WriteLine("Member ID:".PadLeft(20) + " " + memberId);
            Console.WriteLine("Email:".PadLeft(20) + " " + memberEmail);
            Console.WriteLine("Expiry Date:".PadLeft(20) + " " + membershipExpiryDate);
            Console.WriteLine("Tier:".PadLeft(20) + " " + memberTier);
            Console.WriteLine("Books Borrowed:".PadLeft(20) + " " + borrowedText);
            Console.WriteLine("Fines Paid:".PadLeft(20) + " " + finesText + " OMR");
        }

        // Handles book search
        static void SearchBook()
        {
            if (IsRegistered == false)
            {
                Console.WriteLine("No book registered.");
                return;
            }

            Console.Write("Enter keyword to search: ");
            string keyword = Console.ReadLine();

            bool found = SearchBookByTitle(keyword);

            if (found)
            {
                Console.WriteLine("Book found: " + bookTitle);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        // Searches book title and returns true or false
        static bool SearchBookByTitle(string keyword)
        {
            keyword = keyword.ToLower();
            string title = bookTitle.ToLower();

            keyword = keyword.Substring(0, keyword.Length);

            if (keyword.Length == 0)
            {
                return false;
            }

            return title.Contains(keyword);
        }

        // Registers a book
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
                RegisterBookDetails(title, author, copies);
            }
            else
            {
                RegisterBookDetails(title, author, copies, genre);
            }
        }

        // Saves book details using optional genre
        static void RegisterBookDetails(string title, string author, int copies, string genre = "Uncategorized")
        {
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

        // Borrows a book
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

            DeductCopy(ref availableCopies);
            totalBooksBorrowed++;

            if (availableCopies == 0)
            {
                Console.WriteLine("Book borrowed successfully! No copies remaining.");
            }
            else
            {
                Console.WriteLine("Book borrowed successfully! Remaining copies: " + availableCopies);
            }
        }

        // Deducts one copy using ref
        static void DeductCopy(ref int currentCopies)
        {
            currentCopies = Math.Max(0, currentCopies - 1);
        }

        // Returns a borrowed book
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

        // Handles late fine calculation
        static void CalculateLateFine()
        {
            Console.Write("Enter overdue days: ");
            int days = int.Parse(Console.ReadLine());

            double fine = CalculateLateFine(days);

            totalFinesPaid = totalFinesPaid + fine;

            Console.WriteLine("Late fine: " + fine.ToString("F2") + " OMR");
        }

        // Calculates late fine and returns double
        static double CalculateLateFine(int days)
        {
            if (days <= 0)
            {
                return 0.00;
            }

            double fine = Math.Sqrt(days) * 2.5;

            return Math.Round(fine, 2);
        }

        // Handles member discount
        static void ApplyMemberDiscount()
        {
            Console.Write("Enter amount: ");
            double amount = double.Parse(Console.ReadLine());

            double normalDiscount = ApplyDiscount(amount);
            double tierDiscount = ApplyDiscount(amount, memberTier);

            Console.WriteLine("Normal discount amount: " + normalDiscount.ToString("F2") + " OMR");
            Console.WriteLine("Tier discount amount: " + tierDiscount.ToString("F2") + " OMR");
        }

        // Applies normal discount
        static double ApplyDiscount(double amount)
        {
            double finalAmount = amount - (amount * 0.10);

            return Math.Round(finalAmount, 2);
        }

        // Applies discount based on member tier
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

        // Handles borrowing eligibility
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

        // Checks if member can borrow based on expiry date
        static bool CheckBorrowingEligibility(string expiryDate)
        {
            DateTime expiry = DateTime.Parse(expiryDate);

            return expiry >= DateTime.Today;
        }

        // Handles member ID generation
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

        // Generates a member ID
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

        // Displays book details using named parameters
        static void DisplayBookDetails(string title, string author, string genre, int copies)
        {
            if (!IsRegistered)
            {
                Console.WriteLine("No book registered.");
                return;
            }

            string copiesText = Convert.ToString(copies);

            Console.WriteLine("========================================");
            Console.WriteLine(" BOOK DETAILS");
            Console.WriteLine("========================================");
            Console.WriteLine("Title".PadRight(20) + ": " + title);
            Console.WriteLine("Author".PadRight(20) + ": " + author);
            Console.WriteLine("Genre".PadRight(20) + ": " + genre);
            Console.WriteLine("Available Copies".PadRight(20) + ": " + copiesText);
        }

        // Handles renewal fee calculation
        static void CalculateRenewalFeeMenu()
        {
            Console.Write("Enter renewal days: ");
            int days = int.Parse(Console.ReadLine());

            double standardFee = CalculateRenewalFee(days);
            double premiumFee = CalculateRenewalFee(days, true);

            Console.WriteLine("Standard renewal fee: " + standardFee.ToString("F2") + " OMR");
            Console.WriteLine("Premium renewal fee: " + premiumFee.ToString("F2") + " OMR");
        }

        // Calculates standard renewal fee
        static double CalculateRenewalFee(int days)
        {
            double fee = Math.Ceiling(days * 0.35);

            return Math.Round(fee, 2);
        }

        // Calculates premium renewal fee
        static double CalculateRenewalFee(int days, bool isPremium)
        {
            double fee = Math.Ceiling(days * 0.35);

            if (isPremium)
            {
                fee = fee / 2;
            }

            return Math.Round(fee, 2);
        }

        // Handles email update
        static void UpdateMemberEmail()
        {
            if (!memberRegistered)
            {
                Console.WriteLine("No member registered.");
                return;
            }

            Console.Write("Enter new email: ");
            string newEmail = Console.ReadLine();

            string cleanedEmail;

            bool valid = ValidateEmail(newEmail, out cleanedEmail);

            if (valid)
            {
                memberEmail = cleanedEmail;
                Console.WriteLine("Email updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid email.");
            }
        }

        // Validates email and returns cleaned email using out
        static bool ValidateEmail(string email, out string cleanedEmail)
        {
            cleanedEmail = email.Trim();

            if (cleanedEmail.Length == 0)
            {
                return false;
            }

            if (!cleanedEmail.Contains("@"))
            {
                return false;
            }

            if (!cleanedEmail.Contains("."))
            {
                return false;
            }

            return true;
        }

        // Displays session summary
        static void SessionSummary()
        {
            string borrowedText = Convert.ToString(totalBooksBorrowed);
            string finesText = Convert.ToString(Math.Round(totalFinesPaid, 2));
            string dateText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Console.WriteLine("========================================");
            Console.WriteLine(" SESSION SUMMARY");
            Console.WriteLine("========================================");
            Console.WriteLine("Member Name: " + memberName);
            Console.WriteLine("Total Books Borrowed: " + borrowedText);
            Console.WriteLine("Total Fines Paid: " + finesText + " OMR");
            Console.WriteLine("Current Date and Time: " + dateText);
        }

        // Prints short member statistics
        static void MemberStatistics()
        {
            Console.WriteLine("========================================");
            Console.WriteLine(" MEMBER STATISTICS");
            Console.WriteLine("========================================");
            Console.WriteLine("Member Name: " + memberName);
            Console.WriteLine("Books Borrowed: " + totalBooksBorrowed);
            Console.WriteLine("Total Fines Paid: " + Math.Round(totalFinesPaid, 2) + " OMR");
        }

        // Prints full member statistics
        static void MemberStatistics(bool showDetails)
        {
            Console.WriteLine("========================================");
            Console.WriteLine(" FULL MEMBER STATISTICS");
            Console.WriteLine("========================================");
            Console.WriteLine("Member Name: " + memberName);
            Console.WriteLine("Books Borrowed: " + totalBooksBorrowed);
            Console.WriteLine("Total Fines Paid: " + Math.Round(totalFinesPaid, 2) + " OMR");

            if (showDetails)
            {
                Console.WriteLine("Member ID: " + memberId);
                Console.WriteLine("Expiry Date: " + membershipExpiryDate);
            }
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
                    case 0:
                        RegisterMember();
                        break;

                    case 1:
                        MemberProfile();
                        break;

                    case 2:
                        SearchBook();
                        break;

                    case 3:
                        BorrowBook();
                        break;

                    case 4:
                        ReturnBook();
                        break;

                    case 5:
                        CalculateLateFine();
                        break;

                    case 6:
                        ApplyMemberDiscount();
                        break;

                    case 7:
                        CheckEligibility();
                        break;

                    case 8:
                        RegisterBook();
                        break;

                    case 9:
                        HandleGenerateMemberId();
                        break;

                    case 10:
                        DisplayBookDetails(
                            title: bookTitle,
                            author: bookAuthor,
                            genre: bookGenre,
                            copies: availableCopies
                        );
                        break;

                    case 11:
                        CalculateRenewalFeeMenu();
                        break;

                    case 12:
                        UpdateMemberEmail();
                        break;

                    case 13:
                        SessionSummary();
                        break;

                    case 14:
                        MemberStatistics();
                        MemberStatistics(showDetails: true);
                        break;

                    case 99:
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