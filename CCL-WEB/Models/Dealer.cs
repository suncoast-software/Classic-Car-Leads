using System;
using System.Collections.Generic;

namespace CCL_WEB.Models
{
    public partial class Dealer
    {
        public int Id { get; set; }
        public string ListingId { get; set; }
        public string DealerName { get; set; }
        public string DealerUrl { get; set; }
        public DateTime DateVisited { get; set; }
    }
}
