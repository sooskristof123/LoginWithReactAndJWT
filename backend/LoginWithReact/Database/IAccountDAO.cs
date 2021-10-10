using LoginWithReact.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginWithReact.Database
{
    interface IAccountDAO
    {
        Account GetAccount(string username, string password);
    }
}
