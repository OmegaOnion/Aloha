﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Coursework.Controllers
{
    [Authorize(Roles = "Member")]
    public class MemberHomeController : Controller
    {
        // GET: /<controller>/
        
        public IActionResult Index()
        {
            return View();
            
        }
    }
}
