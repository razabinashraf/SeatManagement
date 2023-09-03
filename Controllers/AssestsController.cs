using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;

namespace SeatManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IRepository<Asset> _repository;

        public AssetsController(IRepository<Asset> repository)
        {
            _repository = repository;
        }

        // GET: api/Assets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAsset()
        {
            return _repository.GetAll();
        }

        // GET: api/Assets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetAsset(int id)
        {
            var asset = _repository.GetById(id);

            if (asset == null)
            {
                return NotFound();
            }

            return asset;
        }

        // PUT: api/Assets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsset(Asset asset)
        {
            var item = _repository.GetById(asset.Id);
            if (item == null)
            {
                return NotFound();
            }
            item.Name = asset.Name;
            // Add any other properties you need to update
            _repository.Update(item);
            return Ok();
        }

        // POST: api/Assets
        [HttpPost]
        public async Task<ActionResult<Asset>> PostAsset(AssetDTO assetDTO)
        {
            var asset = new Asset
            {
                Name = assetDTO.Name,
                // Add any other properties you need to set
            };
            _repository.Add(asset);

            return CreatedAtAction("GetAsset", new { id = asset.Id }, asset);
        }

        // DELETE: api/Assets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            var asset = _repository.GetById(id);
            if (asset == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return NoContent();
        }
    }
}
