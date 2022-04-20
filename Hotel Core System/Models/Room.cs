using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Core_System.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        public string RoomNumber { get; set; }
        [Required]
        public int RoomType { get; set; }
        [NotMapped]
        public string RoomTypeString { get; set; }
        [Required]
        public double BookingPrice { get; set; }
        public bool IsSmokingAllowed { get; set; }
        [Required]
        public bool IsRoomAvailable { get; set; }
        public bool CheckIn { get; set; }
        public bool CheckOut { get; set; }
        public int MaxAdult { get; set; }
        public int MaxChild { get; set; }
        public string RoomDescription { get; set; }
        public string RoomFeatureValues { get; set; }

        //public List<Booking> bookings { get; set; }

    }
}
