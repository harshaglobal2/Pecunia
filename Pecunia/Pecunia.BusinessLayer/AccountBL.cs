using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Entities;
using Pecunia.Exceptions;
using Pecunia.DataAccessLayer;
using System.Text.RegularExpressions;

namespace Pecunia.BusinessLayer
{
    public class AccountBL
    {
        static List<long> AccnogenSavings = new List<long>()
        {

        };
        static List<long> AccnogenCurrent = new List<long>()
        {

        };

        static List<long> AccnogenFD = new List<long>()
        {

        };
        //---------------------------------------------------------------------------------------------------------------------1)
        public bool AddAccountBL()
        {
            bool result = false;
            Account account = new Account();

            //AddCustomer(); //  First we will make him a customer in Customer if he already exists then skip this step
            Console.WriteLine("Choose Account Type(Savings, Current,FD)");
            if ((Enum.TryParse(Console.ReadLine(), out account._accType) == true))
            {

            }
            else
            {
                throw new EnterValidAccountTypeException("Enter Valid Account Type");
            }
            Console.WriteLine("Choose Your Home Branch");
            account.HomeBranch = Console.ReadLine();

            Console.WriteLine("Enter Initial Amount(For FD minimum 20,000)");
            double temp = double.Parse(Console.ReadLine());
            if ((int)account._accType == 2 && temp < 20000)
            {
                throw new InitialAmountOfFDException("Amount should be Atleast 20000");
            }
            else if ((int)account._accType == 2 && temp > 20000)
            {
                account.FdDeposit = temp;
            }
            else
            {
                account.InitialAmount = temp;
                account.Balance = account.Balance + account.InitialAmount;

            }
            if ((int)account._accType == 0)
            {
                account.InterestRate = 5;
                if (AccnogenSavings.Count == 0)            // If list empty then only

                {
                    account.AccountNo = 500001;            // Account No of Savings Account Starts with 5 series
                    AccnogenSavings.Add(account.AccountNo);
                }
                else
                {
                    int i = AccnogenSavings.Count;
                    account.AccountNo = (AccnogenSavings[i - 1] + 1); // Add the existing list number + 1 (eg 500001 +1)
                }

            }

            else if ((int)account._accType == 1)
            {

                account.InterestRate = 0;
                if (AccnogenCurrent.Count == 0)

                {
                    account.AccountNo = 400001;                 // Account No of Current Account Starts with 4 series
                    AccnogenCurrent.Add(account.AccountNo);
                }

                else
                {
                    int i = AccnogenCurrent.Count;
                    account.AccountNo = (AccnogenCurrent[i - 1] + 1);
                }
            }

            else
            {
                if (account.InitialAmount > 100000)
                {
                    account.InterestRate = 5.5;
                }

                if (account.InitialAmount < 100000)
                {
                    account.InterestRate = 5;
                }


                if (AccnogenFD.Count == 0)

                {
                    account.AccountNo = 300001;                      // Account No of FD Account Starts with 3 series
                    AccnogenFD.Add(account.AccountNo);
                }

                else
                {
                    int i = AccnogenFD.Count;
                    account.AccountNo = (AccnogenFD[i - 1] + 1);
                }

            }

            AccountDAL ad = new AccountDAL();
            result = ad.AddAccountDAL(account); // After adding Method


            return result;

        }
        //----------------------------------------------------------------------------------------
        public bool ValidateAccNo(long AcNo)
        {
            bool res = false;
            if ((AcNo > 500000 && AcNo < 599999) || (AcNo > 400000 && AcNo < 499999) || (AcNo > 300000 && AcNo < 399999))
            {
                res = true;
            }
            else
            {
                // Throw Exception
            }
            return res;
        }
        //------------------------------------------------------------------------------------------2)
        public bool DeleteAccount(long AccountNo)
        {
            bool result = false;
            if (ValidateAccNo(AccountNo))
            {
                AccountDAL a = new AccountDAL();
                result = a.DeleteAccountDAL(AccountNo);
            }



            return result;
        }
        //----------------------------------------------------------------------------------------
        bool ValidateCustID(string CID)
        {
            bool res = true;
            if (Regex.IsMatch(CID, "[0-9]{14}$") == false)
            {
                throw new InvalidStringException("Customer ID must be of 14 Digits");

            }
            return res;
        }
        //----------------------------------------------------------------------------------------3)
        public Account GetAccountByCustomerID_BL(string CustomerID)
        {
            if (ValidateCustID(CustomerID))
            {
                AccountDAL a = new AccountDAL();
                return a.GetAccountByCustomerID_DAL(CustomerID);
            }
            else
            {
                throw new EnterValidCustomerIDException("ENter Valid Customer ID");

            }


        }
        //-----------------------------------------------------------------------------------------
        public Account GetAccountByAccountNo_BL(long AccountNo)
        {
            if (ValidateAccNo(AccountNo))
            {
                AccountDAL a = new AccountDAL();
                return a.GetAccountByAccountNo_DAL(AccountNo);
            }
            else
            {
                throw new EnterValidCustomerIDException("ENter Valid Customer ID");

            }


        }

        //----------------------------------------------------------------------------------------4)
        public bool ChangeAccountType_BL(long AccNo)
        {
            bool res = false;
            if (ValidateAccNo(AccNo))
            {
                AccountDAL a = new AccountDAL();

                res = a.ChangeAccountType_DAL(AccNo);
            }
            return res;
        }

        //---------------------------------------------------------------------------------------5)
        public bool ChangeBranch_BL(String CustomerID)     // Change Branch
        {
            bool res = false;
            if (ValidateCustID(CustomerID))
            {
                AccountDAL a = new AccountDAL();
                res = a.ChangeBranch_DAL(CustomerID);
            }
            return res;
        }

        //--------------------------------------------------------------------------------------6)

        public List<Account> GetAllAccountsBL()
        {
            AccountDAL a = new AccountDAL();
            return a.GetAllAccountsDAL();
        }

        //-------------------------------------------------------------------------------------7)

        public bool UpdateFDAmount_BL(long AccountNo)
        {
            bool res = false;
            if (ValidateAccNo(AccountNo))
            {
                if (ValidateAccNo(AccountNo))
                {
                    AccountDAL a = new AccountDAL();
                    res = a.UpdateFDAmount_DAL(AccountNo);

                }
            }
            return res;
        }


    }
}
