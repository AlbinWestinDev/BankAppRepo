using BankApp.Repository;
using BankApp.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;
        public LoanController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }


        [HttpPost("addloan")]
        public IActionResult AddLoan([FromBody] Loan loan)
        {
            _loanRepository.Save(loan);
            return Ok(loan);
        }

    }
}
