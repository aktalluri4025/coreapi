using Corewebapi.Data;
using Corewebapi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Corewebapi.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        public readonly CoreDbContext coreDbContext;

        public WalkRepository(CoreDbContext coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await coreDbContext.AddAsync(walk);
            await coreDbContext.SaveChangesAsync();
            return walk;


        }

        public async Task<Walk> DeleteAsync(Guid Id)
        {
            var walk = await coreDbContext.Walks.FindAsync(Id);

            if (walk == null)
            {
                return null;
            }

            coreDbContext.Walks.Remove(walk);
            await coreDbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await coreDbContext.Walks
                .Include(x=>x.Region)
                .Include(x=>x.walkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid Id)
        {
            var walk = await coreDbContext.Walks.Include(x => x.Region)
                .Include(x => x.walkDifficulty).FirstOrDefaultAsync(x => x.Id == Id);
            return walk;
        }

        public async Task<Walk> UpdateAsync(Guid Id, Walk walk)
        {
            var exwalk = await coreDbContext.Walks.FirstOrDefaultAsync(x => x.Id == Id);

            if (exwalk == null)
            {
                return null;
            }

            exwalk.Name = walk.Name;
            exwalk.Length = walk.Length;
            exwalk.RegionId = walk.RegionId;
            exwalk.WalkDifficultyId = walk.WalkDifficultyId;

            await coreDbContext.SaveChangesAsync();

            return exwalk;
        }
    }
}
