using System;
using System.Collections.Generic;

namespace TS_DS_01
{
    internal class Program
    {
        // function for problem 1
        static void Problem01()
        {
            List<double> temperatures = new List<double>() { 38.5, 35.2, 34.8, 36.3, 34.9, 35.9, 30.5 };

            Console.WriteLine("Problem 1: Temperature Log ");

            for (int i = 0; i < temperatures.Count; i++)
            {
                Console.WriteLine("Day " + (i + 1) + ": " + temperatures[i] + " C");
            }

            Console.WriteLine("Total number of readings: " + temperatures.Count);
        }
        // function for problem 2
        static void Problem02()
        {
            List<int> scores = new List<int>() { 85, 92, 76, 88, 95, 67 };

            Console.WriteLine(" Problem 2: Student Score Board ");

            Console.WriteLine("Original Scores:");

            foreach (int score in scores)
            {
                Console.WriteLine(score);
            }

            scores.Reverse();

            Console.WriteLine("\nReversed Scores:");

            foreach (int score in scores)
            {
                Console.WriteLine(score);
            }
        }



        static void Main(string[] args)
        {
            bool mainMenu = true;

            while (mainMenu)
            {
                Console.Clear();

                Console.WriteLine("======================================");
                Console.WriteLine("      LISTS ");
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
                   
                        break;

                    case 4:
                   
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

                    case 0:
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