using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Coursework.Models;
using Microsoft.AspNetCore.Identity;

namespace Coursework.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            
            return View();
        }
  
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Announcements()
        {
            
            return View();
        }

        public IActionResult Settings()
        {

            return View();
        }
        public IActionResult Members()
        {

            return View();
        }
        public IActionResult Statistics()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
