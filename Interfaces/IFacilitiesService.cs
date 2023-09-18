using SeatManagement.DTOs;
using SeatManagement.Models;

namespace SeatManagement.Interfaces
{
    public interface IFacilitiesService
    {
        void DeleteFacility(int id);
        IEnumerable<Facility> GetFacility();
        Facility GetFacility(int id);
        Facility PostFacility(FacilityDTO facilityDTO);
        void PutFacility(Facility facility);
    }
}