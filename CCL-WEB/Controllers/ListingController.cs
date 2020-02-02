using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCL_WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace CCL_WEB.Controllers
{
    public class ListingController : Controller
    {
        public ActionResult Index(List<Listing> listings)
        {
            return View(listings);
        }
    }
}