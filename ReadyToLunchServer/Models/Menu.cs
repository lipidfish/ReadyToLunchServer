using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadyToLunchRole.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public DateTime MenuDate { get; set; }
        public List<Offering> Offerings { get; set; }

        public Menu()
        {
            Offerings = new List<Offering>();            
        }

    }
}