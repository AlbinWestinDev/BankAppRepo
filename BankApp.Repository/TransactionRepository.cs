using AspBankApp.Repository;
using BankApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankApp.Repository
{
    public interface ITransactionRepository
    {
        Transaction Save(Transaction transaction);
    }
    public class TransactionRepository:ITransactionRepository
    {
        private readonly BankAppDataContext _context;
        public TransactionRepository(BankAppDataContext BankAppDataContext)
        {
            _context = BankAppDataContext;
        }



        public Transaction Save(Transaction transaction)
        {
            
            try
            {
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return transaction;
        }
    }

}

