using Corewebapi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Corewebapi.Data
{
    public class CoreDbContext:DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options): base(options)
        {

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }

    }
}
