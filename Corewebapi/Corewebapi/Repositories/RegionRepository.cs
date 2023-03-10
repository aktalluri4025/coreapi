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

        public async Task<Region> AddAsync(Region region)
        {
            region.Id=Guid.NewGuid();
            await coreDbContext.AddAsync(region);
            await coreDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid Id)
        {
            var region= await coreDbContext.Regions.FirstOrDefaultAsync(x=>x.Id==Id);

            if(region==null)
            {
                return null;
            }

            coreDbContext.Regions.Remove(region);
            await coreDbContext.SaveChangesAsync();

            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await coreDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid Id)
        {
            var region = await coreDbContext.Regions.FirstOrDefaultAsync(x => x.Id== Id);
            return region;
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var exregion = await coreDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(exregion==null)
            {
                return null;
            }

            exregion.Code=region.Code;
            exregion.Name=region.Name;
            exregion.Area=region.Area;
            exregion.Lat=region.Lat;
            exregion.Long = region.Long;
            exregion.Population=region.Population;

            await coreDbContext.SaveChangesAsync();

            return exregion;

        }
    }
}
