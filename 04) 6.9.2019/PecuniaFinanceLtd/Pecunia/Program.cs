using Banking.PersonalBanking;
//using System;
using static System.Console;

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
        WriteLine("Welcome to Pecunia Finance Ltd");
        int choice;
        do
        {
            WriteLine("1. Customers");
            WriteLine("2. Accounts");
            WriteLine("3. Transactions");
            WriteLine("4. Loans");
            WriteLine("5. Exit");
            WriteLine("Enter your choice (1-5): ");

            choice = int.Parse(ReadLine());
            if (choice == 1)
            {
                //object 1
                Customer customer;
                customer = new Customer();
                WriteLine("Enter Customer ID");
                customer.CustomerID = int.Parse(ReadLine());
                WriteLine("Enter Customer Name");
                customer.CustomerName = ReadLine();
                WriteLine("Enter Mobile");
                customer.Mobile = ReadLine();
                WriteLine("Enter Email");
                customer.Email = ReadLine();
                WriteLine("Enter Gender");
                customer.Gender = ReadLine()[0];

                WriteLine("Customer details are:");
                WriteLine("Customer ID " + customer.CustomerID);
                WriteLine("Customer Name " + customer.GetTitle() + customer.GetCustomerName());
                WriteLine("Mobile " + customer.Mobile);
                WriteLine("Email " + customer.Email);
                WriteLine("Branch " + Customer.GetBranchName());
                WriteLine("Country " + customer.Country);
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
                WriteLine(dep); //Output: 5000

                WriteLine(account.CurrentBalance); //Output: 10100

                //indexer
                customer.ContactNumbers = new string[3] { "123", "456", "789" }; //Invokes set accessor of the property
                WriteLine(customer.ContactNumbers[0]); //Invokes get accessor of the property
                WriteLine(customer.ContactNumbers[1]); //Invokes get accessor of the property
                WriteLine(customer.ContactNumbers[2]); //Invokes get accessor of the property

                WriteLine(customer[2]); //Invokes get accessor of the indexer

                customer.ContactNumbers[2] = "909"; //Invokes set accessor the property
                customer[2] = "909"; //Invokes set accessor of the indexer
            }
            else if (choice == 2)
            {
                WriteLine(Company.CompanyName);
                Company.ChangeCompanyLocation("Mumbai");
                WriteLine(Company.CompanyLocation);
            }
            else if (choice == 3)
            {
                WriteLine("Transactions menu here");
            }
            else if (choice == 4)
            {
                WriteLine("Loans menu here");
            }
            else if (choice == 5)
            {
            }
            else
            {
                WriteLine("Invalid option");
            }
        } while (choice != 5);
    }
}