using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models.Components
{
    public class UserBaseViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
