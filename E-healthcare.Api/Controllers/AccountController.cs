using Ehealthcare.Entities;
using EHealthcare.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EHealthcare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private IBaseRepository<Account> AccountRepo { get; set; }
        public AccountController(IBaseRepository<Account> repository)
        {
            AccountRepo = repository;
        }

        [HttpGet("accountInfo/{email}")]
        public ActionResult<Account> getAccountDetails(String email)
        {
            try
            {
                Account result = AccountRepo.Get().Where(a => a.Email == email).FirstOrDefault());
                return Ok(result);
            }catch(Exception ex)
            {
               return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [HttpPut("addFunds")]
        public ActionResult<String> AddFunds([FromBody] Account account)
        {
            try
            {
                var result = AccountRepo.Get().Where(a => a.Email == account.Email).First();
                account.Amount = result.Amount + account.Amount;
                var updated = AccountRepo.Update(account).Result;
                return Ok("Account updated");
            }catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message); 
            }
        }
    }
}
