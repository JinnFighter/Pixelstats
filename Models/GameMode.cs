using System.Collections.Generic;

namespace Pixelstats.Models
{
    public class GameMode
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<StatData> StatDatas { get; set; }
    }
}
