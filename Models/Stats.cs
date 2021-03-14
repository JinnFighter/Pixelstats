using System.Collections.Generic;

namespace Pixelstats.Models
{
    public class Stats
    {
        public int Id { get; set; }
        public virtual List<GameMode> GameModes { get; set; }
    }
}
