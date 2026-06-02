using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TS_DS_01
{
    internal class Program
    {
        // function for problem 1
        static void Problem01()
        {
            double[] temperatures = new double[7] { 38.5, 35.2, 34.8, 36.3, 34.9, 35.9, 30.5 };

            Console.WriteLine("Problem 1: Temperature Log ");

            for (int i = 0; i < temperatures.Length; i++)
            {
                //i = 0  → Day 1
               // i = 1  → Day 2
               //i = 2  → Day 3
                Console.WriteLine("Day" + (i + 1) + ": " + temperatures[i] + " C");
            }

            Console.WriteLine("Total number of readings: " + temperatures.Length);
        }
        // function for problem 2
        static void Problem02()
        {
            int[] scores = new int[6] { 85, 92, 76, 88, 95, 67 };

            Console.WriteLine(" Problem 2: Student Score Board ");

            Console.WriteLine("Original Scores:");
            //take each number from scores put it in score
            foreach (int score in scores)
            {
                Console.WriteLine(score);
            }

            Array.Reverse(scores);

            Console.WriteLine("\nReversed Scores:");
            //for reverse
            foreach (int score in scores)
            {
                Console.WriteLine(score);
            }
        }
        // function for problem 3
        static void Problem03()
        {
            double[] prices = new double[5] { 4.99, 2.50, 10.75, 6.30, 8.99 };

            double targetPrice = 8.99;

            Console.WriteLine(" Problem 3: Product Price Finder ");

            for (int i = 0; i < prices.Length; i++)
            {
                Console.WriteLine("Product " + (i + 1) + ": " + prices[i] + " OMR");
            }

            int index = Array.IndexOf(prices, targetPrice);

            if (index != -1)
            {
                Console.WriteLine("\nPrice found at index: " + index);
            }
            else
            {
                Console.WriteLine("\nPrice not found.");
            }
        }
        // function for problem 4

        static void Problem04()
        {
            int[] finishTimes = new int[8] { 55, 47, 63, 51, 41, 59, 50, 54};

            Console.WriteLine(" Problem 4: Race Finish Times ");

            Console.WriteLine("Original Finish Times:");

            foreach (int time in finishTimes)
            {
                Console.WriteLine(time + " seconds");
            }

            Array.Sort(finishTimes);

            Console.WriteLine("\nSorted Finish Times Fastest First:");
            foreach (int time in finishTimes)
            {
                Console.WriteLine(time + " seconds");
            }

            Console.WriteLine("\nTotal participants: " + finishTimes.Length);
        }
        // function for problem 5

        static void Problem05()
        {
            int[] grades = new int[10] { 86, 93, 75, 89, 96, 67, 79, 91, 81, 71 };

            Console.WriteLine(" Problem 5: Classroom Grade Report ");

            Array.Sort(grades);
            Array.Reverse(grades);

            for (int i = 0; i < grades.Length; i++)
            {
                Console.WriteLine("Rank " + (i + 1) + ": " + grades[i]);
            }
        }

        // function for problem 6


        static void Problem06()
        {
            int[] quantities = new int[8] { 13, 26, 9, 41, 16, 31, 23, 11 };

            int total = 0;
            int targetQuantity = 30;

            Console.WriteLine(" Problem 6: Warehouse Inventory Check ");
            //Calculate and display the total stock by summing all elements
            for (int i = 0; i < quantities.Length; i++)
            {
                total +=   quantities[i];
            }
            //Display the average stock per slot (total divided by array length).
            double average = (double)total / quantities.Length;

            Console.WriteLine("Total stock: " + total);
            Console.WriteLine("Average stock per slot: " + average);

           // Search for a hardcoded target quantity
            //and report its slot index, or indicate it was not found.
            int index = Array.IndexOf(quantities, targetQuantity);

            if (index != -1)
            {
                Console.WriteLine("Target quantity found at slot index: " + index);
            }
            else
            {
                Console.WriteLine("Target quantity not found.");
            }
        }


        //function for problem 7
        static void Problem07()
        {
            int[] copies = new int[9] { 3, 0, 7, 2, 5, 1, 9, 4, 6 };

            // Create a boolean variable to check if there is any book with zero copies
            // At the beginning, we assume there is no zero, so we set it to false

            bool hasZero = false;

            Console.WriteLine(" Problem 7: Library Book Shelf Scanner ");

            // Use foreach loop to print each copy count in the original order
            Console.WriteLine("Original Copy Counts:");
            foreach (int copy in copies)
            {
                Console.WriteLine(copy);
            }


            // Sort the copies array in ascending order
            // Example: 3, 0, 7 becomes 0, 3, 7
            Array.Sort(copies);

            // Use foreach loop again to print each copy count after sorting
            Console.WriteLine("\nSorted Copy Counts:");
            foreach (int copy in copies)
            {
                Console.WriteLine(copy);
            }

            // Get the maximum number of copies
            // After sorting, the biggest number is always at the last index
            // copies.Length - 1 gives the last index of the array
            int maxCopies = copies[copies.Length - 1];

            Console.WriteLine("\nBook with the most copies has: " + maxCopies + " copies");

            // Use a for loop to check every value in the copies array
            for (int i = 0; i < copies.Length; i++)
            {
                // Check if the current copy count is equal to zero
                if (copies[i] == 0)
                {
                    // If zero is found, change hasZero to true
                    hasZero = true;
                }
            }

            if (hasZero == true)
            {
                Console.WriteLine("There is at least one book with zero copies.");
            }
            else
            {
                Console.WriteLine("There are no books with zero copies.");
            }
        }

        static void Main(string[] args)
            {
                bool mainMenu = true;

                while (mainMenu)
                {
                    Console.Clear();

                    Console.WriteLine("======================================");
                    Console.WriteLine("     TS-DS-01 ARRAYS ");
                    Console.WriteLine("======================================");
                    Console.WriteLine("1)  Problem 1  - Temperature Log");
                    Console.WriteLine("2)  Problem 2  - Student Score Board");
                    Console.WriteLine("3)  Problem 3  - Product Price Finder");
                    Console.WriteLine("4)  Problem 4  - Race Finish Times");
                    Console.WriteLine("5)  Problem 5  - Classroom Grade Report");
                    Console.WriteLine("6)  Problem 6  - Warehouse Inventory Check");
                    Console.WriteLine("7)  Problem 7  - Library Book Shelf Scanner");
                    Console.WriteLine("8)  Problem 8  - Sales Performance Analyzer");
                    Console.WriteLine("9)  Problem 9  - Flight Seat Allocation Display");
                    Console.WriteLine("10) Problem 10 - Hospital Patient Priority Queue");
                    Console.WriteLine("0)  Exit");
                    Console.WriteLine("======================================");

                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    Console.Clear();

                    switch (choice)
                    {
                        case 1:
                            Problem01();
                            break;

                        case 2:
                            Problem02();
                            break;

                        case 3:
                        Problem03();
                            break;

                        case 4:
                        Problem04();
                            break;

                        case 5:
                        Problem05();
                            break;

                        case 6:
                        Problem06();
                            break;

                        case 7:
                        Problem07();
                            break;

                        case 8:
                            break;

                        case 9:
                            break;

                        case 10:
                            break;

                        case 0:
                            mainMenu = false;
                            Console.WriteLine("Program closed.");
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }

                    if (mainMenu == true)
                    {
                        Console.WriteLine("\nPress any key to return to main menu...");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
