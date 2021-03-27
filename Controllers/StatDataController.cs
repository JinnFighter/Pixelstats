using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pixelstats.Controllers
{
    public class StatDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
