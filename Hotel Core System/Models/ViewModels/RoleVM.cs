using System.ComponentModel.DataAnnotations;

namespace Hotel_Core_System.Models.ViewModels
{
    public class RoleVM
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
    }
}
