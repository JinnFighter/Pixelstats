using Microsoft.AspNetCore.Mvc;
using Pixelstats.Data.Interfaces;
using Pixelstats.ViewModels;
using System.Linq;

namespace Pixelstats.Controllers
{
    public class StatsController : Controller
    {
        private readonly IGetUsers _users;
        private readonly IGetStats _statDatas;
        private readonly IGetStatViewModelsService _statViewModelService;

        public StatsController(IGetUsers users, IGetStats statDatas, IGetStatViewModelsService service)
        {
            _users = users;
            _statDatas = statDatas;
            _statViewModelService = service;
        }

        public IActionResult Index()
        {
            var user = _users.GetUsers().First();
            var userName = user.UserName;
            
            var stats = _statDatas.GetStats.Where(statData => statData.User.UserName == userName);
            var viewModel = new StatsViewModel
            {
                StatList = new StatsListViewModel
                {
                    Stats = _statViewModelService.GetViewModels(stats)
                }
            };
            ViewBag.Title = userName;
            return View(viewModel);
        }
    }
}
