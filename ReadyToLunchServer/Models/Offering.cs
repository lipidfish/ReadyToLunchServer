using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadyToLunchRole.Models
{
    public class Offering
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int SchoolDistrictId { get; set; }
        public int OrderBy { get; set; }
        public List<string> Attributes { get; set; }

        public Offering() {
            Attributes = new List<string>();
        }

    }
}