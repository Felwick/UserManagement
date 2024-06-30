using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;

namespace UserManagement.ViewComponents
{
    public class UserLoginViewComponent : ViewComponent
    {
        public UserLoginViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            var model = new UserViewModel();
            return View("UserLogin", model);
        }
    }
}

