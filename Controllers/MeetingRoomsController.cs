// MeetingRoomsController.cs
using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Exceptions;
using SeatManagement.Models;

[Route("api/[controller]")]
[ApiController]
public class MeetingRoomsController : ControllerBase
{
    private readonly IMeetingRoomsService _meetingRoomsService;
    private readonly IAllocatedAssetsService _allocatedAssetsService;
    private readonly IAssetsService _assetsService;

    public MeetingRoomsController(
        IMeetingRoomsService meetingRoomsService,
        IAllocatedAssetsService allocatedAssetsService,
        IAssetsService assetsService)
    {
        _meetingRoomsService = meetingRoomsService;
        _allocatedAssetsService = allocatedAssetsService;
        _assetsService = assetsService;
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

    [HttpPost("{id}/assets")]
    public ActionResult<MeetingRoom> AddAssetToMeetingRoom(AllocatedAssetDTO allocatedAsset)
    {
        var meetingRoom = _meetingRoomsService.GetMeetingRoom(allocatedAsset.MeetingRoomId);
        if (meetingRoom == null)
        {
            throw new ExceptionWhileAdding("Meeting room id is invalid");
        }

        var asset = _assetsService.GetAsset(allocatedAsset.AssetId);
        if (asset == null)
        {
            throw new ExceptionWhileAdding("Asset id is invalid");
        }
        _allocatedAssetsService.PostAllocatedAsset(allocatedAsset);

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMeetingRoom(int id)
    {
        _meetingRoomsService.DeleteMeetingRoom(id);
        return NoContent();
    }
}
