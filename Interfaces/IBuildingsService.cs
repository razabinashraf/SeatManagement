// IBuildingsService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;

public interface IBuildingsService
{
    IEnumerable<Building> GetBuildings();
    Building GetBuilding(int id);
    Building PostBuilding(BuildingDTO buildingDTO);
}
