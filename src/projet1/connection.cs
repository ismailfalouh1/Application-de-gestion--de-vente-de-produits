using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet1
{
    class connection
    {
        public static SqlConnection
                  GetDBConnection()
        {
    
            string connString = @"Data Source=DESKTOP-AR2DA9K;Initial Catalog=vente;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
