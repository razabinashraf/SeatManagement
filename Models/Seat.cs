using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Facility Facility { get; set; }
    }
}
