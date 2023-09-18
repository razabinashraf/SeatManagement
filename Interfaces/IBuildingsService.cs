// IBuildingsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;

public interface IBuildingsService
{
    IEnumerable<Building> GetBuildings(string nameFilter = null);
    Building GetBuilding(int id);
    void PutBuilding(Building building);
    Building PostBuilding(BuildingDTO buildingDTO);
    void DeleteBuilding(int id);
}
