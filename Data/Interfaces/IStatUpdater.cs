using Pixelstats.Models;

namespace Pixelstats.Data.Interfaces
{
    public interface IStatUpdater
    {
        void AddStats(StatData statData);
    }
}
