using AspBankApp.Repository;
using BankApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Repository
{

    public interface ICustomerRepository
    {
        Customer UpdateNameOnSignUp(Customer customer, Guid IdentityId);
        Customer Save(Customer customer);
        void CreatCustomer(string emailIdentifier, string iDIdentifier);
        Customer GetById(int id);

        Customer GetById(Guid id);

        Customer GetByEmailIdentifier(string emailIdentifier);

        List<Customer> GetUnregistered();
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly BankAppDataContext _context;
        public CustomerRepository(BankAppDataContext BankAppDataContext)
        {
            _context = BankAppDataContext;
        }


     
        public Customer GetByEmailIdentifier(string emailIdentifier)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Emailaddress == emailIdentifier);
            return customer;
        }


        public void CreatCustomer(string emailIdentifier, string iDIdentifier)
        {
            var customer = Customer.CreatNewCustomer(emailIdentifier, iDIdentifier);

            _context.Customers.Add(customer);

            try
            {
                _context.SaveChanges();
            }catch(Exception ex)
            {
                throw ex;
            }

        }

        public Customer UpdateNameOnSignUp(Customer customer, Guid IdentityId)
        {

            var dbCustomer = GetById(IdentityId);

            dbCustomer.UpdateNameOnSignUp(customer);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dbCustomer;

        }

        public Customer GetById(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.CustomerId == id);
            return customer;
        }

        public Customer GetById(Guid id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.IdentityId == id);
            return customer;
        }

        public List<Customer> GetUnregistered()
        {
            var customers = _context.Customers.Where(x => 
            x.IsCustomer == false && 
            x.IsAdmin == false && 
            x.Givenname !=null && 
            x.Surname !=null).ToList();

            return customers;
        }
        public Customer Save(Customer customer)
        {

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customer;
        }
    }
}

