using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;

namespace SeatManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IRepository<City> _repository;

        public CitiesController(IRepository<City> repository)
        {
            _repository = repository;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCity()
        {
          return _repository.GetAll();
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city =  _repository.GetById(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(City city)
        {

            var item = _repository.GetById(city.Id);
            if (item == null)
            {
                return NotFound();
            }
            item.Name = city.Name;
            item.Abbreviation = city.Abbreviation;
            _repository.Update(item);
            return Ok();

        }

        // POST: api/Cities
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(CityDTO cityDTO)
        {
            var city = new City
            {
                Name = cityDTO.Name,
                Abbreviation = cityDTO.Abbreviation
            };
            _repository.Add(city);

            return CreatedAtAction("GetCity", new { id = city.Id }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = _repository.GetById(id);
            if (city == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return NoContent();
        }
    }
}