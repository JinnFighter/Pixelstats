using Microsoft.AspNetCore.Mvc;
using Pixelstats.Data.Interfaces;
using System.Linq;

namespace Pixelstats.Controllers
{
    public class StatDataController : Controller
    {
        private readonly IGetStats _stats;
        private readonly IGetStatViewModelsService _viewModelService;

        public StatDataController(IGetStats stats, IGetStatViewModelsService viewModelService)
        {
            _stats = stats;
            _viewModelService = viewModelService;
        }

        public IActionResult Index(string name)
        {
            var stats = _stats.GetStats.Where(stat => stat.User.UserName == name).OrderByDescending(stat => stat.Id);
            var viewModels = _viewModelService.GetViewModels(stats);
            return View(viewModels);
        }

        public IActionResult Game(int id)
        {
            var statData = _stats.GetStats.FirstOrDefault(stat => stat.Id == id);

            return View();
        }
    }
}
