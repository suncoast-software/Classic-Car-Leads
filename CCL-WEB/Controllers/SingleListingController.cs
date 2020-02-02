using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCL_WEB.Helpers;
using CCL_WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace CCL_WEB.Controllers
{
    public class SingleListingController : Controller
    {
        private readonly CCLdbContext context;
        private ListingHelper listingHelper;

        public SingleListingController(CCLdbContext context)
        {
            this.context = context;
            listingHelper = new ListingHelper(context);
        }
        //GET: '/SingleListing'
        public IActionResult Index(int? id)
        {
            var listing = context.Listing.Find(id);
            return View(listing);
        }

        public IActionResult GoToDealerSite(string[] listing)
        {
            //this will add the dealer to the database and set a timestamp when the user clicks the dealer url link
            string stockNum = "103555";
            string dealerUrl = "https://www.gtautolounge.com/classic-cars-sacramento?searchfor=YearMakeModel&searchtext=" + stockNum + "&inventorysearch=1";

            var dealer = new Dealer
            {
                ListingId = listing[0],
                DealerName = listing[1],
                DealerUrl = listing[2],
                DateVisited = DateTime.Now
            };
            context.Dealer.Add(dealer);
            context.SaveChanges();

            return Redirect(listing[2]);
        }
    }
}