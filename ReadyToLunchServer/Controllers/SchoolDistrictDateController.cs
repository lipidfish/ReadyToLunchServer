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
    public class SchoolDistrictDateController : ApiController
    {



        public SchoolDistrict GetSchoolDistrictDate(int id)
        {
            
            var sql = "SELECT * FROM dbo.SchoolDistrict WHERE SchoolDistrictID = " +
                      id;
            
            var schoolDistrict = new SchoolDistrict();
            using (SqlConnection conn = ConnectionFactory.GetConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            schoolDistrict.DateUpdated = Convert.ToDateTime(reader["SchoolDistrictDateUpdated"]);
                            schoolDistrict.Id = Convert.ToInt16(reader["SchoolDistrictID"]);
                            schoolDistrict.Name = Convert.ToString(reader["SchoolDistrictName"]);
                            
                        }
                    }
                }
            }
            return schoolDistrict;
            
        }

        public IEnumerable<DateTime> GetAllSchoolDictrictUpdates()
        {
            var l = new List<DateTime>();
            return l;
        } 
    }
}
