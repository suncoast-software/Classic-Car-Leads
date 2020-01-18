using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CCL_WEB.Models;
using CCL_WEB.Helpers;

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
            var years = homeHelper.GetYears();
            var makes = homeHelper.GetMakes();
            var models = homeHelper.GetModels();

            ViewBag.years = years;
            ViewBag.makes = makes;
            ViewBag.models = models;

            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Index(string year, string make, string model)
        {
            var years = homeHelper.GetYears();
            var makes = homeHelper.GetMakes();
            var models = homeHelper.GetModels();

            var listings = homeHelper.Search(year, make, model);

            ViewBag.years = years;
            ViewBag.makes = makes;
            ViewBag.models = models;

            return View(listings);
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
    }
}
