using Pixelstats.Models;
using System.Collections.Generic;

namespace Pixelstats.Data.Interfaces
{
    public interface IGetGameModes
    {
        IEnumerable<GameMode> GetGameModes();
    }
}
