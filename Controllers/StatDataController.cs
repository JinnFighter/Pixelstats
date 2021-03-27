using Microsoft.AspNetCore.Mvc;
using Pixelstats.Data.Interfaces;
using Pixelstats.Data.Services;
using System.Linq;

namespace Pixelstats.Controllers
{
    public class StatDataController : Controller
    {
        private readonly IGetStats _stats;
        private readonly IGetStatViewModelsService _viewModelService;

        public StatDataController(IGetStats stats)
        {
            _stats = stats;
            _viewModelService = new GetStatViewModelsService();
        }

        public IActionResult Index(string name)
        {
            var stats = _stats.GetStats.Where(stat => stat.User.UserName == name).OrderByDescending(stat => stat.Id);
            var viewModels = _viewModelService.GetViewModels(stats);
            return View(viewModels);
        }
    }
}
