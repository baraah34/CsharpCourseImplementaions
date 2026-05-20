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

                    case 11:

                        break;

                    case 12:

                        break;

                    case 13:
                        break;

                    case 14:

                        break;

                    case 99:

                        break;

                    default:

                        break;
                }
            }
        }
    }
}
