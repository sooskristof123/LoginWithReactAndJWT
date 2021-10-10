using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginWithReact.Model
{
    public class Account
    {

        public String username { get; set; }
        public String password { get; set; }
        Account account;

        public Account(String username, String password) {
            this.username = username;
            this.password = password;
        }
    }
}
