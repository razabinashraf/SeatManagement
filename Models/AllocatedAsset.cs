using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement.Models
{
    public class AllocatedAsset
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("MeetingRoom")]
        public int MeetingRoomId { get; set; }
        [ForeignKey("Asset")]
        public int AssetId { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual MeetingRoom MeetingRoom { get; set; }
    }
}
