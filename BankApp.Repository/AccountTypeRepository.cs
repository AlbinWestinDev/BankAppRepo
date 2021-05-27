using AspBankApp.Repository;
using BankApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Repository
{
    public interface IAccountTypeRepository
    {
        List<AccountType> GetAccountTypes();


        AccountType CreatAccountType(AccountType type);
    }
    public class AccountRepository : IAccountTypeRepository
    {
        private readonly BankAppDataContext _context;

        public AccountRepository(BankAppDataContext bankAppDataContext)
        {
            _context = bankAppDataContext;
        }

        public List<AccountType> GetAccountTypes()
        {
            return _context.AccountTypes.ToList();

        }


        public AccountType CreatAccountType(AccountType type)
        {

            _context.AccountTypes.Add(type);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return type;

        }
    }
}