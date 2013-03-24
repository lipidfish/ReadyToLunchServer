using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ReadyToLunchRole
{
    public class ConnectionFactory
    {

        public static SqlConnection GetConnection ()
        {
            SqlConnectionStringBuilder connString1Builder;
            connString1Builder = new SqlConnectionStringBuilder();
            connString1Builder.DataSource = "tcp:m3gdulejm4.database.windows.net,1433";
            connString1Builder.InitialCatalog = "ReadyToLunch";
            connString1Builder.Encrypt = true;
            connString1Builder.TrustServerCertificate = false;
            connString1Builder.UserID = "lipidfresh@m3gdulejm4";
            connString1Builder.Password = "Diva4dog";

            return new SqlConnection(connString1Builder.ToString());
        }

    }
}