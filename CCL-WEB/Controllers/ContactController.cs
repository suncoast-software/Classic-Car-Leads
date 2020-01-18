using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CCL_WEB.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult ContactUs(string[] listing)
        {
            ViewBag.listingId = listing[0];
            ViewBag.dealerName = listing[1];
            ViewBag.dealerUrl = listing[2];
            ViewBag.stockNumber = listing[3];

            return View();
        }
    }
}