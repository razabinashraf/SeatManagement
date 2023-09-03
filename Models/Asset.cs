using System.ComponentModel.DataAnnotations;

namespace SeatManagement.Models
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
