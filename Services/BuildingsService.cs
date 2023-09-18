// BuildingsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;
using SeatManagement;

public class BuildingsService : IBuildingsService
{
    private readonly IRepository<Building> _repository;

    public BuildingsService(IRepository<Building> repository)
    {
        _repository = repository;
    }

    public IEnumerable<Building> GetBuildings(string nameFilter = null)
    {
        var buildings = _repository.GetAll();

        return buildings;
    }

    public Building GetBuilding(int id)
    {
        var building = _repository.GetById(id);
        return building;
    }

    public void PutBuilding(Building building)
    {
        var item = _repository.GetById(building.Id);
        if (item == null)
        {
            return;
        }
        // Update any properties of Building as needed
        item.Name = building.Name;
        item.Abbreviation = building.Abbreviation;
        // Add any other properties you need to update
        _repository.Update(item);
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

    public void DeleteBuilding(int id)
    {
        var building = _repository.GetById(id);
        if (building == null)
        {
            return;
        }
        _repository.Delete(id);
    }
}
