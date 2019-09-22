using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;
using Capgemini.Inventory.BusinessLayer;
using Capgemini.Inventory.Entities;
using Capgemini.Inventory.Exceptions;
using Capgemini.Inventory.Contracts.BLContracts;

namespace Capgemini.Inventory.PresentationLayer
{
    public static class AdminPresentation
    {
        /// <summary>
        /// Menu for Admin User
        /// </summary>
        /// <returns></returns>
        public static async Task<int> AdminUserMenu()
        {
            int choice = -2;
            using (ISystemUserBL systemUserBL = new SystemUserBL())
            {
                do
                {
                    //Get and display list of system users.
                    List<SystemUser> systemUsers = await systemUserBL.GetAllSystemUsersBL();
                    WriteLine("\n***************ADMIN***********\n");
                    WriteLine("SYSTEM USERS:");
                    if (systemUsers != null && systemUsers?.Count > 0)
                    {
                        WriteLine("#\tName\tEmail\tCreated\tModified");
                        int serial = 0;
                        foreach (var systemUser in systemUsers)
                        {
                            serial++;
                            WriteLine($"{serial}\t{systemUser.SystemUserName}\t{systemUser.Email}\t{systemUser.CreationDateTime}\t{systemUser.LastModifiedDateTime}");
                        }
                    }

                    //Menu
                    WriteLine("\n1. Add System User");
                    WriteLine("2. Update System User");
                    WriteLine("3. Delete System User");
                    WriteLine("-----------------------");
                    WriteLine("4. Change Password");
                    WriteLine("0. Logout");
                    WriteLine("-1. Exit");
                    Write("Choice: ");

                    //Accept and check choice
                    bool isValidChoice = int.TryParse(ReadLine(), out choice);
                    if (isValidChoice)
                    {
                        switch (choice)
                        {
                            case 1: await AddSystemUser(); break;
                            case 2: await UpdateSystemUser(); break;
                            case 3: await DeleteSystemUser(); break;

                            case 4: await ChangeAdminPassword(); break;
                            case 0: break;
                            case -1: break;
                            default: WriteLine("Invalid Choice"); break;
                        }
                    }
                    else
                    {
                        choice = -2;
                    }
                } while (choice != 0 && choice != -1);
            }
            return choice;
        }

        /// <summary>
        /// Adds System User.
        /// </summary>
        /// <returns></returns>
        public static async Task AddSystemUser()
        {
            try
            {
                //Read inputs
                SystemUser systemUser = new SystemUser();
                Write("Name: ");
                systemUser.SystemUserName = ReadLine();
                Write("Email: ");
                systemUser.Email = ReadLine();
                Write("Password: ");
                systemUser.Password = ReadLine();

                //Invoke AddSystemUserBL method to add
                using (ISystemUserBL systemUserBL = new SystemUserBL())
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

        /// <summary>
        /// Updates System User.
        /// </summary>
        /// <returns></returns>
        public static async Task UpdateSystemUser()
        {
            try
            {
                using (ISystemUserBL systemUserBL = new SystemUserBL())
                {
                    //Read Sl.No
                    Write("System User #: ");
                    bool isNumberValid = int.TryParse(ReadLine(), out int serial);
                    if (isNumberValid)
                    {
                        serial--;
                        List<SystemUser> systemUsers = await systemUserBL.GetAllSystemUsersBL();
                        if (serial <= systemUsers.Count - 1)
                        {
                            //Read inputs
                            SystemUser systemUser = systemUsers[serial];
                            Write("Name: ");
                            systemUser.SystemUserName = ReadLine();
                            Write("Email: ");
                            systemUser.Email = ReadLine();

                            //Invoke UpdateSystemUserBL method to update
                            bool isUpdated = await systemUserBL.UpdateSystemUserBL(systemUser);
                            if (isUpdated)
                            {
                                WriteLine("System User Updated");
                            }
                        }
                        else
                        {
                            WriteLine($"Invalid System User #.\nPlease enter a number between 1 to {systemUsers.Count}");
                        }
                    }
                    else
                    {
                        WriteLine($"Invalid number.");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Delete System User.
        /// </summary>
        /// <returns></returns>
        public static async Task DeleteSystemUser()
        {
            try
            {
                using (ISystemUserBL systemUserBL = new SystemUserBL())
                {
                    //Read Sl.No
                    Write("System User #: ");
                    bool isNumberValid = int.TryParse(ReadLine(), out int serial);
                    if (isNumberValid)
                    {
                        serial--;
                        List<SystemUser> systemUsers = await systemUserBL.GetAllSystemUsersBL();
                        if (serial <= systemUsers.Count - 1)
                        {
                            //Confirmation
                            SystemUser systemUser = systemUsers[serial];
                            Write("Are you sure? (Y/N): ");
                            string confirmation = ReadLine();

                            if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                //Invoke DeleteSystemUserBL method to delete
                                bool isDeleted = await systemUserBL.DeleteSystemUserBL(systemUser.SystemUserID);
                                if (isDeleted)
                                {
                                    WriteLine("System User Deleted");
                                }
                            }
                        }
                        else
                        {
                            WriteLine($"Invalid System User #.\nPlease enter a number between 1 to {systemUsers.Count}");
                        }
                    }
                    else
                    {
                        WriteLine($"Invalid number.");
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Updates Admin's Password.
        /// </summary>
        /// <returns></returns>
        public static async Task ChangeAdminPassword()
        {
            try
            {
                using (IAdminBL adminBL = new AdminBL())
                {
                    //Read Current Password
                    Write("Current Password: ");
                    string currentPassword = ReadLine();

                    Admin existingAdmin = await adminBL.GetAdminByEmailAndPasswordBL(CommonData.CurrentUser.Email, currentPassword);

                    if (existingAdmin != null)
                    {
                        //Read inputs
                        Write("New Password: ");
                        string newPassword = ReadLine();
                        Write("Confirm Password: ");
                        string confirmPassword = ReadLine();

                        if (newPassword.Equals(confirmPassword))
                        {
                            existingAdmin.Password = newPassword;

                            //Invoke UpdateSystemUserBL method to update
                            bool isUpdated = await adminBL.UpdateAdminPasswordBL(existingAdmin);
                            if (isUpdated)
                            {
                                WriteLine("Admin Password Updated");
                            }
                        }
                        else
                        {
                            WriteLine($"New Password and Confirm Password doesn't match");
                        }
                    }
                    else
                    {
                        WriteLine($"Current Password doesn't match.");
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


