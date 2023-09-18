// BuildingsController.cs
using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Models;

[Route("api/[controller]")]
[ApiController]
public class BuildingsController : ControllerBase
{
    private readonly IBuildingsService _buildingsService;

    public BuildingsController(IBuildingsService buildingsService)
    {
        _buildingsService = buildingsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Building>> GetBuilding()
    {
        string nameFilter = HttpContext.Request.Query["Name"].ToString();
        var buildings = _buildingsService.GetBuildings(nameFilter);
        return Ok(buildings);
    }

    [HttpGet("{id}")]
    public ActionResult<Building> GetBuilding(int id)
    {
        var building = _buildingsService.GetBuilding(id);

        if (building == null)
        {
            return NotFound();
        }

        return building;
    }

    [HttpPut("{id}")]
    public IActionResult PutBuilding(Building building)
    {
        _buildingsService.PutBuilding(building);
        return Ok();
    }

    [HttpPost]
    public ActionResult<Building> PostBuilding(BuildingDTO buildingDTO)
    {
        var building = _buildingsService.PostBuilding(buildingDTO);

        return CreatedAtAction("GetBuilding", new { id = building.Id }, building);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBuilding(int id)
    {
        _buildingsService.DeleteBuilding(id);
        return NoContent();
    }
}
