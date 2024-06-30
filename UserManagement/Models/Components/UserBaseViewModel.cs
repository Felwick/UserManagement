using System.ComponentModel.DataAnnotations;

public class UserBaseViewModel
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
