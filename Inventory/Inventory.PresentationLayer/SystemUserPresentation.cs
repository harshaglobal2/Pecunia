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
    public static class SystemUserPresentation
    {
        /// <summary>
        /// Menu for SystemUser User
        /// </summary>
        /// <returns></returns>
        public static async Task<int> SystemUserMenu()
        {
            int choice = -2;
            using (ISupplierBL supplierBL = new SupplierBL())
            {
                do
                {
                    //Get and display list of system users.
                    List<Supplier> suppliers = await supplierBL.GetAllSuppliersBL();
                    WriteLine("\n***************SYSTEM USER***********\n");
                    WriteLine("SUPPLIERS:");
                    if (suppliers != null && suppliers?.Count > 0)
                    {
                        WriteLine("#\tName\tMobile\tEmail\tCreated\tModified");
                        int serial = 0;
                        foreach (var supplier in suppliers)
                        {
                            serial++;
                            WriteLine($"{serial}\t{supplier.SupplierName}\t{supplier.SupplierMobile}\t{supplier.Email}\t{supplier.CreationDateTime}\t{supplier.LastModifiedDateTime}");
                        }
                    }

                    //Menu
                    WriteLine("\n1. Add Supplier");
                    WriteLine("2. Update Supplier");
                    WriteLine("3. Delete Supplier");
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
                            case 1: await AddSupplier(); break;
                            case 2: await UpdateSupplier(); break;
                            case 3: await DeleteSupplier(); break;

                            case 4: await ChangeSystemUserPassword(); break;
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
        public static async Task AddSupplier()
        {
            try
            {
                //Read inputs
                Supplier supplier = new Supplier();
                Write("Name: ");
                supplier.SupplierName = ReadLine();
                Write("Mobile: ");
                supplier.SupplierMobile= ReadLine();
                Write("Email: ");
                supplier.Email = ReadLine();
                Write("Password: ");
                supplier.Password = ReadLine();

                //Invoke AddSupplierBL method to add
                using (ISupplierBL supplierBL = new SupplierBL())
                {
                    bool isAdded = await supplierBL.AddSupplierBL(supplier);
                    if (isAdded)
                    {
                        WriteLine("Supplier Added");
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
        public static async Task UpdateSupplier()
        {
            try
            {
                using (ISupplierBL supplierBL = new SupplierBL())
                {
                    //Read Sl.No
                    Write("Supplier #: ");
                    bool isNumberValid = int.TryParse(ReadLine(), out int serial);
                    if (isNumberValid)
                    {
                        serial--;
                        List<Supplier> suppliers = await supplierBL.GetAllSuppliersBL();
                        if (serial <= suppliers.Count - 1)
                        {
                            //Read inputs
                            Supplier supplier = suppliers[serial];
                            Write("Name: ");
                            supplier.SupplierName = ReadLine();
                            Write("Mobile: ");
                            supplier.SupplierMobile = ReadLine();
                            Write("Email: ");
                            supplier.Email = ReadLine();

                            //Invoke UpdateSupplierBL method to update
                            bool isUpdated = await supplierBL.UpdateSupplierBL(supplier);
                            if (isUpdated)
                            {
                                WriteLine("Supplier Updated");
                            }
                        }
                        else
                        {
                            WriteLine($"Invalid Supplier #.\nPlease enter a number between 1 to {suppliers.Count}");
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
        public static async Task DeleteSupplier()
        {
            try
            {
                using (ISupplierBL supplierBL = new SupplierBL())
                {
                    //Read Sl.No
                    Write("Supplier #: ");
                    bool isNumberValid = int.TryParse(ReadLine(), out int serial);
                    if (isNumberValid)
                    {
                        serial--;
                        List<Supplier> suppliers = await supplierBL.GetAllSuppliersBL();
                        if (serial <= suppliers.Count - 1)
                        {
                            //Confirmation
                            Supplier supplier = suppliers[serial];
                            Write("Are you sure? (Y/N): ");
                            string confirmation = ReadLine();

                            if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                //Invoke DeleteSupplierBL method to delete
                                bool isDeleted = await supplierBL.DeleteSupplierBL(supplier.SupplierID);
                                if (isDeleted)
                                {
                                    WriteLine("Supplier Deleted");
                                }
                            }
                        }
                        else
                        {
                            WriteLine($"Invalid Supplier #.\nPlease enter a number between 1 to {suppliers.Count}");
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
        /// Updates SystemUser's Password.
        /// </summary>
        /// <returns></returns>
        public static async Task ChangeSystemUserPassword()
        {
            try
            {
                using (ISystemUserBL systemUserBL = new SystemUserBL())
                {
                    //Read Current Password
                    Write("Current Password: ");
                    string currentPassword = ReadLine();

                    SystemUser existingSystemUser = await systemUserBL.GetSystemUserByEmailAndPasswordBL(CommonData.CurrentUser.Email, currentPassword);

                    if (existingSystemUser != null)
                    {
                        //Read inputs
                        Write("New Password: ");
                        string newPassword = ReadLine();
                        Write("Confirm Password: ");
                        string confirmPassword = ReadLine();

                        if (newPassword.Equals(confirmPassword))
                        {
                            existingSystemUser.Password = newPassword;

                            //Invoke UpdateSystemUserBL method to update
                            bool isUpdated = await systemUserBL.UpdateSystemUserPasswordBL(existingSystemUser);
                            if (isUpdated)
                            {
                                WriteLine("System User Password Updated");
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


