using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Entities;
using Pecunia.Exceptions;

namespace Pecunia.DataAccessLayer
{
    public class AccountDAL
    {
        public static List<Account> ListOfAccounts = new List<Account>();
        public static List<Account> ClosedAccounts = new List<Account>();
        //----------------------------------------------------------------------------------------------1)
        public bool AddAccountDAL(Account a)
        {
            ListOfAccounts.Add(a);
            return true;


        }
        //---------------------------------------------------------------------------------------------2)
        public bool DeleteAccountDAL(long AccountNo)
        {
            bool res = false;
            int count = 0;
            foreach (Account i in ListOfAccounts)
            {
                if (i.AccountNo == AccountNo)
                {
                    Console.WriteLine("Enter Your FeedBack");
                    i.Feedback = Console.ReadLine();
                    ClosedAccounts.Add(i);
                    ListOfAccounts.Remove(i);
                    res = true;
                    count++;
                    break;
                }
            }
            if (count != 1)
            {
                Console.WriteLine("Enter Valid Account Number");
            }
            return res;
        }
        //-------------------------------------------------------------------------------3)
        public Account GetAccountByCustomerID_DAL(String CustomerID)
        {

            int count = 0;
            Account a = new Account();
            foreach (Account i in ListOfAccounts)
            {
                if (i.CustomerID == CustomerID)
                {
                    count++;
                    a = i;
                    break;
                }
            }
            if (count != 1)
            {
                throw new CustomerDoesNotExistException("Customer Does not have account");
            }
            return a;
        }
        //----------------------------------------------------------------------------------------4)
        public Account GetAccountByAccountNo_DAL(long AccountNo)
        {

            int count = 0;
            Account a = new Account();
            try
            {
                foreach (Account i in ListOfAccounts)
                {
                    if (i.AccountNo == AccountNo)
                    {
                        count++;
                        a = i;
                        break;
                    }
                }
                if (count != 1)
                {
                    throw new CustomerDoesNotExistException("Customer Does not have account");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return a;
        }

        //----------------------------------------------------------------------------------------5)
        public bool ChangeAccountType_DAL(long AccNo)
        {
            bool res = false;
            try
            {
                foreach (Account i in ListOfAccounts)
                {

                    if (i.AccountNo == AccNo)
                    {
                        Console.WriteLine("ENter Account Type");
                        if ((Enum.TryParse(Console.ReadLine(), out i._accType)) == false)
                        {
                            throw new EnterValidAccountTypeException("Enter Valid Account Type");
                        }
                        else
                        {
                            res = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return res;
        }

        //-----------------------------------------------------------------------------------------6)
        public bool ChangeBranch_DAL(String CustomerID)
        {
            bool res = false;
            int count = 0;
            foreach (Account i in ListOfAccounts)
            {
                if (i.CustomerID == CustomerID)
                {
                    Console.WriteLine("ENter Home Branch");
                    i.HomeBranch = Console.ReadLine();
                    res = true;
                    count++;
                    break;
                }
            }
            if (count != 1)
            {
                throw new AccountDoesNotExistException("Account does not exist for ");
            }
            return res;
        }

        //----------------------------------------------------------------------------------------7)
        public List<Account> GetAllAccountsDAL()
        {
            return ListOfAccounts;

        }

        public bool UpdateFDAmount_DAL(long AccountNo)
        {
            bool res = false;
            int count = 0;
            foreach (Account a in ListOfAccounts)
            {
                if (a.AccountNo == AccountNo)
                {
                    try
                    {
                        res = true;
                        count++;
                        Console.WriteLine("Enter New FD Amount");
                        long temp = long.Parse(Console.ReadLine());
                        if (temp < 20000)
                        {
                            throw new InitialAmountOfFDException("Amount should be Atleast 20000");
                        }
                        else
                        {
                            a.FdDeposit = temp;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                    break;
                }
            }
            if (count != 1)
            {
                Console.WriteLine("ENter Valid Account Number");
            }
            return res;
        }

    }
}
