using System;

namespace HotelManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //  variables declaration
            string guestName = "";
            string guestPhone = "";
            int roomNumber = 0;
            string roomType = "";
            double nightlyRate = 0;

            string checkInDate = "";
            string checkOutDate = "";

            int numberOfNights = 0;
            string roomNotes = "";

            double discountPercentage = 0;
            double totalBill = 0;// Stores total bill before discount
            double discountAmount = 0;// Stores discount amount
            double finalBill = 0;// Stores final bill after discoun

            double loyaltyPoints = 0;

            bool isRegistered = false;
            bool isCheckedIn = false;

            Random random = new Random();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("=== HOTEL MENU ===");
                Console.WriteLine("0. Register Guest");
                Console.WriteLine("1. View Info");
                Console.WriteLine("2. Check-In");
                Console.WriteLine("3. Check-Out & Bill");
                Console.WriteLine("4. Apply Discount");
                Console.WriteLine("5. Upgrade Room");
                Console.WriteLine("6. Add Service Note");
                Console.WriteLine("7. Search Guest");
                Console.WriteLine("8. Calculate Points");
                Console.WriteLine("9. Print Receipt");
                Console.WriteLine("10. Edit Name");
                Console.WriteLine("11. Exit");
                Console.Write("\nEnter choice: ");

                string choice = Console.ReadLine();
                if (choice != null) choice = choice.Trim(); // Removes spaces 

                Console.WriteLine();

                switch (choice)
                {
                    case "0": // Register New Guest
                        Console.Write("Enter Name: ");
                        guestName = Console.ReadLine();
                        if (guestName != null) guestName = guestName.Trim();

                        Console.Write("Enter Phone: ");
                        guestPhone = Console.ReadLine();
                        if (guestPhone != null) guestPhone = guestPhone.Trim();// Removes spaces from phone

                        Console.Write("Enter Room Type:[SINGLE/DOUBLE/FAMILY] ");
                        roomType = Console.ReadLine();
                        if (roomType != null) roomType = roomType.Trim();

                        Console.Write("Enter Nightly Rate: ");
                        nightlyRate = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Number of Nights: ");
                        numberOfNights = Convert.ToInt32(Console.ReadLine());

                        //  number between 100 and 500
                        roomNumber = random.Next(100, 501);// Generates room number from 100 to 500
                        roomNotes = "No notes.";
                        isRegistered = true;
                        isCheckedIn = false;

                        Console.WriteLine("Guest registered! Room assigned: " + roomNumber);
                        break;

                    case "1": // View Guest Information
                        if (!isRegistered)
                        {
                            Console.WriteLine("Error: No guest is registered.");
                            break;
                        }

                        Console.WriteLine("Guest Name: " + guestName.ToUpper());// Prints name in uppercase
                        Console.WriteLine("Phone: " + guestPhone);
                        Console.WriteLine("Room Number: " + Convert.ToString(roomNumber));// Converts room number to string
                        Console.WriteLine("Room Type: " + roomType);
                        Console.WriteLine("Nightly Rate: $" + Math.Round(nightlyRate, 2)); // Rounds price to 2 decimals
                        Console.WriteLine("Nights: " + numberOfNights);
                        Console.WriteLine("Check-In: " + checkInDate);
                        Console.WriteLine("Check-Out: " + checkOutDate);
                        Console.WriteLine("Notes: " + roomNotes);
                        Console.WriteLine("Loyalty Points: " + loyaltyPoints);
                        break;

                    case "2": // Check-In Guest
                        if (!isRegistered || isCheckedIn) //If guest is not registered OR already checked in
                        {
                            Console.WriteLine("Error: Cannot check in. Guest must be registered and not already checked in.");
                            break;
                        }

                        checkInDate = DateTime.Now.ToString();
                        checkOutDate = DateTime.Today.AddDays(numberOfNights).ToString();// Adds nights to today
                        isCheckedIn = true;

                        Console.WriteLine("Checked in successfully at: " + checkInDate);
                        break;

                    case "3": // Check-Out & Bill
                        if (!isCheckedIn)// If guest did not check in
                        {
                            Console.WriteLine("Error: Guest is not checked in.");
                            break;
                        }

                        totalBill = nightlyRate * numberOfNights;// Calculates total before discount
                        discountAmount = totalBill * (discountPercentage / 100.0);// Calculates discount amount
                        finalBill = totalBill - discountAmount;// Calculates final bill after discount

                        Console.WriteLine("Total Bill Amount: " + Math.Round(finalBill, 2));

                        Console.WriteLine("Check-out complete. System reset.");
                        break;

                    case "4": // Apply Discount
                        if (!isRegistered)
                        {
                            Console.WriteLine("Error: No guest registered.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Enter discount percentage :");
                            discountPercentage = double.Parse(Console.ReadLine());

                            totalBill = nightlyRate * numberOfNights;// Calculates total before discount
                            discountAmount = Math.Round(totalBill * (discountPercentage / 100), 2);// Calculates discount amount
                            finalBill = Math.Round(totalBill - discountAmount, 2); // Calculates final bill


                            if (discountPercentage > 0)// If discount is more than 0
                            {
                                Console.WriteLine("Discount of " + discountPercentage + "% applied.");
                                Console.WriteLine("Discount Amount: " + discountAmount + " OMR");
                                Console.WriteLine("Final Bill: " + finalBill + " OMR");
                            }
                            else
                            {
                                Console.WriteLine("No discount applied. Final Bill: " + Math.Round(totalBill, 2) + " OMR");
                            }
                        }

                        break;

                    case "5": // Upgrade Room
                        if (!isRegistered)
                        {
                            Console.WriteLine("Error: No guest registered.");
                            break;
                        }

                        Console.Write("Enter New Room Type: ");
                        string newType = Console.ReadLine();
                        if (newType != null) newType = newType.Trim();

                        Console.Write("Enter New Nightly Rate: ");
                        double newRate = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Higher Rate: " + Math.Max(nightlyRate, newRate));
                        Console.WriteLine("Lower Rate: " + Math.Min(nightlyRate, newRate));
                        Console.WriteLine("Difference per night: " + Math.Abs(newRate - nightlyRate));

                        roomType = newType;
                        nightlyRate = newRate;
                        Console.WriteLine("Room successfully upgraded.");
                        break;

                    case "6": // Add Room Service Note
                        if (!isRegistered)
                        {
                            Console.WriteLine("Error: No guest registered.");
                            break;
                        }

                        Console.Write("Enter room service note: ");
                        string inputNote = Console.ReadLine();

                        if (inputNote != null)
                            inputNote = inputNote.Trim();

                        if (inputNote == null || inputNote.Length == 0)
                        {
                            Console.WriteLine("Error: Note cannot be blank.");
                            break;
                        }

                        if (roomNotes == "No notes.")
                        {
                            roomNotes = roomNotes.Replace("No notes.", inputNote);
                        }
                        else
                        {
                            roomNotes = roomNotes + "\n" + inputNote;
                        }

                        Console.WriteLine("Note added. Current total notes length: " + roomNotes.Length);

                        break;

                    case "7": // Search Guest by Name
                        if (!isRegistered)
                        {
                            Console.WriteLine("Error: No registrations active.");
                            break;
                        }

                        Console.Write("Enter search keyword: ");
                        string searchKey = Console.ReadLine();
                        if (searchKey != null) searchKey = searchKey.Trim();

                        if (searchKey == null) searchKey = "";

                        // Case insensitive match checking
                        if (guestName.ToLower().Contains(searchKey.ToLower()))// Searches without caring about uppercase/lowercase
                        {
                            Console.WriteLine("Match found: " + guestName);
                        }
                        else
                        {
                            Console.WriteLine("No match found.");
                        }
                        break;

                    case "8": // Calculate Loyalty Points
                        if (!isRegistered)
                        {
                            Console.WriteLine("Error: No guest registered.");
                            break;
                        }

                        double pointsEarned = Math.Pow(numberOfNights, 2);//numberOfNights * numberOfNights

                        pointsEarned = Math.Round(pointsEarned, 2);

                        loyaltyPoints = loyaltyPoints + pointsEarned;// add past point to new point

                        Console.WriteLine("Points earned this stay: " + pointsEarned);
                        Console.WriteLine("Total points: " + loyaltyPoints);

                        break;

                    case "9": //print recipt
                        if (!isRegistered)
                        {
                            Console.WriteLine("Error: No guest registered.");
                            break;
                        }
                        else
                        {

                            string receipt =// Stores the full receipt 
                                "====== HOTEL RECEIPT ======\n" +
                                "Guest Name: " + guestName + "\n" +
                                "Phone:  " + guestPhone + "\n" +
                                "Room Number: " + Convert.ToString(roomNumber) + "\n" +
                                "Room Type: " + roomType + "\n" +
                                "Nights: " + Convert.ToString(numberOfNights) + "\n" +
                                "Total: " + Convert.ToString(Math.Round(totalBill, 2)) + "\n" +
                                "Discount: " + Convert.ToString(discountPercentage) + "%\n" +
                                "Final Bill: " + Convert.ToString(Math.Round(finalBill, 2)) + "\n" +
                                "Date: " + DateTime.Now.ToString() + "\n" +
                                "===========================";
                            Console.WriteLine(receipt);

                        }

                        break;

                    case "10": // Edit Guest Name
                        if (!isRegistered)
                        {
                            Console.WriteLine("Error: No guest registered.");
                            break;
                        }

                        Console.Write("Enter alternative name: ");
                        string alternateName = Console.ReadLine();
                        if (alternateName != null) alternateName = alternateName.Trim();

                        if (alternateName == null || alternateName.Length < 2)
                        {
                            Console.WriteLine("Error: Minimum required length is 2 characters.");
                            break;
                        }

                        Console.WriteLine("Uppercase preview: " + alternateName.ToUpper());
                        Console.WriteLine("Lowercase preview: " + alternateName.ToLower());

                        guestName = alternateName;
                        Console.WriteLine("Name successfully updated.");
                        break;

                    case "11": // Exit
                        Console.WriteLine("Session closed at: " + DateTime.Now.ToString());
                        return;

                    default:
                        Console.WriteLine("Invalid selection. Choose an option code between 0 and 11.");
                        break;
                }

                // Wait step before starting menu iteration again
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}