using Corewebapi.Data;
using Corewebapi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Corewebapi.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly CoreDbContext coreDbContext;
        public RegionRepository(CoreDbContext coreDbContext) 
        {
            this.coreDbContext=coreDbContext;
        }
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await coreDbContext.Regions.ToListAsync();
        }
    }
}
