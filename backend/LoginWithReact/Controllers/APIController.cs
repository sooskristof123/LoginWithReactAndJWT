using LoginWithReact.Database;
using LoginWithReact.Managers;
using LoginWithReact.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LoginWithReact.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]

    public class APIController : Controller
    {
        private readonly IJWTAuthenticationManager ijwtAuthenticationManager;

        static List<Account> accountList { get; set; } = new List<Account>();

        public APIController(IJWTAuthenticationManager ijwtAuthenticationManager) {
            this.ijwtAuthenticationManager = ijwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Account account) {
            var token = ijwtAuthenticationManager.Authenticate(account.username, account.password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
        [HttpPost]
        public IActionResult PostAccount([FromBody] Account account)
        {
            var item = accountList.FirstOrDefault(x => x.username == account.username);
            if (item == null) {
                accountList.Add(account);
                return Created("OK", account);
            }
            return Ok("Logged in");
        }

        /*[HttpGet]
        public IEnumerable GetAccount() {
            return accountList;
        }*/

        [HttpGet("{jsonobj}")]
        public IActionResult GetAccountByUsername(String jsonobj) {
            Account jsonObj = JsonSerializer.Deserialize<Account>(jsonobj);
            var item = accountList.FirstOrDefault(x => x.username == jsonObj.username);
            Console.WriteLine(jsonObj.username);
            Console.WriteLine(item.username);
            if (item.username == jsonObj.username & item.password == jsonObj.password) {
                return Ok(item);
            }
            return NotFound();
        }

        [HttpGet]
        public IEnumerable GetAccounts() {
            return accountList;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(String username) {
            var item = accountList.First(x => x.username == username);
            accountList.Remove(item);
            return Ok();
        }
    }
}
