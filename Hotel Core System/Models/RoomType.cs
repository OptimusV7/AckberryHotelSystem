using System.ComponentModel.DataAnnotations;

namespace Hotel_Core_System.Models
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }
        public string Type_name { get; set; }
    }

}
