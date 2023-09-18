// CitiesController.cs
using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : ControllerBase
{
    private readonly ICitiesService _citiesService;

    public CitiesController(ICitiesService citiesService)
    {
        _citiesService = citiesService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<City>> GetCity()
    {
        return Ok(_citiesService.GetCities());
    }

    [HttpGet("{id}")]
    public ActionResult<City> GetCity(int id)
    {
        var city = _citiesService.GetCity(id);

        if (city == null)
        {
            return NotFound();
        }

        return city;
    }

    [HttpPut("{id}")]
    public IActionResult PutCity(City city)
    {
        _citiesService.PutCity(city);
        return Ok();
    }

    [HttpPost]
    public ActionResult<City> PostCity(CityDTO cityDTO)
    {
        var city = _citiesService.PostCity(cityDTO);

        return CreatedAtAction("GetCity", new { id = city.Id }, city);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCity(int id)
    {
        _citiesService.DeleteCity(id);
        return NoContent();
    }
}
