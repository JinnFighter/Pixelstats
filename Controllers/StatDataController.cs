using Microsoft.AspNetCore.Mvc;
using Pixelstats.Data.Interfaces;
using Pixelstats.ViewModels;
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
            var stats = new List<StatDataViewModel>();
            foreach (var stat in _stats.GetStats.Where(stat => stat.User.UserName == name).OrderByDescending(stat => stat.Id))
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

            return View(stats);
        }
    }
}
