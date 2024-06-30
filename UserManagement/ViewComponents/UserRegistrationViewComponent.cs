using Microsoft.AspNetCore.Mvc;

namespace UserManagement.ViewComponents
{
    public class UserRegistrationViewComponent: ViewComponent
    {
        public UserRegistrationViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            var model = new UserViewModel();
            return View("UserRegistration", model);
        }
    }
}
