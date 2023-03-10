using Corewebapi.Models.Domain;

namespace Corewebapi.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();

        Task<Walk> GetAsync(Guid Id);

        Task<Walk> AddAsync(Walk walk);

        Task<Walk> DeleteAsync(Guid Id);

        Task<Walk> UpdateAsync(Guid Id, Walk walk);
    }
}
