//Same class
public class Customer
{
    private int _customerID;
    private string _customerName;
    private string _mobile;
    private string _email;
    private char _gender;
    private static string _branchName = "Mumbai";
    private readonly string _country;
    private string _state;

    //auto-implemented property
    public string LandMark { get; set; } //read & write
    //public string LandMark { get; } //read-only

    //field for indexer
    private string[] _contactNumbers;

    //indexer
    public string[] ContactNumbers
    {
        set
        {
            _contactNumbers = value;
        }
        get
        {
            return _contactNumbers;
        }
    }

    //Constructor
    public Customer()
    {
        _country = "India";
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

    //readonly property
    public string Country
    {
        get
        {
            return _country;
        }
    }

    public int CustomerID
    {
        get => _customerID;
        set
        {
            _customerID = value;
        }
    }
    
    public string Email { get => _email; set => _email = value; }
    public char Gender { get => _gender; set => _gender = value; }
    public static string BranchName { get => _branchName; set => _branchName = value; }
    public string CustomerName { get => _customerName; set => _customerName = value; }

    //write only property
    public string State
    {
        set
        {
            _state = value;
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