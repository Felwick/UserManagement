using Microsoft.AspNetCore.Mvc;
using UserManagement.Models.Components;

namespace UserManagement.ViewComponents
{
    public class DeleteUserViewComponent : ViewComponent
    {
        public DeleteUserViewComponent()
        {
        }

        public IViewComponentResult Index()
        {
            var model = new UserBaseViewModel();
            return View("DeleteUser");
        }
    }
}
