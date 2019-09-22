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
        /// Menu for SystemUser
        /// </summary>
        /// <returns></returns>
        public static async Task<int> SystemUserMenu()
        {
            int choice = -2;

            do
            {
                //Menu
                WriteLine("\n***************SYSTEM USER***********");
                WriteLine("1. View Suppliers");
                WriteLine("2. Add Supplier");
                WriteLine("3. Update Supplier");
                WriteLine("4. Delete Supplier");
                WriteLine("-----------------------");
                WriteLine("5. View Distributors");
                WriteLine("6. Add Distributor");
                WriteLine("7. Update Distributor");
                WriteLine("8. Delete Distributor");
                WriteLine("-----------------------");
                WriteLine("9. Change Password");
                WriteLine("0. Logout");
                WriteLine("-1. Exit");
                Write("Choice: ");

                //Accept and check choice
                bool isValidChoice = int.TryParse(ReadLine(), out choice);
                if (isValidChoice)
                {
                    switch (choice)
                    {
                        case 1: await ViewSuppliers(); break;
                        case 2: await AddSupplier(); break;
                        case 3: await UpdateSupplier(); break;
                        case 4: await DeleteSupplier(); break;

                        case 5: await ViewDistributors(); break;
                        case 6: await AddDistributor(); break;
                        case 7: await UpdateDistributor(); break;
                        case 8: await DeleteDistributor(); break;

                        case 9: await ChangeSystemUserPassword(); break;
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
            return choice;
        }


        #region Supplier

        /// <summary>
        /// Displays list of Suppliers.
        /// </summary>
        /// <returns></returns>
        public static async Task ViewSuppliers()
        {
            try
            {
                using (ISupplierBL supplierBL = new SupplierBL())
                {
                    //Get and display list of system users.
                    List<Supplier> suppliers = await supplierBL.GetAllSuppliersBL();
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
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Adds Supplier.
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
                supplier.SupplierMobile = ReadLine();
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
        /// Updates Supplier.
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
        /// Delete Supplier.
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

        #endregion



        #region Distributor

        /// <summary>
        /// Displays list of Distributors.
        /// </summary>
        /// <returns></returns>
        public static async Task ViewDistributors()
        {
            try
            {
                using (IDistributorBL distributorBL = new DistributorBL())
                {
                    //Get and display list of system users.
                    List<Distributor> distributors = await distributorBL.GetAllDistributorsBL();
                    WriteLine("DISTRIBUTORS:");
                    if (distributors != null && distributors?.Count > 0)
                    {
                        WriteLine("#\tName\tMobile\tEmail\tCreated\tModified");
                        int serial = 0;
                        foreach (var distributor in distributors)
                        {
                            serial++;
                            WriteLine($"{serial}\t{distributor.DistributorName}\t{distributor.DistributorMobile}\t{distributor.Email}\t{distributor.CreationDateTime}\t{distributor.LastModifiedDateTime}");
                        }
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
        /// Adds Distributor.
        /// </summary>
        /// <returns></returns>
        public static async Task AddDistributor()
        {
            try
            {
                //Read inputs
                Distributor distributor = new Distributor();
                Write("Name: ");
                distributor.DistributorName = ReadLine();
                Write("Mobile: ");
                distributor.DistributorMobile = ReadLine();
                Write("Email: ");
                distributor.Email = ReadLine();
                Write("Password: ");
                distributor.Password = ReadLine();

                //Invoke AddDistributorBL method to add
                using (IDistributorBL distributorBL = new DistributorBL())
                {
                    bool isAdded = await distributorBL.AddDistributorBL(distributor);
                    if (isAdded)
                    {
                        WriteLine("Distributor Added");
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
        /// Updates Distributor.
        /// </summary>
        /// <returns></returns>
        public static async Task UpdateDistributor()
        {
            try
            {
                using (IDistributorBL distributorBL = new DistributorBL())
                {
                    //Read Sl.No
                    Write("Distributor #: ");
                    bool isNumberValid = int.TryParse(ReadLine(), out int serial);
                    if (isNumberValid)
                    {
                        serial--;
                        List<Distributor> distributors = await distributorBL.GetAllDistributorsBL();
                        if (serial <= distributors.Count - 1)
                        {
                            //Read inputs
                            Distributor distributor = distributors[serial];
                            Write("Name: ");
                            distributor.DistributorName = ReadLine();
                            Write("Mobile: ");
                            distributor.DistributorMobile = ReadLine();
                            Write("Email: ");
                            distributor.Email = ReadLine();

                            //Invoke UpdateDistributorBL method to update
                            bool isUpdated = await distributorBL.UpdateDistributorBL(distributor);
                            if (isUpdated)
                            {
                                WriteLine("Distributor Updated");
                            }
                        }
                        else
                        {
                            WriteLine($"Invalid Distributor #.\nPlease enter a number between 1 to {distributors.Count}");
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
        /// Delete Distributor.
        /// </summary>
        /// <returns></returns>
        public static async Task DeleteDistributor()
        {
            try
            {
                using (IDistributorBL distributorBL = new DistributorBL())
                {
                    //Read Sl.No
                    Write("Distributor #: ");
                    bool isNumberValid = int.TryParse(ReadLine(), out int serial);
                    if (isNumberValid)
                    {
                        serial--;
                        List<Distributor> distributors = await distributorBL.GetAllDistributorsBL();
                        if (serial <= distributors.Count - 1)
                        {
                            //Confirmation
                            Distributor distributor = distributors[serial];
                            Write("Are you sure? (Y/N): ");
                            string confirmation = ReadLine();

                            if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
                            {
                                //Invoke DeleteDistributorBL method to delete
                                bool isDeleted = await distributorBL.DeleteDistributorBL(distributor.DistributorID);
                                if (isDeleted)
                                {
                                    WriteLine("Distributor Deleted");
                                }
                            }
                        }
                        else
                        {
                            WriteLine($"Invalid Distributor #.\nPlease enter a number between 1 to {distributors.Count}");
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

        #endregion


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
                                WriteLine("Distributor Password Updated");
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


