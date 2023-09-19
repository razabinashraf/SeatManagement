// SeatsController.cs
using Microsoft.AspNetCore.Mvc;
using SeatManagement.Exceptions;
using SeatManagement.Models;

namespace SeatManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatsService _seatsService;


        public SeatsController(ISeatsService seatsService)
        {
            _seatsService = seatsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Seat>> GetSeats()
        {
            return Ok(_seatsService.GetSeats());
        }

        [HttpGet]
        [Route("free")]
        public ActionResult<IEnumerable<Seat>> GetFreeSeats()
        {
            try
            {
                string seatNumber = HttpContext.Request.Query["seatNumber"];
                string floorNumber = HttpContext.Request.Query["floorNumber"];
                string cityId = HttpContext.Request.Query["cityId"];
                string facilityName = HttpContext.Request.Query["facilityName"];

                return Ok(_seatsService.GetFreeSeats(seatNumber, floorNumber, cityId, facilityName));
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

        [HttpGet("{id}")]
        public ActionResult<Seat> GetSeat(int id)
        {
            var seat = _seatsService.GetSeat(id);

            if (seat == null)
            {
                return NotFound();
            }

            return seat;
        }

        [HttpPost]
        public ActionResult PostSeats(SeatDTO[] seatDTOs)
        {
            _seatsService.PostSeats(seatDTOs);
            return NoContent();
        }

        [HttpPost]
        [Route("allocate")]
        public ActionResult AllocateSeat(SeatDTO seatDTO)
        {
            _seatsService.AllocateSeat(seatDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSeat(int id)
        {
            _seatsService.DeleteSeat(id);
            return NoContent();
        }

        [HttpPost]
        [Route("deallocate")]
        public ActionResult DeallocateSeat(int id, Seat seat)
        {
            _seatsService.DeallocateSeat(id, seat);
            return NoContent();
        }
    }
}
