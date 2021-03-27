using Microsoft.AspNetCore.Mvc;
using Pixelstats.Data.Interfaces;
using System.Linq;

namespace Pixelstats.Controllers
{
    public class StatsController : Controller
    {
        private readonly IGetUsers _users;

        public StatsController(IGetUsers users)
        {
            _users = users;
        }

        public IActionResult Index()
        {
            ViewBag.Title = _users.GetUsers().First().UserName;
            return View();
        }
    }
}
