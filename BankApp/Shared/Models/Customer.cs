using System;
using System.Collections.Generic;

#nullable disable

namespace BankApp.Shared
{
    public partial class Customer
    {
        public Customer()
        {
            Accounts = new List<Account>();
        }

        public int CustomerId { get; set; }
        public string? Gender { get; set; }
        public string? Givenname { get; set; }
        public string? Surname { get; set; }
        public string? Streetaddress { get; set; }
        public string? City { get; set; }
        public string? Zipcode { get; set; }
        public string? Country { get; set; }
        public string? CountryCode { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Telephonecountrycode { get; set; }
        public string? Telephonenumber { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsCustomer { get; set; }
        public virtual List<Account> Accounts { get; set; }



    public Guid IdentityId { get; set; }

        public void UpdateNameOnSignUp(Customer customer)
        {


            Surname = customer.Surname;
            Givenname = customer.Givenname;

        }

        public string Emailaddress { get; set; }

        public static Customer CreatNewCustomer(string emailIdentifier, string iDIdentifier)
        {
            var customer = new Customer();
            customer.Emailaddress = emailIdentifier;
            customer.IdentityId = Guid.Parse(iDIdentifier);
            return customer;
        }
        public void CreateNewAccount(int accountType)
        {
            Account salaryAccount = new Account();
            salaryAccount.AccountTypesId = accountType;
            salaryAccount.Balance = 0;

            Accounts.Add(salaryAccount);
        }

        public void ApproveAsCustomer()
        {
            CreateNewAccount(Constants.AccountTypeSalaryAccount);

            IsCustomer = true;
        }

        public void ApproveAsAdmin()
        {
            IsAdmin = true;
        }

        
    }
}
