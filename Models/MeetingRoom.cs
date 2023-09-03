using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement.Models
{
    public class MeetingRoom
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        public int SeatCount { get; set; }

        public virtual Facility Facility { get; set; }
    }
}
