using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeatManagement.DTOs;
using SeatManagement.Models;
using System.Xml.Linq;

namespace SeatManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly IRepository<Building> _repository;

        public BuildingsController(IRepository<Building> repository)
        {
            _repository = repository;
        }

        // GET: api/Buildings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuilding()
        {
            string Name = HttpContext.Request.Query["Name"];
            // [FromQuery] string Name
            if (Name != null)
            {
                var filteredBuildings = _repository.GetAll().Where(building => building.Name == Name).ToList();
                return filteredBuildings;
            }
            return _repository.GetAll();
        }

        // GET: api/Buildings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> GetBuilding(int id)
        {
            var building = _repository.GetById(id);

            if (building == null)
            {
                return NotFound();
            }

            return building;
        }

        // PUT: api/Buildings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuilding(Building building)
        {
            var item = _repository.GetById(building.Id);
            if (item == null)
            {
                return NotFound();
            }
            // Update any properties of Building as needed
            item.Name = building.Name;
            item.Abbreviation = building.Abbreviation;
            // Add any other properties you need to update
            _repository.Update(item);
            return Ok();
        }

        // POST: api/Buildings
        [HttpPost]
        public async Task<ActionResult<Building>> PostBuilding(BuildingDTO buildingDTO)
        {
            var building = new Building
            {
                Name = buildingDTO.Name,
                Abbreviation = buildingDTO.Abbrevation
                // Add any other properties you need to set
            };
            _repository.Add(building);

            return CreatedAtAction("GetBuilding", new { id = building.Id }, building);
        }

        // DELETE: api/Buildings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuilding(int id)
        {
            var building = _repository.GetById(id);
            if (building == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return NoContent();
        }
    }
}
