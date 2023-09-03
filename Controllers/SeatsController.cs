using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;
using System.Drawing;

namespace SeatManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly IRepository<Seat> _repository;

        public SeatsController(IRepository<Seat> repository)
        {
            _repository = repository;
        }

        // GET: api/Seats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seat>>> GetSeats()
        {
            return _repository.GetAll();
        }

        [HttpGet]
        [Route("free")]
        public async Task<ActionResult<IEnumerable<Seat>>> GetFreeSeats()
        {
            var freeSeats = _repository.GetAll().Where(x => x.EmployeeId == null);
            string seatNumber = HttpContext.Request.Query["seatNumber"];
            string floorNumber = HttpContext.Request.Query["floorNumber"];
            string cityId = HttpContext.Request.Query["cityId"];
            if (seatNumber != null)
            {
                freeSeats = freeSeats.Where(x => x.SeatNumber == Convert.ToInt32(seatNumber));
            }
            if (floorNumber != null)
            {
                freeSeats = freeSeats.Where(x => x.Facility.FloorNumber == Convert.ToInt32(floorNumber));
            }
            if (cityId != null)
            {
                freeSeats = freeSeats.Where(x => x.Facility.CityId == Convert.ToInt32(cityId));
            }
            return freeSeats.ToList();
        }

        // GET: api/Seats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seat>> GetSeat(int id)
        {
            var seat = _repository.GetById(id);

            if (seat == null)
            {
                return NotFound();
            }

            return seat;
        }

        [HttpPost]
        public async Task<ActionResult<Seat>> PostSeats(SeatDTO[] seatDTOs)
        {

            foreach (var st in seatDTOs)
            {
                Seat seat = new Seat();
                seat.SeatNumber = st.SeatNumber;
                seat.EmployeeId = null;
                seat.FacilityId = st.FacilityId;
                _repository.Add(seat);
            }
            return NoContent();

        }

        // POST: api/Seats
        [HttpPost]
        [Route("allocate")]
        public async Task<ActionResult<Seat>> AllocateSeat(SeatDTO seatDTO)
        {


            var seat = _repository.GetAll().Where(x => x.EmployeeId == null && x.SeatNumber == seatDTO.SeatNumber && x.FacilityId==seatDTO.FacilityId).FirstOrDefault();

            seat.EmployeeId = null;

            return NoContent();
        }



        // DELETE: api/Seats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            var seat = _repository.GetById(id);
            if (seat == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return NoContent();
        }
        [HttpPost]
        [Route("deallocate")]
        public async Task<IActionResult> DeAllocateSeat(int id, Seat seat)
        {
            if (id != seat.Id)
            {
                return BadRequest();
            }

            var existingSeat = _repository.GetById(id);
            if (existingSeat == null)
            {
                return NotFound();
            }

            // Update any properties of Seat as needed
            existingSeat.EmployeeId = null;
            // Add any other properties you need to update
            _repository.Update(existingSeat);
            return Ok();
        }
    }
}
