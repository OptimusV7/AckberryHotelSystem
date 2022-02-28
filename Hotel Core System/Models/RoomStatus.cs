using System.ComponentModel.DataAnnotations;

namespace Hotel_Core_System.Models
{
    public class RoomStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status_name { get; set; }
    }
}
