using System;

namespace TS_DS_01
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
                Console.WriteLine("     TS-DS-01 ARRAYS PRACTICE");
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
                      
                        break;

                    case 2:
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