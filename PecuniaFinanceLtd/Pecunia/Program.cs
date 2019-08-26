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

                System.Console.WriteLine("Customer details are:");
                System.Console.WriteLine("Customer ID " + customer.CustomerID);
                System.Console.WriteLine("Customer Name " + customer.CustomerName);
                System.Console.WriteLine("Mobile " + customer.Mobile);
                System.Console.WriteLine("Email " + customer.Email);
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