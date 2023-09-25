// CabinRoomsController.cs
using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Exceptions;
using SeatManagement.Interfaces;
using SeatManagement.Models;

[Route("api/[controller]")]
[ApiController]
public class CabinRoomsController : ControllerBase
{
    private readonly ICabinRoomsService _cabinRoomsService;
    private readonly IFacilitiesService _facilitiesService;

    public CabinRoomsController(ICabinRoomsService cabinRoomsService, IFacilitiesService facilitiesService)
    {
        _cabinRoomsService = cabinRoomsService;
        _facilitiesService = facilitiesService;
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

    [HttpGet]
    [Route("free")]
    public ActionResult<IEnumerable<CabinRoom>> GetFreeCabinRooms()
    {
        try
        {
            string cityId = HttpContext.Request.Query["cityId"];
            string facilityName = HttpContext.Request.Query["facilityName"];
            string floorNumber = HttpContext.Request.Query["floorNumber"];
            string cabinNumber = HttpContext.Request.Query["cabinNumber"];

            return Ok(_cabinRoomsService.GetFreeCabinRooms(cabinNumber, floorNumber, cityId, facilityName));
        }
        catch (ExceptionWhileAdding ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPost]
    [Route("{id}/allocation")]
    public ActionResult AllocateCabinRoom(CabinRoomDTO cabinRoomDTO, int id)
    {
        try
        {
            _cabinRoomsService.AllocateCabinRoom(cabinRoomDTO, id);
            return Ok();
        }
        catch (ExceptionWhileAdding ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpDelete]
    [Route("{id}/allocation")]
    public ActionResult DeallocateSeat(int id)
    {
        _cabinRoomsService.DeallocateCabinRoom(id);
        return Ok();
    }
}
