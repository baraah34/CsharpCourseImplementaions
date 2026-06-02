using System;

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
                            break;

                        case 7:
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
