using Pixelstats.Data.Interfaces;
using Pixelstats.Models;
using Pixelstats.ViewModels;
using System;
using System.Collections.Generic;

namespace Pixelstats.Data.Services
{
    public class GetStatViewModelsService : IGetStatViewModelsService
    {
        public IEnumerable<StatDataViewModel> GetViewModels(IEnumerable<StatData> datas)
        {
            var stats = new List<StatDataViewModel>();
            foreach(var data in datas)
            {
                stats.Add(new StatDataViewModel
                {
                    GameModeName = data.GameMode.Name,
                    Time = string.Format("{0:00} m:{1:00} s", (int)(data.Time / 60f) % 60, (int)(data.Time % 60)),
                    CorrectAnswers = (uint)data.CorrectAnswers,
                    WrongAnswers = (uint)data.WrongAnswers,
                    SuccessRate = data.WrongAnswers == 0 ? 0 : (int)((double)data.CorrectAnswers / (double)(data.CorrectAnswers + data.WrongAnswers) * 100)
                });
            }
            return stats;
        }
    }
}
