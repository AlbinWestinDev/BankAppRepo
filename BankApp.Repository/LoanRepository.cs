using AspBankApp.Repository;
using BankApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Repository
{
    public interface ILoanRepository
    {
        
        Loan Save(Loan loan);
    }
    public class LoanRepository : ILoanRepository
    {

        private readonly BankAppDataContext _context;
        public LoanRepository(BankAppDataContext BankAppDataContext)
        {
            _context = BankAppDataContext;
        }

        public Loan Save(Loan loan)
        {
            var newLone = Loan.CreateNewLoan(loan);
            try
            {
                _context.Loans.Add(newLone);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newLone;
        }
    }
}
