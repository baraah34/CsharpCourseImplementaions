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

            Console.WriteLine("Checking if URL is still in history:");
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

        // Problem 2: Hotel Check-In Queue - QUEUE
        static void Problem02()
        {
            Queue<string> checkInQueue = new Queue<string>();

            checkInQueue.Enqueue("BARAAH");
            checkInQueue.Enqueue("RAHAF");
            checkInQueue.Enqueue("WEJDAN");
            checkInQueue.Enqueue("HAFISA");
            checkInQueue.Enqueue("HIDAYA");

            Console.WriteLine(" Problem 2: Hotel Check-In Queue ");

            Console.WriteLine("All waiting guests:");
            foreach (string guest in checkInQueue)
            {
                Console.WriteLine(guest);
            }

            Console.WriteLine("Next guest using Peek:");
            Console.WriteLine(checkInQueue.Peek());

            Console.WriteLine("\nServing next 2 guests:");
            Console.WriteLine("Served guest: " + checkInQueue.Dequeue());
            Console.WriteLine("Served guest: " + checkInQueue.Dequeue());

            Console.WriteLine("Remaining queue:");
            foreach (string guest in checkInQueue)
            {
                Console.WriteLine(guest);
            }

            string searchGuest = "RAHAF";

            Console.WriteLine("Checking if guest is still waiting:");
            if (checkInQueue.Contains(searchGuest))
            {
                Console.WriteLine(searchGuest + " is still waiting.");
            }
            else
            {
                Console.WriteLine(searchGuest + " is NOT waiting.");
            }

            Console.WriteLine("Total guests still waiting: " + checkInQueue.Count);
        }

        // Problem 3: Text Editor Undo System - STACK
        
        static void Problem03()
        {
            Stack<string> undoStack = new Stack<string>();
            Stack<string> tempStack = new Stack<string>();

            undoStack.Push("Typed: Hello");
            undoStack.Push("Typed: World");
            undoStack.Push("Deleted: World");
            undoStack.Push("Changed font size");
            undoStack.Push("Inserted image");
            undoStack.Push("Changed text color");
            undoStack.Push("Saved document");

            Console.WriteLine(" Problem 3: Text Editor Undo System ");

            Console.WriteLine("Full undo history:");
            foreach (string action in undoStack)
            {
                Console.WriteLine(action);
            }

            Console.WriteLine("Next action to undo using Peek:");
            Console.WriteLine(undoStack.Peek());

            Console.WriteLine("Undo last 2 actions:");
            Console.WriteLine("Undone: " + undoStack.Pop());
            Console.WriteLine("Undone: " + undoStack.Pop());

            Console.WriteLine("Undo history after 2 pops:");
            foreach (string action in undoStack)
            {
                Console.WriteLine(action);
            }

            string targetAction = "Deleted: World";

            Console.WriteLine("Before selective undo:");
            foreach (string action in undoStack)
            {
                Console.WriteLine(action);
            }

            while (undoStack.Count > 0)
            {
                string currentAction = undoStack.Pop();

                if (currentAction != targetAction)
                {
                    tempStack.Push(currentAction);
                }
                else
                {
                    Console.WriteLine("Selective undo removed: " + currentAction);
                }
            }

            while (tempStack.Count > 0)
            {
                undoStack.Push(tempStack.Pop());
            }

            Console.WriteLine("After selective undo:");
            foreach (string action in undoStack)
            {
                Console.WriteLine(action);
            }

            Console.WriteLine("Final number of actions: " + undoStack.Count);
        }

        // Problem 4: Hospital Emergency Room Triage - QUEUE
        static void Problem04()
        {
            Queue<string> triageQueue = new Queue<string>();
            Queue<string> tempQueue = new Queue<string>();

            triageQueue.Enqueue("BARAAH");
            triageQueue.Enqueue("RAHAF");
            triageQueue.Enqueue("WEJDAN");
            triageQueue.Enqueue("HAFISA");
            triageQueue.Enqueue("HIDAYA");
            triageQueue.Enqueue("MARYAM");
            triageQueue.Enqueue("MUNA");
            triageQueue.Enqueue("AISHA");

            Console.WriteLine(" Problem 4: Hospital Emergency Room Triage ");

            Console.WriteLine("Full triage queue:");
            int position = 1;
            foreach (string patient in triageQueue)
            {
                Console.WriteLine(position + ") " + patient);
                position++;
            }

            Console.WriteLine("Next patient using Peek:");
            Console.WriteLine(triageQueue.Peek());

            Console.WriteLine("Processing first 3 patients:");
            Console.WriteLine("Seen patient: " + triageQueue.Dequeue());
            Console.WriteLine("Seen patient: " + triageQueue.Dequeue());
            Console.WriteLine("Seen patient: " + triageQueue.Dequeue());

            Console.WriteLine("Remaining queue:");
            foreach (string patient in triageQueue)
            {
                Console.WriteLine(patient);
            }

            string patientLeft = "BARAAH";

            Console.WriteLine("Patient left without being seen: " + patientLeft);

            while (triageQueue.Count > 0)
            {
                string currentPatient = triageQueue.Dequeue();

                if (currentPatient != patientLeft)
                {
                    tempQueue.Enqueue(currentPatient);
                }
            }

            while (tempQueue.Count > 0)
            {
                triageQueue.Enqueue(tempQueue.Dequeue());
            }

            Console.WriteLine("Final queue after removal:");
            foreach (string patient in triageQueue)
            {
                Console.WriteLine(patient);
            }

            Console.WriteLine("Final queue count: " + triageQueue.Count);
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
                        Problem02();
                        break;

                    case "3":
                        Problem03();
                        break;

                    case "4":
                        Problem04();
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