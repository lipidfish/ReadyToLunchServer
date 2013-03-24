using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ReadyToLunchRole;

namespace ReadyToLunchRole.Controllers
{
    public class ReaderDataUtilities
    {




        public static ReaderData GetReaderData(SqlDataReader dr)
        {
            var retVal = new ReaderData();
            retVal.SchoolDistrictId = Convert.ToInt16(dr["SchoolDistrictID"]);
            retVal.SchoolDistrictName = Convert.ToString(dr["SchoolDistrictName"]);
            retVal.SchoolDistrictDateUpdated = Convert.ToDateTime(dr["SchoolDistrictDateUpdated"]);
            retVal.MenuGroupId = Convert.ToInt16(dr["MenuGroupID"]);
            retVal.MenuGroupName = Convert.ToString(dr["MenuGroupName"]);
            retVal.MenuGroupDescription = Convert.ToString(dr["MenuGroupDescription"]);
            retVal.MenuGroupOrderBy = Convert.ToInt16(dr["MenuGroupOrderBy"]);
            retVal.MenuGroupDateUpdated = Convert.ToDateTime(dr["MenuGroupDateUpdated"]);
            retVal.MenuId = Convert.ToInt16(dr["MenuID"]);
            retVal.MenuDate = Convert.ToDateTime(dr["MenuDate"]);
            retVal.IsDayOff = Convert.ToInt16(dr["IsDayOff"]);
            retVal.OfferingId = Convert.ToInt16(dr["OfferingID"]);
            retVal.OfferingName = Convert.ToString(dr["OfferingName"]);
            retVal.OfferingAttribute = Convert.ToString(dr["OfferingAttribute"]);
            retVal.OfferingOrderBy = Convert.ToInt16(dr["OfferingOrderBy"]);
            return retVal;
        }


    }
}