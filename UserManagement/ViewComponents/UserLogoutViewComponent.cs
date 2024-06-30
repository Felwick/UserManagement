using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;

namespace UserManagement.ViewComponents
{
    public class UserLogoutViewComponent : ViewComponent
    {

        public UserLogoutViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View("UserLogout");
        }
    }
}
