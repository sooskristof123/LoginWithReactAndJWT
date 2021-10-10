using LoginWithReact.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LoginWithReact.Database
{
    public class AccountDAO : IAccountDAO
    {
        Account account;
        private static SqlCommand dbCmd = null;
        public Account GetAccount(string username, string password)
        {
            string sql = "select * from Account where username='"+username+"' and password='"+password+"'";
            dbCmd = Connection.GetDbCommand(sql);

            /*IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();*/

            using (SqlDataReader reader = dbCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    username = reader.GetString(1);
                    password = reader.GetString(2);
                    account = new Account(username, password);
                }
            }
            Connection.Close();
            return account;



























        }
    }
}
