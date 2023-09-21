// ICitiesService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;

public interface ICitiesService
{
    IEnumerable<City> GetCities();
    City GetCity(int id);
    City PostCity(CityDTO cityDTO);
}
