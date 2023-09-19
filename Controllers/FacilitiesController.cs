using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Exceptions;
using SeatManagement.Interfaces;
using SeatManagement.Models;

namespace SeatManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        private readonly IFacilitiesService _facilitiesService;

        public FacilitiesController(IFacilitiesService facilitiesService)
        {
            _facilitiesService = facilitiesService;
        }

        // GET: api/Facilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facility>>> GetFacility()
        {
            return Ok(_facilitiesService.GetFacility());
        }

        // GET: api/Facilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facility>> GetFacility(int id)
        {
            var facility = _facilitiesService.GetFacility(id);

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
            _facilitiesService.PutFacility(facility);
            return Ok();
        }

        // POST: api/Facilities
        [HttpPost]
        public async Task<ActionResult<Facility>> PostFacility(FacilityDTO facilityDTO)
        {
            if(facilityDTO == null)
            {
                return BadRequest();
            }
            try
            {
                var facility = _facilitiesService.PostFacility(facilityDTO);

                return CreatedAtAction("GetFacility", new { id = facility.Id }, facility);
            }
            catch (ExceptionWhileAdding ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        // DELETE: api/Facilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacility(int id)
        {
            _facilitiesService.DeleteFacility(id);
            return NoContent();
        }
    }
}
