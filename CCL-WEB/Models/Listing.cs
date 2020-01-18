using System;
using System.Collections.Generic;

namespace CCL_WEB.Models
{
    public partial class Listing
    {
        public int Id { get; set; }
        public string ListingId { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Location { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Desc { get; set; }
        public string Transmission { get; set; }
        public string Engine { get; set; }
        public string Vin { get; set; }
        public string StockNumber { get; set; }
        public string DealerName { get; set; }
        public string DealerUrl { get; set; }
        public string MainImgUrl { get; set; }
        public string Status { get; set; }
    }
}
