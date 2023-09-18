using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement.Models
{
    public class SeatDTO
    {
        public int SeatNumber { get; set; }
        public int FacilityId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
