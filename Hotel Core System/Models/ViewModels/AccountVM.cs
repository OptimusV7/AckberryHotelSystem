namespace Hotel_Core_System.Models.ViewModels
{
    public class AccountVM
    {
        public string Id { get; set; }

        public string Name { get; set; }
        
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Phone { get; set; }
        
        public bool EmailConfirmed { get; set; }
        
        public string RoleName { get; set; }
    }
}
