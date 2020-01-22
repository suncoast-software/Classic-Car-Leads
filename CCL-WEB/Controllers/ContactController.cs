using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCL_WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace CCL_WEB.Controllers
{
    public class ContactController : Controller
    {
        private readonly CCLdbContext context;

        public ContactController(CCLdbContext context)
        {
            this.context = context;

        }

        public IActionResult ContactUs(string[] listing)
        {
            ViewBag.listingId = listing[0];
            ViewBag.dealerName = listing[1];
            ViewBag.dealerUrl = listing[2];
            ViewBag.stockNumber = listing[3];

            return View();
        }

        [HttpPost]
        public IActionResult RequestInfo(string[] listing)
        {
            if (ModelState.IsValid)
            {
                ViewBag.listingId = listing[0];
                ViewBag.dealerName = listing[1];
                ViewBag.dealerUrl = listing[2];
                ViewBag.stockNumber = listing[3];

                Dealer dealer = new Dealer();
                dealer.ListingId = listing[0];
                dealer.DealerName = listing[1];
                dealer.DealerUrl = listing[2];
                dealer.StockNumber = listing[3];
                dealer.DateVisited = DateTime.Now;

                context.Add(dealer);
                context.SaveChanges();

                return View(nameof(Success));
            }


            return View(nameof(Failure));
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Failure()
        {
            return View();
        }
    }
}