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
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeRepository _accountTypeRepository;
        public AccountTypeController(IAccountTypeRepository IAccountRepository)
        {
            _accountTypeRepository = IAccountRepository;
        }


        [HttpGet("getaccounttypes")]
        public IActionResult GetAccountTypes()
        {
            var accountypes = _accountTypeRepository.GetAccountTypes();
            return Ok(accountypes);
        }


        [HttpPost("addaccounttype")]
        public IActionResult AddAccountType([FromBody] AccountType accounttype)
        {
            var newAccount =AccountType.Add(accounttype);

           var dbAccountType= _accountTypeRepository.CreatAccountType(newAccount);

            return Ok(dbAccountType);
        }
    }
}
