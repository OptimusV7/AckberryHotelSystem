using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class RoomStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status_name { get; set; }
    }
}
