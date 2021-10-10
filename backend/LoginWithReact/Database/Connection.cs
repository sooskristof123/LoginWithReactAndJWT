using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LoginWithReact.Database
{
    public class Connection
    {
        public static readonly string connectionString = @"Data Source=hildur.ucn.dk; UID=dmaj0920_1086314; Password=Password1!;";
        public static readonly SqlConnection dbconn = new SqlConnection(connectionString);
        private static SqlCommand dbCmd;

        private Connection()
        {
        }
        private static void Open()
        {
            if (dbconn.State.ToString().CompareTo("Open") != 0)
                dbconn.Open();
        }
        public static void Close()
        {
            dbconn.Close();
        }

        public static SqlCommand GetDbCommand(string sql)
        {
            if (dbconn.State.ToString().CompareTo("Open") != 0)
                Open();
            if (dbCmd == null)
            {
                dbCmd = new SqlCommand(sql, dbconn);
            }
            dbCmd.CommandText = sql;
            return dbCmd;
        }
    }
}
