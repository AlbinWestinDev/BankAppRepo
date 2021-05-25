using System;
using System.Collections.Generic;

#nullable disable

namespace BankApp.Shared
{
    public partial class Loan
    {
        public int LoanId { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int Duration { get; set; }
        public decimal Payments { get; set; }
        public string Status { get; set; }

        public virtual Account Account { get; set; }



        public static Loan CreateNewLoan(Loan loan)
        {
            var newLoan = new Loan();
            newLoan.AccountId = loan.AccountId;
            newLoan.Amount = loan.Amount;
            newLoan.Date = DateTime.Now;
            newLoan.Duration = loan.Duration;
            newLoan.Payments = 12;
            newLoan.Status = "Huslån";

            return newLoan;
        }
    }
}
