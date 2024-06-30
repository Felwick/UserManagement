using Microsoft.AspNetCore.Identity;
using UserManagement.Models.Components;

namespace UserManagement.Services
{
    public interface IUserManagementService
    {
        Task<IdentityResult> Delete(UserBaseViewModel model);
        Task<SignInResult> Login(UserViewModel model);
        Task Logout(UserViewModel model);
        Task<IdentityResult> RegisterUser(UserViewModel model);
    }
}