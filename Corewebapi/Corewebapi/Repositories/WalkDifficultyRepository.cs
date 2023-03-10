using Corewebapi.Data;
using Corewebapi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Corewebapi.Repositories
{
    public class WalkDifficultyRepository:IWalkDifficultyRepository
    {
        private readonly CoreDbContext coreDbContext;

        public WalkDifficultyRepository(CoreDbContext coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            await coreDbContext.AddAsync(walkDifficulty);
            await coreDbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid Id)
        {
            var walkDifficulty = await coreDbContext.WalkDifficulty.FindAsync(Id);

            if (walkDifficulty == null)
            {
                return null;
            }

            coreDbContext.WalkDifficulty.Remove(walkDifficulty);
            await coreDbContext.SaveChangesAsync();

            return walkDifficulty;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await coreDbContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid Id)
        {
            var walkDifficulty = await coreDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == Id);
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid Id, WalkDifficulty walkDifficulty)
        {
            var exwalkDifficulty = await coreDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == Id);

            if (exwalkDifficulty == null)
            {
                return null;
            }

            exwalkDifficulty.Code = walkDifficulty.Code;

            await coreDbContext.SaveChangesAsync();

            return exwalkDifficulty;
        }
    }
}
