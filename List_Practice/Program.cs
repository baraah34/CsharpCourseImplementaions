using System;
using System.Collections.Generic;

namespace TS_DS_02_List_Practice
{
    internal class Program
    {
        static void Problem01()
        {
            List<string> menuItems = new List<string>();

            menuItems.Add("Burger");
            menuItems.Add("Pizza");
            menuItems.Add("Pasta");
            menuItems.Add("Caesar Salad");

            Console.WriteLine("===== Problem 1: Room Service Menu =====");

            Console.WriteLine("\n--- Original Menu ---");
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + menuItems[i]);
            }

            menuItems.Add("Chicken Sandwich");
            menuItems.Add("Fruit Salad");

            Console.WriteLine("\n--- Updated Menu After Adding 2 Dishes ---");
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + menuItems[i]);
            }

            menuItems.Remove("Pizza");

            Console.WriteLine("\n--- Menu After Removing Pizza ---");
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + menuItems[i]);
            }

            string dishToCheck = "Pasta";

            Console.WriteLine("\n--- Dish Availability Check ---");
            if (menuItems.Contains(dishToCheck))
            {
                Console.WriteLine(dishToCheck + " is available.");
            }
            else
            {
                Console.WriteLine(dishToCheck + " is not available.");
            }

            Console.WriteLine("\n--- Total Menu Items ---");
            Console.WriteLine("Total items on the menu: " + menuItems.Count);
        }


        static void Main(string[] args)
        {
            bool mainMenu = true;

            while (mainMenu)
            {
                Console.Clear();

                Console.WriteLine("======================================");
                Console.WriteLine("  List Practice  ");
                Console.WriteLine("======================================");
                Console.WriteLine("1) Problem 1: Room Service Menu");
                Console.WriteLine("2) Problem 2: Guest Check-In Queue");
                Console.WriteLine("3) Problem 3: Housekeeping Floor Assignment");
                Console.WriteLine("4) Problem 4: Hotel Booking Conflict Resolver");
                Console.WriteLine("0) Exit");
                Console.WriteLine("======================================");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (choice)
                {
                    case 1:
                       
                        break;

                    case 2:
                        
                        break;

                    case 3:
                      
                        break;

                    case 4:
                     
                        break;

                    case 0:
                        mainMenu = false;
                        Console.WriteLine("Program closed.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (mainMenu == true)
                {
                    Console.WriteLine("\nPress any key to go back to main menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}