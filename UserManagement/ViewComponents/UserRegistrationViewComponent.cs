using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;

namespace UserManagement.ViewComponents
{
    public class UserRegistrationViewComponent: ViewComponent
    {

        public UserRegistrationViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            var model = new UserBaseViewModel();
            return View("UserRegistration", model);
        }
    }
}
