using Pixelstats.Models;
using System.Collections.Generic;

namespace Pixelstats.ViewModels
{
    public class StatsListViewModel
    {
        public IEnumerable<StatData> Stats { get; set; }
    }
}
