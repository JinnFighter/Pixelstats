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

        public IActionResult Index(string userName)
        {
            var user = _users.GetUsers().FirstOrDefault(user => user.UserName == userName);
            var stats = _statDatas.GetStats.Where(statData => statData.User == user);


            var best = stats.OrderBy(stat => stat.WrongAnswers == 0 ? 0 : (int)((double)stat.CorrectAnswers / (double)(stat.CorrectAnswers + stat.WrongAnswers) * 100)).First();
            var bestStats = new BestStatsViewModel
            {
                BestRating = 3,
                BestMode = best.GameMode.Name,
                BestPercentage = best.WrongAnswers == 0 ? 0 : (int)((double)best.CorrectAnswers / (double)(best.CorrectAnswers + best.WrongAnswers) * 100)

            };
            var viewModel = new StatsViewModel
            {
                StatList = new StatsListViewModel
                {
                    Stats = _statViewModelService.GetViewModels(stats),
                },
                BestStats = bestStats
            };
            ViewBag.Title = userName;
            ViewBag.Group = user.StudyGroup;
            return View(viewModel);
        }
    }
}
