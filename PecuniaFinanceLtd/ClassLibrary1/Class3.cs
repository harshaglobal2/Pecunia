namespace Banking.PersonalBanking
{
    public partial class Customer : IPerson
    {
        //Constructor
        public Customer()
        {
            _country = "India";
        }

        public Customer(int customerID, string customerName, string mobile)
        {
            //field = parameter
            _customerID = customerID;
            _customerName = customerName;
            _mobile = mobile;
        }

        //method
        public string GetCustomerName()
        {
            return CustomerName;
        }

        //method
        public virtual string GetTitle()
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

    public static class Company
    {
        private static string _companyName;
        private static string _companyLocation;

        public static string CompanyName
        {
            set
            {
                _companyName = value;
            }
            get
            {
                return _companyName;
            }
        }

        public static string CompanyLocation
        {
            set
            {
                _companyLocation = value;
            }
            get
            {
                return _companyLocation;
            }
        }

        public static void ChangeCompanyLocation(string newLocation)
        {
            _companyLocation = newLocation;
        }

        static Company()
        {
            _companyName = "Capgemini";
            _companyLocation = "Navi Mumbai";
        }
    }
}
