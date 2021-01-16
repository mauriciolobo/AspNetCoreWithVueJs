using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWithVueJs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public ActionResult<Account> Register([FromBody] Account account)
        {
            return Ok(_accountService.Register(account));
        }
    }

    public interface IAccountService
    {
        Account Register(Account account);
    }

    public class AccountService:IAccountService
    {
        private static List<Account> list = new List<Account>();
        public Account Register(Account account)
        {
            account.AccountIndex = list.Max(a => a.AccountIndex) + 1;
            list.Add(account);
            return account;
        }
    }

    public class Account
    {
        public int AccountIndex { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
