using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCL_WEB.Models
{
    public class ContactFormModel
    {
        [Required]
        public string ListingId { get; set; }
        public string DealerName { get; set; }
        public string DealerUrl { get; set; }
        public string StockNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
