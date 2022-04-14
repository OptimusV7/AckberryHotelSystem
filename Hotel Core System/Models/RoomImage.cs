using System.ComponentModel.DataAnnotations;

namespace Hotel_Core_System.Models
{
    public class RoomImage
    {
        [Key]
        public int ImageID { get; set; }
        public string RoomNumber { get; set; }
        public string ImageName { get; set; }
        public string Caption { get; set; }
    }

}
