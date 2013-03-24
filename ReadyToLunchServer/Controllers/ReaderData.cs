using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadyToLunchRole.Controllers
{
    public class ReaderData
    {

        public int SchoolDistrictId { get; set; }
        public String SchoolDistrictName { get; set; }
        public DateTime SchoolDistrictDateUpdated { get; set; }
        public int MenuGroupId { get; set; }
        public String MenuGroupName { get; set; }
        public String MenuGroupDescription { get; set; }
        public int MenuGroupOrderBy { get; set; }
        public DateTime MenuGroupDateUpdated { get; set; }
        public int MenuId { get; set; }
        public DateTime MenuDate { get; set; }
        public int IsDayOff { get; set; }
        public int OfferingId { get; set; }
        public String OfferingName { get; set; }
        public String OfferingAttribute { get; set; }
        public int OfferingOrderBy { get; set; }

    }

}