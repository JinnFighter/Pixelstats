using Pixelstats.Models;
using Pixelstats.ViewModels;
using System.Collections.Generic;

namespace Pixelstats.Data.Interfaces
{
    interface IGetStatViewModelsService
    {
        IEnumerable<StatDataViewModel> GetViewModels(IEnumerable<StatData> datas);
    }
}
