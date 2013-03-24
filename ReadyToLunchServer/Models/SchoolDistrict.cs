using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadyToLunchRole.Models
{
    public class SchoolDistrict
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateUpdated { get; set; }
        public List<MenuGroup> MenuGroups { get; set; }

        public SchoolDistrict()
        {
            MenuGroups = new List<MenuGroup>();
        }

    }
}