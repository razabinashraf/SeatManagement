using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement.DTOs
{
    public class AllocatedAssetDTO
    {
        public int Quantity { get; set; }
        public int FacilityDetailId { get; set; }
        public int AssetId { get; set; }
    }
}
