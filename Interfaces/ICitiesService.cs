// ICitiesService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;

public interface ICitiesService
{
    IEnumerable<City> GetCities();
    City GetCity(int id);
    void PutCity(City city);
    City PostCity(CityDTO cityDTO);
    void DeleteCity(int id);
}
