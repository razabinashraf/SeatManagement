// MeetingRoomsController.cs
using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;

[Route("api/[controller]")]
[ApiController]
public class MeetingRoomsController : ControllerBase
{
    private readonly IMeetingRoomsService _meetingRoomsService;

    public MeetingRoomsController(IMeetingRoomsService meetingRoomsService)
    {
        _meetingRoomsService = meetingRoomsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<MeetingRoom>> GetMeetingRoom()
    {
        return Ok(_meetingRoomsService.GetMeetingRooms());
    }

    [HttpGet("{id}")]
    public ActionResult<MeetingRoom> GetMeetingRoom(int id)
    {
        var meetingRoom = _meetingRoomsService.GetMeetingRoom(id);

        if (meetingRoom == null)
        {
            return NotFound();
        }

        return meetingRoom;
    }

    [HttpPut("{id}")]
    public IActionResult PutMeetingRoom(MeetingRoom meetingRoom)
    {
        _meetingRoomsService.PutMeetingRoom(meetingRoom);
        return Ok();
    }

    [HttpPost]
    public ActionResult<MeetingRoom> PostMeetingRoom(MeetingRoomDTO meetingRoomDTO)
    {
        var meetingRoom = _meetingRoomsService.PostMeetingRoom(meetingRoomDTO);

        return CreatedAtAction("GetMeetingRoom", new { id = meetingRoom.Id }, meetingRoom);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMeetingRoom(int id)
    {
        _meetingRoomsService.DeleteMeetingRoom(id);
        return NoContent();
    }
}
