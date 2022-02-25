using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        public string RoomNumber { get; set; }
        [Required]
        public string RoomType { get; set; }
        [Required]
        public double BookingPrice { get; set; }
        public bool IsSmokingAllowed { get; set; }
        [Required]
        public bool IsRoomAvailable { get; set; }
        public bool CheckIn { get; set; }
        public bool CheckOut { get; set; }

        //public List<Booking> bookings { get; set; }

    }
}
