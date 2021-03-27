using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pixelstats.Models;

namespace Pixelstats
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<StatData> StatDatas { get; set; }
        public DbSet<GameMode> GameModes { get; set; }
    }
}
