using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;

namespace SeatManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomsController : ControllerBase
    {
        private readonly IRepository<MeetingRoom> _repository;

        public MeetingRoomsController(IRepository<MeetingRoom> repository)
        {
            _repository = repository;
        }

        // GET: api/MeetingRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingRoom>>> GetMeetingRoom()
        {
            return _repository.GetAll();
        }

        // GET: api/MeetingRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingRoom>> GetMeetingRoom(int id)
        {
            var meetingRoom = _repository.GetById(id);

            if (meetingRoom == null)
            {
                return NotFound();
            }

            return meetingRoom;
        }

        // PUT: api/MeetingRooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetingRoom(MeetingRoom meetingRoom)
        {
            var item = _repository.GetById(meetingRoom.Id);
            if (item == null)
            {
                return NotFound();
            }
            // Update any properties of MeetingRoom as needed
            item.Name = meetingRoom.Name;
            item.FacilityId = meetingRoom.FacilityId;
            item.SeatCount = meetingRoom.SeatCount;
            // Add any other properties you need to update
            _repository.Update(item);
            return Ok();
        }

        // POST: api/MeetingRooms
        [HttpPost]
        public async Task<ActionResult<MeetingRoom>> PostMeetingRoom(MeetingRoomDTO meetingRoomDTO)
        {
            var meetingRoom = new MeetingRoom
            {
                Name = meetingRoomDTO.Name,
                FacilityId = meetingRoomDTO.FacilityId,
                SeatCount = meetingRoomDTO.SeatCount,
                // Add any other properties you need to set
            };
            _repository.Add(meetingRoom);

            return CreatedAtAction("GetMeetingRoom", new { id = meetingRoom.Id }, meetingRoom);
        }

        // DELETE: api/MeetingRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeetingRoom(int id)
        {
            var meetingRoom = _repository.GetById(id);
            if (meetingRoom == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return NoContent();
        }
    }
}
