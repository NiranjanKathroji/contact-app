using System;
using System.Collections.Generic;
using ContactApp.Core.Domain.Customers;
using ContactApp.Data.Infrastructure;

namespace ContactApp.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IRepository<Customer> customerRepository, IUnitOfWork unitOfWork)
        {
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            //return _customerRepository.GetAll();
            return _customerRepository.AllIncluding(x => x.Enquiries);
        }

        public Customer GetCustomer(int id)
        {
            //return _customerRepository.GetSingle(id);
            return _customerRepository.GetSingle(x => x.Id == id, x => x.Enquiries);
        }
        public Customer GetCustomer(string userName)
        {
            //return _customerRepository.GetSingle(id);
            return _customerRepository.GetSingle(x => x.UserName == userName, x => x.Enquiries);
        }

        public void CreateCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _customerRepository.Delete(customer);
        }

        public void SaveCustomer()
        {
            _unitOfWork.Commit();
        }
    }
}
