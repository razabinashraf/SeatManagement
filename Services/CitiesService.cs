// CitiesService.cs
using SeatManagement.DTOs;
using SeatManagement.Models;
using SeatManagement;

public class CitiesService : ICitiesService
{
    private readonly IRepository<City> _repository;

    public CitiesService(IRepository<City> repository)
    {
        _repository = repository;
    }

    public IEnumerable<City> GetCities()
    {
        return _repository.GetAll();
    }

    public City GetCity(int id)
    {
        var city = _repository.GetById(id);
        return city;
    }


    public City PostCity(CityDTO cityDTO)
    {
        var city = new City
        {
            Name = cityDTO.Name,
            Abbreviation = cityDTO.Abbreviation
            // Add any other properties you need to set
        };
        _repository.Add(city);
        return city;
    }

}
