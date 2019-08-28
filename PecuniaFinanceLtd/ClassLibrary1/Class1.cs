//Same class
public class Customer
{
    public int CustomerID;
    public string CustomerName;
    private string _mobile;
    public string Email;
    public char Gender;
    public static string BranchName = "Mumbai";
    public readonly string Country;

    //Constructor
    public Customer()
    {
        Country = "India";
    }

    //method
    public string GetCustomerName()
    {
        return CustomerName;
    }

    //method
    public string GetTitle()
    {
        if (this.Gender == 'M')
        {
            return "Mr.";
        }
        else
        {
            return "Ms.";
        }
    }

    //static method
    public static string GetBranchName()
    {
        return BranchName;
    }

    //property
    public string Mobile
    {
        set
        {
            if (value.Length == 10)
                _mobile = value;
        }
        get
        {
            return _mobile;
        }
    }
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