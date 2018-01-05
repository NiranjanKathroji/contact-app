using System.Collections.Generic;
using ContactApp.Core.Domain.Customers;


namespace ContactApp.Services.Customers
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        Customer GetCustomer(string userName);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void SaveCustomer();
    }
}
