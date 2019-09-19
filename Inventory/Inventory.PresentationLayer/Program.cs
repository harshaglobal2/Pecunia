using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Capgemini.Inventory.BusinessLayer;
using Capgemini.Inventory.Exceptions;
using Capgemini.Inventory.Helpers;
using Capgemini.Inventory.Entities;

namespace Capgemini.Inventory.PresentationLayer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                UserType userType = ShowLoginScreen();
                if (userType == UserType.Admin)
                {
                    await AdminUserMenu();
                }
                else if (userType == UserType.SystemUser)
                {
                }
                else if (userType == UserType.Supplier)
                {
                }
                else if (userType == UserType.Distributor)
                {
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                WriteLine(ex.Message);
            }

            WriteLine("Thank you!");
            ReadKey();
        }

        static UserType ShowLoginScreen()
        {
            string email, password;
            WriteLine("===============INVENTORY MANAGEMENT SYSTEM=========================");
            Write("Email: ");
            email = ReadLine();
            Write("Password: ");
            password = ReadLine();

            if (email.Equals("admin@capgemini.com") && password.Equals("manager"))
            {
                return UserType.Admin;
            }
            return UserType.Anonymous;
        }

        static async Task AdminUserMenu()
        {
            using (SystemUserBL systemUserBL = new SystemUserBL())
            {
                int choice = -1;

                do
                {
                    List<SystemUser> systemUsers = systemUserBL.GetAllSystemUsersBL();
                    WriteLine("\n***************ADMIN***********\n");
                    WriteLine("SYSTEM USERS:");
                    if (systemUsers != null && systemUsers?.Count > 0)
                    {
                        WriteLine("Name\tEmail\tCreated\tModified");
                        foreach (var systemUser in systemUsers)
                        {
                            WriteLine($"{systemUser.SystemUserName}\t{systemUser.SystemUserEmail}\t{systemUser.CreationDateTime}\t{systemUser.LastModifiedDateTime}");
                        }
                    }
                    WriteLine("\n1. Add System User");
                    WriteLine("2. Update System User");
                    WriteLine("3. Delete System User");
                    WriteLine("0. Exit");
                    Write("Choice: ");
                    bool isValidChoice = int.TryParse(Console.ReadLine(), out choice);
                    if (isValidChoice)
                    {
                        switch (choice)
                        {
                            case 1: await AddSystemUser(); break;
                            //case 2: UpdateSystemUser(); break;
                            //case 3: DeleteSystemUser(); break;
                            case 0: break;
                            default: WriteLine("Invalid Choice"); break;
                        }
                    }
                    else
                    {
                        choice = -1;
                    }
                } while (choice != 0);
            }
        }

        static async Task AddSystemUser()
        {
            try
            {
                SystemUser systemUser = new SystemUser();
                Write("Name: ");
                systemUser.SystemUserName = ReadLine();
                Write("Email: ");
                systemUser.SystemUserEmail = ReadLine();
                Write("Password: ");
                systemUser.SystemUserPassword = ReadLine();
                using (SystemUserBL systemUserBL = new SystemUserBL())
                {
                    bool isAdded = await systemUserBL.AddSystemUserBL(systemUser);
                    if (isAdded)
                    {
                        WriteLine("System User Added");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                WriteLine(ex.Message);
            }
        }
    }
}


