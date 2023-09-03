using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement.DTOs
{
    public class FacilityDTO
    {
        public string Name { get; set; }
        public int FloorNumber { get; set; }
        public int CityId { get; set; }
        public int BuildingId { get; set; }

    }
}
