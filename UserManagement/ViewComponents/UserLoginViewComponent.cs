using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;

namespace UserManagement.ViewComponents
{
    public class UserLoginViewComponent : ViewComponent
    {

        public UserLoginViewComponent(SignInManager<UserModel> userManager)
        {
        }

        public IViewComponentResult Invoke()
        {
            var model = new UserBaseViewModel();
            return View("UserLogin", model);
        }
    }
}

