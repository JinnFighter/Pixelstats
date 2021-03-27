using Pixelstats.Models;
using Pixelstats.ViewModels;
using System.Collections.Generic;

namespace Pixelstats.Data.Interfaces
{
    public interface IGetStatViewModelsService
    {
        IEnumerable<StatDataViewModel> GetViewModels(IEnumerable<StatData> datas);
    }
}
