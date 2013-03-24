using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReadyToLunchRole.Models;

namespace ReadyToLunchRole.Controllers
{
    public class SchoolDistrictUpdatedController : ApiController
    {



        public SchoolDistrict GetSchoolDistrict(int id)
        {
            return new SchoolDistrict {DateUpdated = DateTime.Today, Id = 1, MenuGroups = null, Name = "MPS"};

            var sql = "SELECT SchoolDistrictDateUpdated FROM dbo.SchoolDistrict WHERE SchoolDistrictID = " +
                      id;
            var retVal = new DateTime(2000, 1, 1);

            SqlConnectionStringBuilder connString1Builder;
            connString1Builder = new SqlConnectionStringBuilder();
            connString1Builder.DataSource = "tcp:m3gdulejm4.database.windows.net,1433";
            connString1Builder.InitialCatalog = "ReadyToLunch";
            connString1Builder.Encrypt = true;
            connString1Builder.TrustServerCertificate = false;
            connString1Builder.UserID = "lipidfresh@m3gdulejm4";
            connString1Builder.Password = "Diva4dog";

            using (SqlConnection conn = new SqlConnection(connString1Builder.ToString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            retVal = Convert.ToDateTime(reader["SchoolDistrictDateUpdated"]);
                        }
                    }
                }
            }
            //return retVal;

        }

    }
}
