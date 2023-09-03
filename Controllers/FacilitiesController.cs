using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;

namespace SeatManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        private readonly IRepository<Facility> _repository;

        public FacilitiesController(IRepository<Facility> repository)
        {
            _repository = repository;
        }

        // GET: api/Facilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facility>>> GetFacility()
        {
            return _repository.GetAll();
        }

        // GET: api/Facilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facility>> GetFacility(int id)
        {
            var facility = _repository.GetById(id);

            if (facility == null)
            {
                return NotFound();
            }

            return facility;
        }

        // PUT: api/Facilities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacility(Facility facility)
        {
            var item = _repository.GetById(facility.Id);
            if (item == null)
            {
                return NotFound();
            }
            // Update any properties of Facility as needed
            item.Name = facility.Name;
            item.FloorNumber = facility.FloorNumber;
            item.CityId = facility.CityId;
            item.BuildingId = facility.BuildingId;
            // Add any other properties you need to update
            _repository.Update(item);
            return Ok();
        }

        // POST: api/Facilities
        [HttpPost]
        public async Task<ActionResult<Facility>> PostFacility(FacilityDTO facilityDTO)
        {
            var facility = new Facility
            {
                Name = facilityDTO.Name,
                FloorNumber = facilityDTO.FloorNumber,
                CityId = facilityDTO.CityId,
                BuildingId = facilityDTO.BuildingId,
                // Add any other properties you need to set
            };
            _repository.Add(facility);

            return CreatedAtAction("GetFacility", new { id = facility.Id }, facility);
        }

        // DELETE: api/Facilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacility(int id)
        {
            var facility = _repository.GetById(id);
            if (facility == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return NoContent();
        }
    }
}
