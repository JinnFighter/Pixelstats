using Microsoft.EntityFrameworkCore;
using Pixelstats.Data.Interfaces;
using Pixelstats.Models;
using System.Collections.Generic;

namespace Pixelstats.Data.Repositories
{
    public class StatsRepository : IGetStats
    {
        private readonly AppDbContext _context;

        public StatsRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<StatData> GetStats => _context.StatDatas.Include(statData => statData.GameMode).Include(statData => statData.User);
    }
}
