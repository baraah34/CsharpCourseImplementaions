using System;
using System.Collections.Generic;

namespace StackQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool mainMenu = true;

            while (mainMenu)
            {
                Console.Clear();

                Console.WriteLine("======================================");
                Console.WriteLine("   TS-DS-03 STACK & QUEUE PRACTICE");
                Console.WriteLine("======================================");
                Console.WriteLine("1) Problem 1 - Browser History Tracker");
                Console.WriteLine("2) Problem 2 - Hotel Check-In Queue");
                Console.WriteLine("3) Problem 3 - Text Editor Undo System");
                Console.WriteLine("4) Problem 4 - Hospital ER Triage");
                Console.WriteLine("5) Problem 5 - Parenthesis Validator");
                Console.WriteLine("6) Problem 6 - Print Spooler");
                Console.WriteLine("7) Problem 7 - Reverse Sentence");
                Console.WriteLine("8) Problem 8 - Undo with Redo");
                Console.WriteLine("9) Problem 9 - Ticket Counter");
                Console.WriteLine("10) Problem 10 - Order Processing");
                Console.WriteLine("0) Exit");
                Console.WriteLine("======================================");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        break;

                    case "2":
                        break;

                    case "3":
                        break;

                    case "4":
                        break;

                    case "5":
                        break;

                    case "6":
                        break;

                    case "7":
                        break;

                    case "8":
                        break;

                    case "9":
                        break;

                    case "10":
                        break;

                    case "0":
                        mainMenu = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (mainMenu)
                {
                    Console.WriteLine("\nPress any key to return to main menu...");
                    Console.ReadKey();
                }
            }
        }

       
    }
}