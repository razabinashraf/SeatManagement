// CabinRoomsController.cs
using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;

[Route("api/[controller]")]
[ApiController]
public class CabinRoomsController : ControllerBase
{
    private readonly ICabinRoomsService _cabinRoomsService;

    public CabinRoomsController(ICabinRoomsService cabinRoomsService)
    {
        _cabinRoomsService = cabinRoomsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CabinRoom>> GetCabinRoom()
    {
        return Ok(_cabinRoomsService.GetCabinRooms());
    }

    [HttpGet("{id}")]
    public ActionResult<CabinRoom> GetCabinRoom(int id)
    {
        var cabinRoom = _cabinRoomsService.GetCabinRoom(id);

        if (cabinRoom == null)
        {
            return NotFound();
        }

        return cabinRoom;
    }

    [HttpPut("{id}")]
    public IActionResult PutCabinRoom(CabinRoom cabinRoom)
    {
        _cabinRoomsService.PutCabinRoom(cabinRoom);
        return Ok();
    }

    [HttpPost]
    public ActionResult<CabinRoom> PostCabinRoom(CabinRoomDTO cabinRoomDTO)
    {
        var cabinRoom = _cabinRoomsService.PostCabinRoom(cabinRoomDTO);

        return CreatedAtAction("GetCabinRoom", new { id = cabinRoom.Id }, cabinRoom);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCabinRoom(int id)
    {
        _cabinRoomsService.DeleteCabinRoom(id);
        return NoContent();
    }
}
