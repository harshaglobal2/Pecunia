using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Entities;
using Pecunia.DataAccessLayer;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Pecunia.DataAccessLayer
{
    public abstract class TransactionDALAbstract
    {
        public abstract void StoreTransaction(long accountNo, double Amount, TypeOfTranscation type, string mode, string chequeNo);
        public abstract bool DebitTransactionByWithdrawalSlipDAL(long AccountNo, double Amount);
        public abstract bool CreditTransactionByWithdrawalSlipDAL(long AccountNo, double Amount);
        public abstract bool DebitTransactionByChequeDAL(long AccountNo, double Amount, string ChequeNo);
        public abstract bool CreditTransactionByChequeDAL(long AccountNo, double Amount, string ChequeNo);
        public abstract TransactionEntities DisplayTransactionByCustomerID_DAL(string CustomerID);
        public abstract TransactionEntities DisplayTransactionByAccountNo_DAL(long AccountNo);
        public abstract TransactionEntities DisplayTransactionDetailsByTransactionID_DAL(string TransactionID);
        public abstract void Serialize();
        public abstract void DeSerialize();

    }
    [Serializable]
    public class TransactionDAL: TransactionDALAbstract
    {
        
        public static List<TransactionEntities> Transactions = new List<TransactionEntities>() { };
        public List<TransactionEntities> TransactionsToSerialize = new List<TransactionEntities>() { };
        private string filepath = "transactions.dat";
        public override void StoreTransaction(long accountNo, double Amount, TypeOfTranscation type, string mode, string chequeNo)
        {
            //// retrieving customerID based on account No
            string customerID = "00000000000000";// dummy initialization to avoid warnings
            foreach(Account acc in AccountDAL.ListOfAccounts)
            {
                    if (acc.AccountNo == accountNo)
                        customerID = acc.CustomerID;
            }

            DateTime time = DateTime.Now;
            string transactionID = "TRANS" + time.ToString("yyyyMMddhhmmss");//sample transactionID : TRANS20190921154525

            TransactionEntities trans = new TransactionEntities();
            trans.AccountNo = accountNo;
            trans.CustomerID = customerID;
            trans.Type = type;
            trans.Amount = Amount;
            trans.TransactionID = transactionID;
            trans.DateOfTransaction = time;
            trans.Mode = mode;
            trans.ChequeNo = chequeNo;

            Transactions.Add(trans);
        }

        public override bool DebitTransactionByWithdrawalSlipDAL(long AccountNo, double Amount)
        {
            bool res = false;
            foreach (Account acc in AccountDAL.ListOfAccounts)
            {
                if (acc.AccountNo == AccountNo)
                {
                    acc.Balance = acc.Balance - Amount;
                    TypeOfTranscation transEnum;
                    Enum.TryParse("Debit", out transEnum);
                    StoreTransaction(AccountNo, Amount, transEnum ,"WithdrawalSlip", null);
                    res = true;
                    break;
                
                }

            }
            if (res == true)
            {
                Console.WriteLine("Succesfully Debited");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Account Number");
                return false;
            }
        }

        public override bool CreditTransactionByWithdrawalSlipDAL(long AccountNo, double Amount)
        {
            bool res = false;
            foreach (Account acc in AccountDAL.ListOfAccounts)
            {
                if (acc.AccountNo == AccountNo)
                {
                    acc.Balance = acc.Balance + Amount;
                    TypeOfTranscation transEnum;
                    Enum.TryParse("Credit", out transEnum);
                    StoreTransaction(AccountNo, Amount, transEnum, "WithdrawalSlip", null);
                    res=true;
                    break;
                }

            }
            if (res == true)
            {
                Console.WriteLine("Succesfully Credited");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Account Number");
                return false;
            }
        }

        public override bool DebitTransactionByChequeDAL(long AccountNo, double Amount, string ChequeNo)
        {
            bool res = false;
            foreach (Account acc in AccountDAL.ListOfAccounts)
            {
                if (acc.AccountNo == AccountNo)
                {
                    acc.Balance = acc.Balance - Amount;
                    TypeOfTranscation transEnum;
                    Enum.TryParse("Debit", out transEnum);
                    StoreTransaction(AccountNo, Amount, transEnum, "Cheque", ChequeNo);
                    res = true;
                    break;
                }

            }
            if (res == true)
            {
                Console.WriteLine("Succesfully Debited");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Account Number or Cheque");
                return false;
            }
        }

        public override bool CreditTransactionByChequeDAL(long AccountNo, double Amount, string ChequeNo)
        {
            
            bool res = false;
            foreach (Account acc in AccountDAL.ListOfAccounts)
            {
                if (acc.AccountNo == AccountNo)
                {
                    acc.Balance = acc.Balance + Amount;
                    TypeOfTranscation transEnum;
                    Enum.TryParse("Credit", out transEnum);
                    StoreTransaction(AccountNo, Amount, transEnum, "Cheque", ChequeNo);
                    res = true;
                    break;
                }

            }
            if (res == true)
            {
                Console.WriteLine("Succesfully Credited");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Account Number or Cheque");
                return false;
            }
        }

        public override TransactionEntities DisplayTransactionByCustomerID_DAL(string CustomerID)
        {
            foreach (TransactionEntities trans in Transactions)
            {
                if (trans.CustomerID == CustomerID)
                {
                    return trans;
                }
            }
            return null;
        }

        public override TransactionEntities DisplayTransactionByAccountNo_DAL(long AccountNo)
        {
            foreach (TransactionEntities trans in Transactions)
            {
                if (trans.AccountNo == AccountNo)
                {
                    return trans;
                }
                
            }
            return null;
        }

        public override TransactionEntities DisplayTransactionDetailsByTransactionID_DAL(string TransactionID)
        {
            foreach (TransactionEntities trans in Transactions)
            {
                if (trans.TransactionID == TransactionID)
                {
                    return trans;
                }
            }
            return null;
        }

        public TransactionEntities GetAllTransactionsDAL()
        {
            foreach (TransactionEntities trans in Transactions)
            {
                return trans;

            }
            return null;

        }
        public override void Serialize()
        {
            this.TransactionsToSerialize = Transactions;
            FileStream fs1 = new FileStream(filepath, FileMode.Create, FileAccess.Write);
            BinaryFormatter binaryformatter = new BinaryFormatter();
            binaryformatter.Serialize(fs1, this);
            fs1.Close();
        }
        public override void DeSerialize()
        {
            
            FileStream fs2 = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            BinaryFormatter binaryformatter = new BinaryFormatter();
            TransactionDAL transactionDal = (TransactionDAL)binaryformatter.Deserialize(fs2);
        }

    }
}
