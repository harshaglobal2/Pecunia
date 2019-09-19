using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Entities;

namespace Pecunia.DataAccessLayer
{
    public interface ILoanDAL
    {
        bool ApplyLoanDAL<T>(T obj);
        T GetLoanStatusDAL<T>(string loanID);
        T GetLoanByCustomerID_DAL<T>(string customerID);
        T ApproveLoanDAL<T>(string loanID);
        T GetLoanByLoanID_DAL<T>(string loanID);
        
    }

    public class CarLoanDAL : ILoanDAL
    {
        public static List<CarLoan> CarLoans;
        public bool ApplyLoanDAL<CarLoan>(CarLoan obj)
        {
            return SerializeIntoJSON(obj, "CarLoans.txt");
        }

        public CarLoan ApproveLoanDAL<CarLoan>(string loanID)
        {
            CarLoan loan = GetLoanByLoanID_DAL<CarLoan>(loanID);

        }

        public CarLoan GetLoanByCustomerID_DAL<CarLoan>(string customerID)
        {
            throw new NotImplementedException();
        }

        public CarLoan GetLoanByLoanID_DAL<CarLoan>(string loanID)
        {
            throw new NotImplementedException();
        }

        public CarLoan GetLoanStatusDAL<CarLoan>(string loanID)
        {
            throw new NotImplementedException();
        }

        public bool SerializeIntoJSON(CarLoan obj, string filename)
        {
            return true;
        }

        public List<CarLoan> DeserializeFromJSON(string filename)
        {
            return CarLoans;
        }
    }

    public class HomeLoanDAL : ILoanDAL
    {
        public static List<HomeLoan> HomeLoans;

        public bool ApplyLoanDAL<HomeLoan>(HomeLoan obj)
        {
            throw new NotImplementedException();
        }

        public HomeLoan ApproveLoanDAL<HomeLoan>(string loanID)
        {
            throw new NotImplementedException();
        }

        public HomeLoan GetLoanByCustomerID_DAL<HomeLoan>(string customerID)
        {
            throw new NotImplementedException();
        }

        public HomeLoan GetLoanByLoanID_DAL<HomeLoan>(string loanID)
        {
            throw new NotImplementedException();
        }

        public HomeLoan GetLoanStatusDAL<HomeLoan>(string loanID)
        {
            throw new NotImplementedException();
        }
    }

    public class EduLoanDAL : ILoanDAL
    {
        public static List<EduLoan> EduLoans;

        public bool ApplyLoanDAL<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public EduLoan ApproveLoanDAL<EduLoan>(string loanID)
        {
            throw new NotImplementedException();
        }

        public EduLoan GetLoanByCustomerID_DAL<EduLoan>(string customerID)
        {
            throw new NotImplementedException();
        }

        public T GetLoanByLoanID_DAL<T>(string loanID)
        {
            throw new NotImplementedException();
        }

        public EduLoan GetLoanStatusDAL<EduLoan>(string loanID)
        {
            throw new NotImplementedException();
        }
    }
    /*
    public class LoanDAL
    {
        static List<LoanEntities> Loans = new List<LoanEntities>();
        public bool ApplyLoanDAL(LoanEntities loan)
        {
            try
            {
                
                DateTime time = DateTime.Now;
                string currentTime = time.ToString("yyyyMMddhhmmss");

                if ((int)loan.Type == 0)
                {//eduloan
                    loan.LoanID = "EDU" + currentTime; //string concatenation loanID sample : EDULOAN20190912101552
                    loan.InterestRate = 10;
                }
                else if ((int)loan.Type == 1)
                { //homeloan
                    loan.LoanID = "HOME" + currentTime; //string concatenation loanID sample : HOMELOAN20190912101552
                    loan.InterestRate = 10.85;
                }
                else//car loan
                {
                    loan.LoanID = "CAR" + currentTime; //string concatenation loanID sample : CARLOAN20190912101552
                    loan.InterestRate = 8;
                }
                
                loan.DateOfApplication = time;
                loan.Status = (LoanStatus)Enum.Parse(typeof(LoanStatus), "APPLIED");

                Loans.Add(loan);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool GetLoanStatusDAL(string loanID)
        {
            try
            {
                foreach (LoanEntities loan in Loans)
                {
                    if (loan.LoanID.Equals(loanID))
                    {
                        Console.WriteLine(loan.Status);
                        break;
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////
        public LoanEntities GetLoanByCustomerID_DAL(string customerID)
        {
            foreach(LoanEntities loan in Loans)
            {
                if (loan.CustomerID.Equals(customerID) == true)
                    return loan;
            }

            //// if not found return a null object
            LoanEntities emptyObj = new LoanEntities();
            return emptyObj;
        }

        ////////////////////////////////////////////////////////////////////////////////
        public LoanEntities GetLoanByLoanID_DAL(string loanID)
        {
            foreach (LoanEntities loan in Loans)
            {
                if (loan.LoanID.Equals(loanID) == true)
                    return loan;
            }

            //// if not found return a null object
            LoanEntities emptyObj = new LoanEntities();
            return emptyObj;
        }

        ////////////////////////////////////////////////////////////////////////////////
        public void ApproveLoanDAL(string loanID)
        {
            try
            {
                foreach (LoanEntities loan in Loans)
                {
                    if (loan.LoanID.Equals(loanID))
                    {
                        Console.WriteLine("Current status of loan is as follows : ");
                        Console.WriteLine("Cusotmer ID : " + loan.CustomerID);
                        Console.WriteLine("Income : " + loan.Income);
                        Console.WriteLine("Amount Applied : " + loan.AmountApplied);
                        Console.WriteLine("Interest Rate : " + loan.InterestRate);
                        Console.WriteLine("Applied EMI : " + loan.EMI);
                        Console.WriteLine("Tenure : " + loan.Tenure);
                        Console.WriteLine("Date of application : " + loan.DateOfApplication);
                        Console.WriteLine("Types : " + loan.Type);
                        Console.WriteLine("Current Status : " + loan.Status);

                        Console.WriteLine("Enter modified status");
                        string modStatus = Console.ReadLine();
                        LoanStatus modStatusEnum;
                        bool isValid = Enum.TryParse(modStatus, out modStatusEnum);
                        if (isValid == true)
                            loan.Status = modStatusEnum;
                        else
                            Console.WriteLine("Not a valid loan status!");
                        break;
                    }
                }
            }
            catch(Exception e)
            {

            }
            
                
        }
    }
    */
}
                   