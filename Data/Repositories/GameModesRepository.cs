using Pixelstats.Data.Interfaces;
using Pixelstats.Models;
using System.Collections.Generic;

namespace Pixelstats.Data.Repositories
{
    public class GameModesRepository : IGetGameModes
    {
        private readonly AppDbContext _context;

        public GameModesRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GameMode> GetGameModes() => _context.GameModes;
    }
}
