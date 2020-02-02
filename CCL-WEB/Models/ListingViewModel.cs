using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCL_WEB.Models
{
    public class ListingViewModel
    {
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public List<SelectListItem> Years { get; set; }
        public List<SelectListItem> Makes { get; set; }
        public List<SelectListItem> Models { get; set; }
        public List<Listing> Listings { get; set; }

        public ListingViewModel()
        {
            this.Years = new List<SelectListItem>();
            this.Makes = new List<SelectListItem>();
            this.Models = new List<SelectListItem>();
            this.Listings = new List<Listing>();
        }
    }
}
