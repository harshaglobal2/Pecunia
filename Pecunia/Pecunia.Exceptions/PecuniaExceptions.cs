using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pecunia.Exceptions
{
    public class InvalidStringException : ApplicationException{
        public InvalidStringException(string msg) : base(msg){

        }    
    }

    public class InvalidAmountException : ApplicationException
    {
        public InvalidAmountException(string msg) : base(msg)
        {

        }
    }

    public class InvalidRangeException : ApplicationException
    {
        public InvalidRangeException(string msg) : base(msg)
        {

        }
    }

    public class InvalidEnumException : ApplicationException
    {
        public InvalidEnumException(string msg) : base(msg)
        {

        }
    }

    
    public class InitialAmountOfFDException : Exception
    {
        public InitialAmountOfFDException(String m) : base(m)
        {

        }
    }
    public class EnterValidCustomerIDException : Exception
    {
        public EnterValidCustomerIDException(String m) : base(m)
        {

        }
    }

    public class CustomerDoesNotExistException : Exception
    {
        public CustomerDoesNotExistException(String m) : base(m)
        {

        }
    }

    public class EnterValidAccountTypeException : Exception
    {
        public EnterValidAccountTypeException(String m) : base(m)
        {

        }
    }
    public class AccountDoesNotExistException : Exception
    {
        public AccountDoesNotExistException(String m) : base(m)
        {

        }
    }

    public class DebitSlipException : ApplicationException
    {
        public DebitSlipException(string message) : base(message)
        {

        }
    }
    public class CreditSlipException : ApplicationException
    {
        public CreditSlipException(string message) : base(message)
        {

        }
    }
    public class DebitChequeException : ApplicationException
    {
        public DebitChequeException(string message) : base(message)
        {

        }
    }
    public class CreditChequeException : ApplicationException
    {
        public CreditChequeException(string message) : base(message)
        {

        }
    }
    public class TransactionDisplayIDException : ApplicationException
    {
        public TransactionDisplayIDException(string message) : base(message)
        {

        }
    }
    public class TransactionDisplayAccountException : ApplicationException
    {
        public TransactionDisplayAccountException(string message) : base(message)
        {

        }
    }
    public class TransactionDetailsException : ApplicationException
    {
        public TransactionDetailsException(string message) : base(message)
        {

        }
    }

    public class PecuniaException : ApplicationException
    {
        public PecuniaException()
            : base()
        {
        }

        public PecuniaException(string message)
                : base(message)
        {
        }
        public PecuniaException(string message, Exception innerException)
                : base(message, innerException)
        {
        }
    }
}
