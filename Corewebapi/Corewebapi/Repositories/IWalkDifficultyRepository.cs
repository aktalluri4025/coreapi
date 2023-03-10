using Corewebapi.Models.Domain;

namespace Corewebapi.Repositories
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();

        Task<WalkDifficulty> GetAsync(Guid Id);

        Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty);

        Task<WalkDifficulty> DeleteAsync(Guid Id);

        Task<WalkDifficulty> UpdateAsync(Guid Id, WalkDifficulty walkDifficulty);
    }
}
