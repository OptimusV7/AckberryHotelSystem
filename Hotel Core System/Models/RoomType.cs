using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }
        public string Type_name { get; set; }
    }

}
