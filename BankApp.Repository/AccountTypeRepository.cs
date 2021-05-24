using AspBankApp.Repository;
using BankApp.Shared;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Repository
{
    public interface IAccountTypeRepository
    {
        List<AccountType> GetAccountTypes();
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
    }
}