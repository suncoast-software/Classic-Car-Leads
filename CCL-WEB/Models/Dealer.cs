using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CCL_WEB.Models
{
    public partial class Dealer
    {
        [Key]
        public int Id { get; set; }
        public string ListingId { get; set; }
        public string DealerName { get; set; }
        public string DealerUrl { get; set; }
        public string StockNumber { get; set; }
        public DateTime DateVisited { get; set; }

    }
}
