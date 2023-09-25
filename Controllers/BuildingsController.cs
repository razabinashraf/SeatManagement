// BuildingsController.cs
using Microsoft.AspNetCore.Mvc;
using SeatManagement.DTOs;
using SeatManagement.Exceptions;
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
        var buildings = _buildingsService.GetBuildings();
        return Ok(buildings);
    }

    [HttpGet("{id}")]
    public ActionResult<Building> GetBuilding(int id)
    {
        try
        {
            var building = _buildingsService.GetBuilding(id);
            return Ok(building);
        }
        catch (ExceptionWhileFetching ex)
        {
            return NotFound(ex.Message);
        }
    }


    [HttpPost]
    public ActionResult<Building> PostBuilding(BuildingDTO buildingDTO)
    {
        var building = _buildingsService.PostBuilding(buildingDTO);

        return CreatedAtAction("GetBuilding", new { id = building.Id }, building);
    }

}
