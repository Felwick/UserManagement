using Microsoft.AspNetCore.Identity;
using UserManagement.Models;
using UserManagement.Models.Components;

namespace UserManagement.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly ILogger<UserManagementService> _logger;

        public UserManagementService(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, ILogger<UserManagementService> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IdentityResult> RegisterUser(UserViewModel model)
        {
            var user = new UserModel { UserName = model.UserName, Email = model.Email, UserGuid = Guid.NewGuid(), Id = Guid.NewGuid().ToString() };
            var result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }

        public async Task<SignInResult> Login(UserViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);
            return result;

        }

        //Logout is safe to be void as it does not return any data
        public async Task Logout(UserViewModel model)
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Delete(UserBaseViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }

            var result = await _userManager.DeleteAsync(user);
            await _signInManager.SignOutAsync();

            return result;
        }
    }
}
