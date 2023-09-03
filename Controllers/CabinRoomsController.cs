using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;

namespace SeatManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinRoomsController : ControllerBase
    {
        private readonly IRepository<CabinRoom> _repository;

        public CabinRoomsController(IRepository<CabinRoom> repository)
        {
            _repository = repository;
        }

        // GET: api/CabinRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CabinRoom>>> GetCabinRoom()
        {
            return _repository.GetAll();
        }

        // GET: api/CabinRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CabinRoom>> GetCabinRoom(int id)
        {
            var cabinRoom = _repository.GetById(id);

            if (cabinRoom == null)
            {
                return NotFound();
            }

            return cabinRoom;
        }

        // PUT: api/CabinRooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCabinRoom(CabinRoom cabinRoom)
        {
            var item = _repository.GetById(cabinRoom.Id);
            if (item == null)
            {
                return NotFound();
            }
            // Update any properties of CabinRoom as needed
            item.Name = cabinRoom.Name;
            item.EmployeeId = cabinRoom.EmployeeId;
            item.FacilityId = cabinRoom.FacilityId;
            // Add any other properties you need to update
            _repository.Update(item);
            return Ok();
        }

        // POST: api/CabinRooms
        [HttpPost]
        public async Task<ActionResult<CabinRoom>> PostCabinRoom(CabinRoomDTO cabinRoomDTO)
        {
            var cabinRoom = new CabinRoom
            {
                Name = cabinRoomDTO.Name,
                FacilityId = cabinRoomDTO.FacilityId,
                EmployeeId = cabinRoomDTO.EmployeeId
                // Add any other properties you need to set
            };
            _repository.Add(cabinRoom);

            return CreatedAtAction("GetCabinRoom", new { id = cabinRoom.Id }, cabinRoom);
        }

        // DELETE: api/CabinRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCabinRoom(int id)
        {
            var cabinRoom = _repository.GetById(id);
            if (cabinRoom == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return NoContent();
        }
    }
}
