// BuildingsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;
using SeatManagement;
using SeatManagement.Exceptions;

public class BuildingsService : IBuildingsService
{
    private readonly IRepository<Building> _repository;

    public BuildingsService(IRepository<Building> repository)
    {
        _repository = repository;
    }

    public IEnumerable<Building> GetBuildings()
    {
        var buildings = _repository.GetAll();

        return buildings;
    }

    public Building GetBuilding(int id)
    {
        var building = _repository.GetById(id);
        if (building == null)
        {
            throw new ExceptionWhileFetching("Building id is invalid");
        }        
        return building;
    }


    public Building PostBuilding(BuildingDTO buildingDTO)
    {
        var building = new Building
        {
            Name = buildingDTO.Name,
            Abbreviation = buildingDTO.Abbreviation
            // Add any other properties you need to set
        };
        _repository.Add(building);
        return building;
    }
}
