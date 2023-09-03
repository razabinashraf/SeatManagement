using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;

namespace SeatManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocatedAssetsController : ControllerBase
    {
        private readonly IRepository<AllocatedAsset> _repository;

        public AllocatedAssetsController(IRepository<AllocatedAsset> repository)
        {
            _repository = repository;
        }

        // GET: api/AllocatedAssets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllocatedAsset>>> GetAllocatedAsset()
        {
            return _repository.GetAll();
        }

        // GET: api/AllocatedAssets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllocatedAsset>> GetAllocatedAsset(int id)
        {
            var allocatedAsset = _repository.GetById(id);

            if (allocatedAsset == null)
            {
                return NotFound();
            }

            return allocatedAsset;
        }

        // PUT: api/AllocatedAssets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllocatedAsset(AllocatedAsset allocatedAsset)
        {
            var item = _repository.GetById(allocatedAsset.Id);
            if (item == null)
            {
                return NotFound();
            }
            // Update any properties of AllocatedAsset as needed
            item.MeetingRoomId = allocatedAsset.MeetingRoomId;
            item.Quantity = allocatedAsset.Quantity;
            item.AssetId = allocatedAsset.AssetId;
            _repository.Update(item);
            return Ok();
        }

        // POST: api/AllocatedAssets
        [HttpPost]
        public async Task<ActionResult<AllocatedAsset>> PostAllocatedAsset(AllocatedAssetDTO allocatedAssetDTO)
        {
            var allocatedAsset = new AllocatedAsset
            {
                
                AssetId = allocatedAssetDTO.AssetId,
                // Add any other properties you need to set
            };
            _repository.Add(allocatedAsset);

            return CreatedAtAction("GetAllocatedAsset", new { id = allocatedAsset.Id }, allocatedAsset);
        }

        // DELETE: api/AllocatedAssets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllocatedAsset(int id)
        {
            var allocatedAsset = _repository.GetById(id);
            if (allocatedAsset == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return NoContent();
        }
    }
}
