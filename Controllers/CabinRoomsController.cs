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
        //cabinRoomDTO.Number = $"{cityAbb}-{buildingAbb}-{floor}-{facilityName}-{cabinRoomDTO.Number}";
        //if()
        cabinRoomDTO.Number = $"C{cabinRoomDTO.Number}";
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
            string seatNumber = HttpContext.Request.Query["seatNumber"];
            string floorNumber = HttpContext.Request.Query["floorNumber"];
            string cityId = HttpContext.Request.Query["cityId"];
            string facilityName = HttpContext.Request.Query["facilityName"];

            return Ok(_cabinRoomsService.GetFreeCabinRooms(seatNumber, floorNumber, cityId, facilityName));
        }
        catch (ExceptionWhileAdding ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

    }

    [HttpPost]
    [Route("allocate")]
    public ActionResult AllocateCabinRoom(CabinRoomDTO cabinRoomDTO)
    {
        _cabinRoomsService.AllocateCabinRoom(cabinRoomDTO);
        return NoContent();
    }

    [HttpPost]
    [Route("deallocate")]
    public ActionResult DeallocateCabinRoom(int id, CabinRoomDTO cabinRoomDTO)
    {
        _cabinRoomsService.DeallocateCabinRoom(id, cabinRoomDTO);
        return NoContent();
    }
}
