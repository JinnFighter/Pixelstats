using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
namespace Pixelstats.Controllers
{
    public class StatsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Statistics";
            return View();
        }
    }
}
