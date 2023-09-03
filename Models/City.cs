using System.ComponentModel.DataAnnotations;

namespace SeatManagement.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}
