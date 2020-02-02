using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CCL_WEB.Models;
using CCL_WEB.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CCL_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CCLdbContext context;
        private HomeHelper homeHelper;

        public HomeController(ILogger<HomeController> logger, CCLdbContext context)
        {
            _logger = logger;
            this.context = context;
            homeHelper = new HomeHelper(context);
        }

        //GET: '/'
        public IActionResult Index()
        {
            ListingViewModel mv = new ListingViewModel();
            var years = context.Year.Distinct().OrderBy(m => m.Value).ToList();
            foreach (var y in years)
            {
                if (y.Value.Length > 4 || y.Value.Equals("9831"))
                {
                    
                }
                else
                 mv.Years.Add(new SelectListItem { Text = y.Value, Value = y.Value });
            }
            return View(mv);
        }

        //Post
        [HttpPost]
        public IActionResult Index(string year, string make, string model, int? page)
        {
            ListingViewModel mv = new ListingViewModel();
            var years = context.Year.Distinct().OrderByDescending(m => m.Value).ToList();
            foreach (var y in years)
            {
                mv.Years.Add(new SelectListItem { Text = y.Value, Value = y.Value });
            }

            if (year != null)
            {
                var makes = context.make.Where(m => m.Year.Equals(year)).Distinct().OrderBy(m => m.Value).ToList();
                foreach (var m in makes)
                {
                    mv.Makes.Add(new SelectListItem { Text = m.Value, Value = m.Value });
                }
            }

            if (make != null)
            {
                var models = context.model.Where(m => m.Make.Equals(make)).Distinct().OrderBy(m => m.Value).ToList();
                List<string> modelList = new List<string>();

                foreach (var m in models)
                {
                   if (!modelList.Contains(m.Value))
                    {
                        modelList.Add(m.Value);
                        mv.Models.Add(new SelectListItem { Text = m.Value, Value = m.Value });
                    }
                }
                    
            }
            if (model != null)
            {
                var pageNumber = page ?? 1;
                int pageSize = 25;
                var listings = context.Listing.Where(m => m.Year.Equals(year) && m.Make.Equals(make) && m.Model.Equals(model)).ToList();
                mv.Listings.AddRange(listings);
                //return RedirectToAction("Index", "Listing", listings);
            }
            return View(mv);
           
        }

        public IActionResult Success(List<Listing> listings)
        {
            return View(listings);
        }

        [HttpGet]
        public JsonResult GetMakes(string year)
        {
            return Json(new SelectList(context.make.Where(m => m.Year.Equals(year)), "Id", "Year"));
        }

        public IActionResult Models(string make)
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<Listing> GetYear()
        {
            List<Listing> years = context.Listing.ToList();
            return years;
        }

    }
}
