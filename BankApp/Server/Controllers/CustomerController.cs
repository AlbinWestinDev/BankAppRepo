using BankApp.Repository;
using BankApp.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BankApp.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository ICustomerRepository)
        {
            _customerRepository = ICustomerRepository;
        }

        [HttpPut("editcustomeronsignup")]
        public IActionResult EditCustomerOnSignup([FromBody] Customer customer)
        {
            
            var sparadCustomer = _customerRepository.UpdateNameOnSignUp(customer, User.GetIdentityId());

            return Ok(sparadCustomer);
        }

        [HttpGet("getunregistered")]
        public IActionResult GetUnregistered()
        {
            var customers = _customerRepository.GetUnregistered();
            return Ok(customers);
        }

        [HttpGet("getcustomer")]
        public IActionResult EditCustomerOnSignup()
        {

            var x = User.GetIdentityId();

            var dbCustomer = _customerRepository.GetById(User.GetIdentityId());

            return Ok(dbCustomer);
        }


        [HttpPut("approveascustomer")]
        public IActionResult ApproveCustomer([FromBody] Customer customer)
        {
           var dbCustomer =  _customerRepository.GetById(customer.CustomerId);
            dbCustomer.ApproveAsCustomer();
            _customerRepository.Save(customer);
            return Ok();
        }
        [HttpPut("approveasadmin")]
        public IActionResult ApproveAdmin([FromBody] Customer customer)
        {

            var dbCustomer = _customerRepository.GetById(customer.CustomerId);
            dbCustomer.ApproveAsAdmin();
            _customerRepository.Save(customer);
            return Ok();
        }

        
        [HttpGet("getcustomers")]
        public IActionResult GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
            return Ok(customers);
        }
    }
    
}
