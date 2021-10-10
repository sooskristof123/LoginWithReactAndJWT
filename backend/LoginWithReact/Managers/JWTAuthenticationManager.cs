using LoginWithReact.Controllers;
using LoginWithReact.Database;
using LoginWithReact.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoginWithReact.Managers
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {

        /*private readonly IDictionary<string, string> accountList = new Dictionary<string, string> {
            { "test1", "password1"},{ "test2", "password2"}};*/
        private readonly string key;

        public JWTAuthenticationManager(string key) {
            this.key = key;
        }
        public string Authenticate(string username, string password)
        {
            AccountsController ac = new AccountsController();
            if((ac.GetAccount(username, password) == null))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
