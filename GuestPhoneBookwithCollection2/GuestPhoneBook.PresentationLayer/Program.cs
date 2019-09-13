using System;
using System.Collections.Generic;
using System.Text;
using GuestPhoneBook.Entities;
using GuestPhoneBook.BusinessLayer;
using GuestPhoneBook.Exceptions;

namespace GuestPhoneBook.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                PrintMenu();
                Console.WriteLine("Enter your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddGuest();
                        break;
                    case 2:
                        ListAllGuests();
                        break;
                    case 3:
                        SearchGuestByID();
                        break;
                    case 4:
                        UpdateGuest();
                        break;
                    case 5:
                        DeleteGuest();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != -1);
        }

        private static void DeleteGuest()
        {
            try
            {
                int deleteGuestID;
                Console.WriteLine("Enter GuestID to Delete:");
                deleteGuestID = Convert.ToInt32(Console.ReadLine());
                Guest deleteGuest = GuestBL.SearchGuestBL(deleteGuestID);
                if (deleteGuest != null)
                {
                    bool guestdeleted = GuestBL.DeleteGuestBL(deleteGuestID);
                    if (guestdeleted)
                        Console.WriteLine("Guest Deleted");
                    else
                        Console.WriteLine("Guest not Deleted ");     
                }
                else
                {
                    Console.WriteLine("No Guest Details Available");
                }


            }
            catch (GuestPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateGuest()
        {
            try
            {
                int updateGuestID;
                Console.WriteLine("Enter GuestID to Update Details:");
                updateGuestID = Convert.ToInt32(Console.ReadLine());
                Guest updatedGuest = GuestBL.SearchGuestBL(updateGuestID);
                if (updatedGuest != null)
                {
                    Console.WriteLine("Update Guest Name :");
                    updatedGuest.GuestName = Console.ReadLine();
                    Console.WriteLine("Update PhoneNumber :");
                    updatedGuest.GuestContactNumber = Console.ReadLine();
                    bool guestUpdated = GuestBL.UpdateGuestBL(updatedGuest);
                    if (guestUpdated)
                        Console.WriteLine("Guest Details Updated");
                    else
                        Console.WriteLine("Guest Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No Guest Details Available");
                }
               

            }
            catch (GuestPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SearchGuestByID()
        {
            try
            {
                int searchGuestID;
                Console.WriteLine("Enter GuestID to Search:");
                searchGuestID = Convert.ToInt32(Console.ReadLine());
                Guest searchGuest = GuestBL.SearchGuestBL(searchGuestID);
                if (searchGuest != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("GuestID\t\tName\t\tPhoneNumber");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", searchGuest.GuestID, searchGuest.GuestName, searchGuest.GuestContactNumber);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Guest Details Available");
                }

            }
            catch (GuestPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void ListAllGuests()
        {
            try
            {
                List<Guest> guestList = GuestBL.GetAllGuestsBL();
                if (guestList != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("GuestID\t\tName\t\tPhoneNumber");
                    Console.WriteLine("******************************************************************************");
                    foreach (Guest guest in guestList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}", guest.GuestID, guest.GuestName, guest.GuestContactNumber);
                    }
                    Console.WriteLine("******************************************************************************");

                }
                else
                {
                    Console.WriteLine("No Guest Details Available");
                }
            }
            catch (GuestPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddGuest()
        {
            try
            {
                Guest newGuest = new Guest();
                Console.WriteLine("Enter GuestID :");
                newGuest.GuestID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Guest Name :");
                newGuest.GuestName = Console.ReadLine();
                Console.WriteLine("Enter PhoneNumber :");
                newGuest.GuestContactNumber = Console.ReadLine();
                bool guestAdded = GuestBL.AddGuestBL(newGuest);
                if (guestAdded)
                    Console.WriteLine("Guest Added");
                else
                    Console.WriteLine("Guest not Added");
            }
            catch (GuestPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\n***********Guest PhoneBook Menu***********");
            Console.WriteLine("1. Add Guest");
            Console.WriteLine("2. List All Guests");
            Console.WriteLine("3. Search Guest by ID");
            Console.WriteLine("4. Update Guest");
            Console.WriteLine("5. Delete Guest");
            Console.WriteLine("6. Exit");
            Console.WriteLine("******************************************\n");

        }
    }
}
