using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadyToLunchRole.Models
{
    public class MenuGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrderBy { get; set; }
        public DateTime DateUpdated { get; set; }
        public List<Menu> Menus { get; set; }

        public MenuGroup()
        {
            Menus = new List<Menu>();
        }
    }
}