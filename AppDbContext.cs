using Microsoft.EntityFrameworkCore;

namespace Pixelstats
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
