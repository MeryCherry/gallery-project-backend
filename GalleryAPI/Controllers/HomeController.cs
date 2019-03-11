using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GalleryAPI.Models;
using DataAccessLayer.Models;
using DataAccessLayer.DAL;
using Microsoft.Extensions.Options;
using Bootstrap;

namespace GalleryAPI.Controllers
{
    public class HomeController : Controller
    {
        private Gallery_dbContext shopContext;

        private IOptions<AppSettingsModel> _settings;
        public HomeController( IOptions<AppSettingsModel> settings)
        {
           // shopContext = sc;
            this._settings = settings;
        }

        public IActionResult Index()
        {

            CountryDAL b = new CountryDAL(_settings);

            return View(b.Select().Items);
           // return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}
