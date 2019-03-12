using BusinessLayer.AppEntities;
using BusinessLayer.Configuration;
using DataAccessLayer.DAL;
using DataAccessLayer.Models;
using GalleryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Text;

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

            UserDAL b = new UserDAL(_settings);

            return View(b.Select().Items);
           // return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            var data = Encoding.ASCII.GetBytes("password");
            UserEntity us = new UserEntity() {    Name = "Andrew",  IdRole = 3, Password = data,
                ProfilePictName = "andi", Email = "andi@wp.pl"};

            UserDAL b = new UserDAL(_settings);
            b.Add(us);
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
