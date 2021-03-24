using Microsoft.AspNetCore.Mvc;
using Pixelstats.Data.Interfaces;
using Pixelstats.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pixelstats.Controllers
{
    public class StatsController : Controller
    {
        private readonly IGetStats _stats;

        public StatsController(IGetStats stats)
        {
            _stats = stats;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Statistics";

            var stats = new List<StatDataViewModel>();

            var allStats = _stats.GetStats.ToList();
            if (allStats.Count == 0)
                throw new Exception("STATS EMPTY");
            foreach(var stat in _stats.GetStats)
            {
                stats.Add(new StatDataViewModel
                {
                    GameModeName = stat.GameMode.Name,
                    Time = string.Format("{0:00} m:{1:00} s", (int)(stat.Time / 60f) % 60,
                    (int)(stat.Time % 60)),
                    CorrectAnswers = (uint)stat.CorrectAnswers,
                    WrongAnswers = (uint)stat.WrongAnswers,
                    SuccessRate = stat.WrongAnswers == 0 ? 0 : (int)((double)stat.CorrectAnswers / (double)(stat.CorrectAnswers + stat.WrongAnswers) * 100)
                });
            }

            return PartialView("_StatsListPartial", stats);
        }
    }
}
