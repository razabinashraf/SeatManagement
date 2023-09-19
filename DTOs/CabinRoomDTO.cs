using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement.DTOs
{
    public class CabinRoomDTO
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public int FacilityId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
