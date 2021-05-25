using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace BankApp.Shared
{
    public partial class Account
    {
        public Account()
        {

            Created = DateTime.Now;

            Loans = new HashSet<Loan>();
            Transactions = new HashSet<Transaction>();
        }

        public int AccountId { get; set; }
        
   
        public DateTime Created { get; set; }
        public decimal Balance { get; set; }
        public int? AccountTypesId { get; set; }


        [JsonIgnore]
        public virtual AccountType AccountTypes { get; set; }

        public int CustomerId { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }


        [JsonIgnore]
        public virtual ICollection<Loan> Loans { get; set; }


        [JsonIgnore]
        public virtual ICollection<Transaction> Transactions { get; set; }


        public void SetBalance(decimal amount)
        {
          Balance = Balance + amount;
        }

    }
}
