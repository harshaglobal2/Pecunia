//Same class
public class Customer
{
    private int CustomerID;
    private protected string CustomerName;
    protected internal string Mobile;
    public string Email;

    public void Method1()
    {
        CustomerID = 0; //accessible
        CustomerName = "abc"; //accessible
        Mobile = "1234"; //accessible
    }
}

//Child class at same project
public class PriviligedCustomer : Customer
{
    public void Method3()
    {
        CustomerID = 0; //not accessible
        CustomerName = "xyz"; //accessible
        Mobile = "1234"; //accessible
    }
}

//Other class at same project
public class Supplier
{
    public void Method2()
    {
        Customer customer = new Customer();
        customer.CustomerID = 1; //not accessible
        customer.CustomerName = "pqr"; //Not accessible
        customer.Mobile = "1234"; //accessible
    }
}