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

        static void Main(string[] args)
        {
            int Mainchoice = int.Parse(Console.ReadLine());
            while (true)
            {
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

                        break;
                }
            }
        }
    }
}
