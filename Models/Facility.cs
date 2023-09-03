using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement.Models
{
    public class Facility
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int FloorNumber { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        [ForeignKey("Building")]
        public int BuildingId { get; set; }

        public virtual City City { get; set; }
        public virtual Building Building { get; set; }
    }
}
