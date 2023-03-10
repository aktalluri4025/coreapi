using AutoMapper;
using Corewebapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Corewebapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;
        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllWalks()
        {
            var walks = await walkRepository.GetAllAsync();

            var walksDTO = mapper.Map<List<Models.DTO.Walk>>(walks);


            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkAsync")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            var walk = await walkRepository.GetAsync(id);
            if (walk == null)
            {
                return NotFound();
            }

            var walkDTO = mapper.Map<Models.DTO.Walk>(walk);


            return Ok(walkDTO);
        }

        [HttpPost]

        public async Task<IActionResult> AddWalkAsync(Models.DTO.AddWalkRequest addWalkRequest)
        {
            var walk = new Models.Domain.Walk()
            {
                Name = addWalkRequest.Name,
                Length= addWalkRequest.Length,
                RegionId= addWalkRequest.RegionId,
                WalkDifficultyId= addWalkRequest.WalkDifficultyId
            };

            walk = await walkRepository.AddAsync(walk);

            var walkDTO = new Models.DTO.Walk
            {
                Name = walk.Name,
                Length = walk.Length,
                RegionId= walk.RegionId,
                WalkDifficultyId= walk.WalkDifficultyId
            };

            return CreatedAtAction(nameof(GetWalkAsync), new { id = walkDTO.Id }, walkDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync(Guid id)
        {
            var walk = await walkRepository.DeleteAsync(id);
            if (walk == null)
            {
                return NotFound();
            }

            var walkDTO = mapper.Map<Models.DTO.Walk>(walk);

            return Ok(walkDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateWalkRequest updateWalkRequest)
        {
            var walk = new Models.Domain.Walk()
            {
                Name = updateWalkRequest.Name,
                Length = updateWalkRequest.Length,
                RegionId= updateWalkRequest.RegionId,
                WalkDifficultyId= updateWalkRequest.WalkDifficultyId
            };

            walk = await walkRepository.UpdateAsync(id, walk);

            if (walk == null)
            {
                return NotFound();
            }

            var walkDTO = new Models.DTO.Walk()
            {
                Id = walk.Id,
                Name = walk.Name,
                Length = walk.Length,
                RegionId = walk.RegionId,
                WalkDifficultyId = walk.WalkDifficultyId,
            };

            return Ok(walkDTO);




        }
    }
}
