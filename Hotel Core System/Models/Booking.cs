using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Core_System.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public string ReservationNumber { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationInDays { get; set; }
        public int BookingStatusId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}
