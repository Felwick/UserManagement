using Microsoft.AspNetCore.Mvc;

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
