using Microsoft.AspNetCore.Mvc;
using Pixelstats.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pixelstats.Controllers
{
    public class StatDataController : Controller
    {
        private readonly IGetStats _stats;

        public StatDataController(IGetStats stats)
        {
            _stats = stats;
        }

        public IActionResult Index(string name)
        {
            return View();
        }
    }
}
