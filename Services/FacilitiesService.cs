using SeatManagement.DTOs;
using SeatManagement.Exceptions;
using SeatManagement.Interfaces;
using SeatManagement.Models;

namespace SeatManagement.Services
{
    public class FacilitiesService : IFacilitiesService
    {
        private readonly IRepository<Facility> _repository;
        private readonly IRepository<Building> _buildingRepository;
        private readonly IRepository<City> _cityRepository;
        public FacilitiesService(IRepository<Facility> repository, IRepository<Building> buildingRepository, IRepository<City> cityRepository)
        {
            _repository = repository;
            _buildingRepository = buildingRepository;
            _cityRepository = cityRepository;
        }

        public IEnumerable<Facility> GetFacility()
        {
            return _repository.GetAll();
        }

        public Facility GetFacility(int id)
        {
            var facility = _repository.GetById(id);

            return facility;
        }

        public void PutFacility(Facility facility)
        {
            var item = _repository.GetById(facility.Id);
            if (item == null)
            {
                return;
            }
            // Update any properties of Facility as needed
            item.Name = facility.Name;
            item.FloorNumber = facility.FloorNumber;
            item.CityId = facility.CityId;
            item.BuildingId = facility.BuildingId;
            // Add any other properties you need to update
            _repository.Update(item);
            return;
        }

        public Facility PostFacility(FacilityDTO facilityDTO)
        {
            if(_buildingRepository.GetById(facilityDTO.BuildingId) == null)
            {
                throw new ExceptionWhileAdding("Building does not exist");
            }
            if (_cityRepository.GetById(facilityDTO.CityId) == null)
            {
                throw new ExceptionWhileAdding("City does not exist");
            }
            var facility = new Facility
            {
                Name = facilityDTO.Name,
                FloorNumber = facilityDTO.FloorNumber,
                CityId = facilityDTO.CityId,
                BuildingId = facilityDTO.BuildingId,
            };
            _repository.Add(facility);

            return facility;
        }

        public void DeleteFacility(int id)
        {

            var facility = _repository.GetById(id);
            if (facility == null)
            {
                return;
            }
            _repository.Delete(id);

            return;
        }
    }
}
