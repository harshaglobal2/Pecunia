namespace Banking.PersonalBanking
{
    public interface IPerson
    {
        string PersonName { get; set; }
        System.DateTime DateOfBirth { get; set; }
        string GetTitle();
    }

    //Same class
    public partial class Customer : IPerson
    {
        private int _customerID = 5;
        private string _customerName;
        private string _mobile;
        private string _email;
        private char _gender;
        private static string _branchName = "Mumbai";
        private readonly string _country;
        private string _state;

        public string PersonName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
    }

    public enum MartialStatusEnum
    {
        Unmarried, Married
    }

    public sealed class PriviligedCustomer : Customer
    {
        public MartialStatusEnum MaritalStatus { get; set; }

        //method hiding (overwriting)
        //public new string GetTitle()
        //{
        //    if (this.Gender == 'M')
        //    {
        //        return "Mr.";
        //    }
        //    else
        //    {
        //        if (MaritalStatus == "Unmarried")
        //        {
        //            return "Miss.";
        //        }
        //        else
        //        {
        //            return "Mrs.";
        //        }
        //    }
        //}

        //method overriding (extending the parent class's method)
        public override string GetTitle()
        {
            string t = base.GetTitle();
            if (t == "Ms.")
            {
                if (MaritalStatus == "Unmarried")
                {
                    return "Miss.";
                }
                else
                {
                    return "Mrs.";
                }
            }
            return t;
        }
    }

    //public class OtherCustomer : PriviligedCustomer
    //{

    //}

    public class CorporateCustomer : Customer
    {

    }

    public class Account
    {
        public double CurrentBalance = 0;

        public void Deposit(double DepositAmount = 100)
        {
            CurrentBalance = CurrentBalance + DepositAmount;
        }

        public double Deposit(ref double DepositAmount, double InterestRate)
        {
            DepositAmount = 4000; //not allowed
            CurrentBalance = CurrentBalance + DepositAmount + (DepositAmount * InterestRate / 100);
            return CurrentBalance;
        }
    }
}



namespace Accounts.LoanAccount
{

}