using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pecunia.Entities
{
    public enum AccountType
    {
        Savings = 0,
        Current = 1,
        FD = 2
    }


    public class Account
    {
        private long _accountNo;
        private string _customerID;
        private double _balance = 0;
        private DateTime _dateOfCreation;
        private double _interestrate;
        private double _initialAmount;
        public AccountType _accType;
        private string _branch;
        private double _fdDeposit;
        private string _homeBranch;
        private string _feedback;

        public long AccountNo
        {

            set => _accountNo = value;

            get => _accountNo;
        }

        public double InitialAmount
        {
            set
            {
                _initialAmount = value;
            }
            get
            {
                return _initialAmount;
            }
        }

        public string CustomerID { get => _customerID; set => _customerID = value; }
        public double Balance { get => _balance; set => _balance = value; }
        public DateTime DateOfCreation { get => _dateOfCreation; set => _dateOfCreation = value; }
        public double InterestRate { get => _interestrate; set => _interestrate = value; }
        public string Branch { get => _branch; set => _branch = value; }
        public double FdDeposit
        {
            get => _fdDeposit; set => _fdDeposit = value;

        }
        public string HomeBranch { get => _homeBranch; set => _homeBranch = value; }
        public string Feedback { get => _feedback; set => _feedback = value; }
    }
}
