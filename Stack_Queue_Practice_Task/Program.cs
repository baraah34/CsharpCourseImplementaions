using System;
using System.Collections.Generic;

namespace StackQueue
{
    internal class Program
    {
        // Problem 1: Browser History Tracker - STACK
        static void Problem01()
        {
            Stack<string> browserHistory = new Stack<string>();

            browserHistory.Push("www.google.com");
            browserHistory.Push("www.youtube.com");
            browserHistory.Push("www.github.com");
            browserHistory.Push("www.microsoft.com");
            browserHistory.Push("www.openai.com");

            Console.WriteLine(" Problem 1: Browser History Tracker ");

            Console.WriteLine("All pages in history:");
            foreach (string page in browserHistory)
            {
                Console.WriteLine(page);
            }

            Console.WriteLine("Current page using Peek:");
            Console.WriteLine(browserHistory.Peek());

            Console.WriteLine("User pressed Back twice:");
            Console.WriteLine("Removed page: " + browserHistory.Pop());
            Console.WriteLine("Removed page: " + browserHistory.Pop());

            Console.WriteLine("\nRemaining history:");
            foreach (string page in browserHistory)
            {
                Console.WriteLine(page);
            }

            string searchUrl = "www.youtube.com";

            Console.WriteLine("\nChecking if URL is still in history:");
            if (browserHistory.Contains(searchUrl))
            {
                Console.WriteLine(searchUrl + " is still in the history.");
            }
            else
            {
                Console.WriteLine(searchUrl + " is NOT in the history.");
            }

            Console.WriteLine("\nTotal pages remaining: " + browserHistory.Count);
        }

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
                        Problem01();
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