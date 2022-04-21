using System.ComponentModel.DataAnnotations;

namespace Hotel_Core_System.Models
{
    public class RoomFeature
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name ="Feature name")]
        public string Feature_Name { get; set; }
    }
}
