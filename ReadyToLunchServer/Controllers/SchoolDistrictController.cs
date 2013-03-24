using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReadyToLunchRole.Models;
using ReadyToLunchRole;

namespace ReadyToLunchRole.Controllers
{
    public class SchoolDistrictController : ApiController
    {

       // private List<SchoolDistrict> _schoolDistricts;

        public SchoolDistrictController()
        {
            

         //   _schoolDistricts.Add(currentSchoolDistrict);
        }

        /*
        public IEnumerable<SchoolDistrict> GetAllSchoolDistricts()
        {
           // return _schoolDistricts;
        }
        */

        private SchoolDistrict GetSchoolDistrictListById(int id)
        {

            var schoolDistrictList = new List<SchoolDistrict>();

            var currentSchoolDistrict = new SchoolDistrict();
            var currentMenuGroup = new MenuGroup();
            var currentMenu = new Menu();
            var currentOffering = new Offering();
            var currentAttribute = "";

            using (SqlConnection conn = ConnectionFactory.GetConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    
                    cmd.CommandText = "select * from AllData where schoolDistrictID = @schoolDistrictId and MenuDate >= getdate() - 1 order by SchoolDistrictName, MenuGroupOrderBy, MenuDate, OfferingOrderBy";
                    // cmd.CommandText = "select * from AllData where schoolDistrictID = @schoolDistrictId and MenuDate >= '2012-11-01' order by SchoolDistrictName, MenuGroupOrderBy, MenuDate, OfferingOrderBy";

                    var param = new SqlParameter();
                    param.ParameterName = "@schoolDistrictId";
                    param.DbType = System.Data.DbType.Int32;
                    param.Value = id;
                    cmd.Parameters.Add(param);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bool isFirstPass = true;

                        var listOfferingAttributes = new List<String>();
                        var listOfferings = new List<Offering>();
                        var listMenus = new List<Menu>();
                        var listMenuGroups = new List<MenuGroup>();
                        ReaderData oldRd = new ReaderData();

                        while (reader.Read())
                        {
                            ReaderData newRd = GetReaderData(reader);
                            currentAttribute = "";
                            

                            if (!isFirstPass && IsOfferingDifferent(oldRd, newRd))
                            {
                                currentOffering.Attributes = listOfferingAttributes;
                                listOfferings.Add(currentOffering);
                                currentMenu.Offerings = listOfferings;
                                currentOffering = new Offering();
                                listOfferingAttributes = new List<String>();
                            }

                            if (!isFirstPass && IsMenuDifferent(oldRd, newRd))
                            {
                                currentMenu.Offerings = listOfferings;
                                listMenus.Add(currentMenu);
                                currentMenuGroup.Menus = listMenus;
                                currentMenu = new Menu();
                                listOfferings = new List<Offering>();
                            }

                            if (!isFirstPass && IsMenuGroupDifferent(oldRd, newRd))
                            {
                                listMenuGroups.Add(currentMenuGroup);
                                currentMenuGroup.Menus = listMenus;
                                currentMenuGroup = new MenuGroup();
                                listMenus = new List<Menu>();
                            }

                            currentSchoolDistrict.Id = newRd.SchoolDistrictId;
                            currentSchoolDistrict.Name = newRd.SchoolDistrictName;
                            currentSchoolDistrict.DateUpdated = newRd.SchoolDistrictDateUpdated;
                            currentMenuGroup.Id = newRd.MenuGroupId;
                            currentMenuGroup.Name = newRd.MenuGroupName;
                            currentMenuGroup.Description = newRd.MenuGroupDescription;
                            currentMenuGroup.OrderBy = newRd.MenuGroupOrderBy;
                            currentMenuGroup.DateUpdated = newRd.MenuGroupDateUpdated;
                            currentMenuGroup.Id = newRd.MenuGroupId;
                            currentMenu.Id = newRd.MenuId;
                            currentMenu.MenuDate = newRd.MenuDate;
                            currentOffering.Id = newRd.OfferingId;
                            currentOffering.Name = newRd.OfferingName;
                            currentOffering.OrderBy = newRd.OfferingOrderBy;
                            currentAttribute = newRd.OfferingAttribute;

                            listOfferingAttributes.Add(currentAttribute);

                            oldRd = newRd;

                            isFirstPass = false;

                        }

                        currentOffering.Attributes.Add(currentAttribute);
                        listOfferings.Add(currentOffering);
                        currentMenu.Offerings = listOfferings;
                        listMenus.Add(currentMenu);
                        currentMenuGroup.Menus = listMenus;


                        listMenuGroups.Add(currentMenuGroup);
                        currentSchoolDistrict.MenuGroups = listMenuGroups;

                    }
                }
            }


            return currentSchoolDistrict;

        }


        public SchoolDistrict GetSchoolDistrictById (int id)
        {

            var sd = GetSchoolDistrictListById(id);
            if (sd == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return sd;

        }


        private ReaderData GetReaderData(SqlDataReader dr)
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

        private bool IsMenuGroupDifferent(ReaderData rd1, ReaderData rd2)
        {
            return rd1.MenuGroupId != rd2.MenuGroupId;
        }

        private bool IsMenuDifferent(ReaderData rd1, ReaderData rd2)
        {
            return rd1.MenuId != rd2.MenuId;
        }

        private bool IsOfferingDifferent(ReaderData rd1, ReaderData rd2)
        {
            return rd1.OfferingId != rd2.OfferingId || rd1.MenuDate != rd2.MenuDate;
        }


        private bool IsAttributeDifferent(ReaderData rd1, ReaderData rd2)
        {
            return rd1.OfferingAttribute != rd2.OfferingAttribute;
        }



    }
}
