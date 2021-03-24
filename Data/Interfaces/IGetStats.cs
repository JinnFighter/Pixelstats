using Pixelstats.Models;
using System.Collections.Generic;

namespace Pixelstats.Data.Interfaces
{
    public interface IGetStats
    {
        IEnumerable<StatData> GetStats { get; }
    }
}
