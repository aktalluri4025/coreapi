using Corewebapi.Models.Domain;

namespace Corewebapi.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>>GetAllAsync();
    }
}
