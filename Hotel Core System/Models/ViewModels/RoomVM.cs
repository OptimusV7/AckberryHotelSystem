using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Core_System.Models.ViewModels
{
    public class RoomVM
    {
        [Required, Display(Name = "Room Number")]
        public string RoomNumber { get; set; }
        [Required, Display(Name = "Room Type")]
        public int RoomType { get; set; }
        [Required, Display(Name = "Booking Price")]
        public double BookingPrice { get; set; }
        [Required, Display(Name = "Is Smoking Allowed")]
        public bool IsSmokingAllowed { get; set; }
        [Required, Display(Name = "Is Room Available")]
        public bool IsRoomAvailable { get; set; }
        [Required, Display(Name = "Max No Adult")]
        public int MaxAdult { get; set; }
        [Required, Display(Name = "Max No Child")]
        public int MaxChild { get; set; }
        public string imageName { get; set; }
        public List<string> ImageFile { get; set; }
    }
}
