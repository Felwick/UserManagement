using Microsoft.AspNetCore.Identity;

namespace UserManagement.Models
{
    public class UserModel : IdentityUser
    {
        public Guid UserGuid { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public override string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
