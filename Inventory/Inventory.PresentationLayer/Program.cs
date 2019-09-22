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
using Capgemini.Inventory.Contracts.BLContracts;

namespace Capgemini.Inventory.PresentationLayer
{
    class Program
    {
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            try
            {
                int internalChoice = -2;
                WriteLine("===============INVENTORY MANAGEMENT SYSTEM=========================");

                do
                {
                    //Invoke Login Screen
                    (UserType userType, IUser currentUser) = await ShowLoginScreen();

                    //Set current user details into CommonData (global data)
                    CommonData.CurrentUser = currentUser;
                    CommonData.CurrentUserType = userType;

                    //Invoke User's Menu
                    if (userType == UserType.Admin)
                    {
                        internalChoice = await AdminPresentation.AdminUserMenu();
                    }
                    else if (userType == UserType.SystemUser)
                    {
                        internalChoice = await SystemUserPresentation.SystemUserMenu();
                    }
                    else if (userType == UserType.Supplier)
                    {
                    }
                    else if (userType == UserType.Distributor)
                    {
                    }
                } while (internalChoice != -1);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                WriteLine(ex.Message);
            }

            WriteLine("Thank you!");
            ReadKey();
        }

        /// <summary>
        /// Login (based on Email and Password)
        /// </summary>
        /// <returns></returns>
        static async Task<(UserType, IUser)> ShowLoginScreen()
        {
            //Read inputs
            string email, password;
            WriteLine("=====LOGIN=========");
            Write("Email: ");
            email = ReadLine();
            Write("Password: ");
            password = ReadLine();

            using (IAdminBL adminBL = new AdminBL())
            {
                //Invoke GetAdminByEmailAndPasswordBL for checking email and password of Admin
                Admin admin = await adminBL.GetAdminByEmailAndPasswordBL(email, password);
                if (admin != null)
                {
                    return (UserType.Admin, admin);
                }
            }

            using (ISystemUserBL systemUserBL = new SystemUserBL())
            {
                //Invoke GetAdminByEmailAndPasswordBL for checking email and password of Admin
                SystemUser systemUser = await systemUserBL.GetSystemUserByEmailAndPasswordBL(email, password);
                if (systemUser != null)
                {
                    return (UserType.SystemUser, systemUser);
                }
            }

            WriteLine("Invalid Email or Password. Please try again...");
            return (UserType.Anonymous, null);
        }
    }
}



