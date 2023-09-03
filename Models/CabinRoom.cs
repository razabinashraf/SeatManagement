using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement.Models
{
    public class CabinRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        public virtual Facility Facility { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
