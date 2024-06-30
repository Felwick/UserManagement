using System.ComponentModel.DataAnnotations;
using UserManagement.Models.Components;

public class UserViewModel : UserBaseViewModel
{
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
