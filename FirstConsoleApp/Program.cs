using System;

namespace ClinicManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // patient variable
            string patientName = "";
            int patientAge = 0;
            string patientPhone = "";
            int patientCount = 0;
            int MAX_PATIENTS = 2;

            // doctor variable
            string doctorName = "";
            string doctorSpec = "";
            int doctorCount = 0;
            int MAX_DOCTORS = 2;

            // appointment variable
            string appointmentDate = "";
            string appointmentTime = "";
            bool appointmentBooked = false;

            while (true)
            {
                Console.Clear();


                Console.WriteLine("===== CLINIC MANAGEMENT SYSTEM =====");
                Console.WriteLine("1) Patient Management");
                Console.WriteLine("2) Doctor Management");
                Console.WriteLine("3) Appointment Management");
                Console.WriteLine("0) Exit");

                Console.Write("Select option: ");
                int Mainchoice = int.Parse(Console.ReadLine());

                switch (Mainchoice)
                {
                    case 1: // first case for patients

                        bool patientMenu = true;

                        while (patientMenu)
                        {
                            Console.WriteLine("===== PATIENT MANAGEMENT =====");
                            Console.WriteLine("1) Add New Patient");
                            Console.WriteLine("2) Display Patient");
                            Console.WriteLine("3) Edit Patient Info");
                            Console.WriteLine("0) Back To Main Menu");
                            Console.Write("Enter your choice: ");

                            int patientChoice = int.Parse(Console.ReadLine());

                            switch (patientChoice)
                            {
                                case 1:
                                    if (patientCount == MAX_PATIENTS)
                                    {
                                        Console.WriteLine("Clinic is full. Cannot add more patients.");
                                    }
                                    else
                                    {
                                        Console.Write("Enter patient name: ");
                                        patientName = Console.ReadLine();

                                        Console.Write("Enter patient age: ");
                                        patientAge = int.Parse(Console.ReadLine());

                                        Console.Write("Enter patient phone: ");
                                        patientPhone = Console.ReadLine();

                                        patientCount++;

                                        Console.WriteLine("Patient added successfully.");
                                    }

                                    break;

                                case 2: //view all patents
                                    if (patientCount == 0)
                                    {
                                        Console.WriteLine("No patient added yet.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("===== PATIENT INFORMATION =====");
                                        Console.WriteLine("Patient Name: " + patientName);
                                        Console.WriteLine("Patient Age: " + patientAge);
                                        Console.WriteLine("Patient Phone: " + patientPhone);
                                    }

                                    break;

                                case 3: // update patient information by choosing from update menu

                                    if (patientCount == 0)
                                    {
                                        Console.WriteLine("No patient to edit.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("What do you want to update?");
                                        Console.WriteLine("1) Patient Name");
                                        Console.WriteLine("2) Patient Age");
                                        Console.WriteLine("3) Patient Phone");
                                        Console.WriteLine("4) Update All");
                                        Console.Write("Enter your choice: ");

                                        int updateChoice = int.Parse(Console.ReadLine());

                                        switch (updateChoice)
                                        {
                                            case 1://update name only
                                                Console.Write("Enter new patient name: ");
                                                patientName = Console.ReadLine();
                                                Console.WriteLine("Patient name updated successfully.");
                                                break;

                                            case 2://update age only
                                                Console.Write("Enter new patient age: ");
                                                patientAge = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Patient age updated successfully.");
                                                break;

                                            case 3://update phone only
                                                Console.Write("Enter new patient phone: ");
                                                patientPhone = Console.ReadLine();
                                                Console.WriteLine("Patient phone updated successfully.");
                                                break;

                                            case 4:// if you want to update all info
                                                Console.Write("Enter new patient name: ");
                                                patientName = Console.ReadLine();

                                                Console.Write("Enter new patient age: ");
                                                patientAge = int.Parse(Console.ReadLine());

                                                Console.Write("Enter new patient phone: ");
                                                patientPhone = Console.ReadLine();

                                                Console.WriteLine("All patient information updated successfully");
                                                break;

                                            default:
                                                Console.WriteLine("Invalid update choice.");
                                                break;
                                        }
                                    }
                                    break;

                                case 0:
                                    patientMenu = false;
                                    break;

                                default:
                                    Console.WriteLine("Invalid patient choice.");
                                    break;
                            }
                        }

                        break;

                    case 2: // second case for doctors

                  

                    case 3: // appointments

                     
                    case 0:
                        Console.WriteLine("Thank you for using Clinic Management System.");
                        break;

                    default:

                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}