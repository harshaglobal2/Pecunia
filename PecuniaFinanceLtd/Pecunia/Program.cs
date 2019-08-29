//child class at other project
class OtherCustomer : Customer
{
    public void Method3()
    {
        CustomerName = "stu"; //accessible
        Mobile = "1234"; //accessible
    }
}

//Other class at Other project
class EntryScreen
{
    static void Main()
    {
        System.Console.WriteLine("Welcome to Pecunia Finance Ltd");
        int choice;
        do
        {
            System.Console.WriteLine("1. Customers");
            System.Console.WriteLine("2. Accounts");
            System.Console.WriteLine("3. Transactions");
            System.Console.WriteLine("4. Loans");
            System.Console.WriteLine("5. Exit");
            System.Console.WriteLine("Enter your choice (1-5): ");

            choice = int.Parse(System.Console.ReadLine());
            if (choice == 1)
            {
                //object 1
                Customer customer;
                customer = new Customer();
                System.Console.WriteLine("Enter Customer ID");
                customer.CustomerID = int.Parse(System.Console.ReadLine());
                System.Console.WriteLine("Enter Customer Name");
                customer.CustomerName = System.Console.ReadLine();
                System.Console.WriteLine("Enter Mobile");
                customer.Mobile = System.Console.ReadLine();
                System.Console.WriteLine("Enter Email");
                customer.Email = System.Console.ReadLine();
                System.Console.WriteLine("Enter Gender");
                customer.Gender = System.Console.ReadLine()[0];

                System.Console.WriteLine("Customer details are:");
                System.Console.WriteLine("Customer ID " + customer.CustomerID);
                System.Console.WriteLine("Customer Name " + customer.GetTitle() + customer.GetCustomerName());
                System.Console.WriteLine("Mobile " + customer.Mobile);
                System.Console.WriteLine("Email " + customer.Email);
                System.Console.WriteLine("Branch " + Customer.GetBranchName());
                System.Console.WriteLine("Country " + customer.Country);
                //customer.Country = "UK"; //we can't assign value into readonly

                //object 2
                Customer customer2 = new Customer(1, "sample 1", "1234");
                Customer customer3 = new Customer(2, "sample 2", "897");
                Customer customer4 = new Customer(3, "sample 3", "6677");
                Customer customer5 = new Customer() { CustomerName = "some name", Gender = 'M', Email = "some@something.com" };

                Account account = new Account();
                account.CurrentBalance = 10000;
                double dep = 2000;
                double bal = account.Deposit(ref dep, 10);
                System.Console.WriteLine(dep); //Output: 5000

                System.Console.WriteLine(account.CurrentBalance); //Output: 10100

                //indexer
                customer.ContactNumbers = new string[3] { "123", "456", "789" }; //Invokes set accessor of the property
                System.Console.WriteLine(customer.ContactNumbers[0]); //Invokes get accessor of the property
                System.Console.WriteLine(customer.ContactNumbers[1]); //Invokes get accessor of the property
                System.Console.WriteLine(customer.ContactNumbers[2]); //Invokes get accessor of the property

                System.Console.WriteLine(customer[2]); //Invokes get accessor of the indexer

                customer.ContactNumbers[2] = "909"; //Invokes set accessor the property
                customer[2] = "909"; //Invokes set accessor of the indexer
            }
            else if (choice == 2)
            {
                System.Console.WriteLine("Accounts menu here");
            }
            else if (choice == 3)
            {
                System.Console.WriteLine("Transactions menu here");
            }
            else if (choice == 4)
            {
                System.Console.WriteLine("Loans menu here");
            }
            else if (choice == 5)
            {
            }
            else
            {
                System.Console.WriteLine("Invalid option");
            }
        } while (choice != 5);
    }
}