using System.Collections.Generic;

class Customer
{

}
interface ICustomerService
{
    List<Customer> Customers { get; set; }
    void AddCustomer(Customer customer);
    void InsertCustomer(int index, Customer customer);
    void RemoveCustomer(int index);
    Customer GetCustomerByCustomerID(int customerID);
    Customer GetCustomerByPhone(string phone);
    List<Customer> GetAllCustomers();
}
class CustomerService : ICustomerService
{
    public List<Customer> Customers { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void AddCustomer(Customer customer)
    {
        throw new System.NotImplementedException();
    }

    public List<Customer> GetAllCustomers()
    {
        throw new System.NotImplementedException();
    }

    public Customer GetCustomerByCustomerID(int customerID)
    {
        throw new System.NotImplementedException();
    }

    public Customer GetCustomerByPhone(string phone)
    {
        throw new System.NotImplementedException();
    }

    public void InsertCustomer(int index, Customer customer)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveCustomer(int index)
    {
        throw new System.NotImplementedException();
    }
}