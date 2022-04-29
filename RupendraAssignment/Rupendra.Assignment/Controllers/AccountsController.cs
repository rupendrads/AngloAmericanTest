using Microsoft.AspNetCore.Mvc;
using Rupendra.Assignment.Models;
using Rupendra.Assignment.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rupendra.Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {     
        private IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        [HttpGet("getaccounts")]
        public async Task<ActionResult<IList<Account>>> GetAccounts()
        {
            var response = await _accountService.GetAccounts();            
            return response.ToList();
        }

        [HttpPost("createaccount")]
        public async Task<ActionResult<Account>> CreateAccount(Account account)
        {
            var task = await _accountService.CreateAccount(account);
            return Ok(task);
        }

        [HttpPatch("updateaccount")]
        public async Task<ActionResult<Account>> UpdateAccount(Account account)
        {
            var task = await _accountService.UpdateAccount(account);             
            return Ok(task);
        }

        [HttpGet("getaccounttypes")]
        public async Task<ActionResult<IList<AccountType>>> GetAccountTypes()
        {
            var response = await _accountService.GetAccountTypes();            
            return response.ToList();
        }
    }
}
