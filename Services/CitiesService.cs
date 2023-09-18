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

    public void PutCity(City city)
    {
        var item = _repository.GetById(city.Id);
        if (item == null)
        {
            return;
        }
        // Update any properties of City as needed
        item.Name = city.Name;
        item.Abbreviation = city.Abbreviation;
        // Add any other properties you need to update
        _repository.Update(item);
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

    public void DeleteCity(int id)
    {
        var city = _repository.GetById(id);
        if (city == null)
        {
            return;
        }
        _repository.Delete(id);
    }
}
