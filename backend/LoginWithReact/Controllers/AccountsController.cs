using LoginWithReact.Database;
using LoginWithReact.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginWithReact.Controllers
{
    public class AccountsController : Controller
    {
        public AccountsController() { 
        }
        public Account GetAccount(string username, string password)
        {
            AccountDAO accountDAO = new AccountDAO();
            return accountDAO.GetAccount(username, password);
        }
    }
}
