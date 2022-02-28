using System.ComponentModel.DataAnnotations;

namespace Hotel_Core_System.Models
{
    public class BookingStatus
    {
        [Key]
        public int Id { get; set; }
        public string Booking_status_name { get; set; }
    }
}
