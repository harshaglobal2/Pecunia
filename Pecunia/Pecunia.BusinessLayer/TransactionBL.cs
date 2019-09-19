using System;
using Pecunia.Exceptions;
using Pecunia.DataAccessLayer;
using System.Text.RegularExpressions;

namespace Pecunia.BusinessLayer
{
    public class TransactionsBL
    {
        public bool DebitTransactionByWithdrawalSlipBL(long AccountNo, double Amount)
        {
            // FD accountNo ranges from 30000 - 39999, Current accountNo ranges from 40000-49999, savings accountNo ranges from 50000-59999
            if ((AccountNo > 50000 && AccountNo < 59999) || (AccountNo > 40000 && AccountNo < 49999) || (AccountNo > 30000 && AccountNo < 39999) && Amount <= 50000)
            {
                TransactionDAL debit = new TransactionDAL();
                return debit.DebitTransactionByWithdrawalSlipDAL(AccountNo, Amount);
            }
            else
            {
                throw new DebitSlipException("Invalid Account No or Amount");
            }
        }
        public bool CreditTransactionByWithdrawalSlipBL(long AccountNo, Double Amount)
        {

            if ((AccountNo > 50000 && AccountNo < 59999) || (AccountNo > 40000 && AccountNo < 49999) || (AccountNo > 30000 && AccountNo < 39999) && Amount <= 50000)
            {
                TransactionDAL credit = new TransactionDAL();
                return credit.CreditTransactionByWithdrawalSlipDAL(AccountNo, Amount);
            }
            else
            {
                throw new CreditSlipException("Invalid Account No or Amount");
            }
        }
        public bool DebitTransactionByChequeBL(long AccountNo, double Amount, string ChequeNo)
        {

            if ((AccountNo > 50000 && AccountNo < 59999) || (AccountNo > 40000 && AccountNo < 49999) || (AccountNo > 30000 && AccountNo < 39999) && Amount <= 50000 && ChequeNo.Length == 10 && (Regex.IsMatch(ChequeNo, "[A-Z0-9]$") == true))
            {
                TransactionDAL Cheque = new TransactionDAL();
                return Cheque.DebitTransactionByChequeDAL(AccountNo, Amount, ChequeNo);
            }
            else
            {
                throw new DebitChequeException("Invalid Account Credentials or Amount");
            }

        }
        public bool CreditTransactionByChequeBL(long AccountNo, double Amount, string ChequeNo)
        {
            
            if ((AccountNo > 50000 && AccountNo < 59999) || (AccountNo > 40000 && AccountNo < 49999) || (AccountNo > 30000 && AccountNo < 39999) && Amount <= 50000 && ChequeNo.Length == 10 && (ValidateCheque(Ch) == true))
            {
                TransactionDAL Cheque = new TransactionDAL();
                return Cheque.CreditTransactionByChequeDAL(AccountNo, Amount, ChequeNo);
            }
            else
            {
                throw new CreditChequeException("Invalid Account Credentials or Amount");
            }
        }
        public void DisplayTransactionByCustomerID_DAL(string CustomerID)
        {
            if (Regex.IsMatch(CustomerID, "[0-9]{14}$") == true)
            {
                TransactionDAL trans = new TransactionDAL();
                trans.DisplayTransactionByCustomerID_DAL(CustomerID);
            }
            else
            {
                throw new TransactionDisplayIDException("Invalid ID");
            }
        }
        public void DisplayTransactionByAccountNoBL(long AccountNo)
        {
            if ((AccountNo > 50000 && AccountNo < 59999) || (AccountNo > 40000 && AccountNo < 49999) || (AccountNo > 30000 && AccountNo < 39999))
            {
                TransactionDAL acc = new TransactionDAL();
                acc.DisplayTransactionByAccountNo_DAL(AccountNo);
            }
            else
            {
                throw new TransactionDisplayAccountException("Invalid AccountNo");
            }
        }
        public void DisplayTransactionDetailsByTransactionID_DAL(string TransactionID)
        {
            if ()
            {
                return;
            }
            else
            {
                throw new TransactionDetailsException("Invalid Transaction ID");
            }
        }
        public bool ValidateCheque(string ChequeNo)
        {
            if (Regex.IsMatch(ChequeNo, "[0-9]{6}$")==true)
            {
                return true;
            }
            return false;
        }

    }
}
