using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class EditUserPropertiesController : Controller
    {
        private readonly UserManager<UserModel> _userManager;

        public EditUserPropertiesController(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View("../Management/EditUserProperties");
        }

        public async Task<IActionResult> Edit()
        {
            if (User.Identity == null)
            {
                return Unauthorized();
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }

            var model = new UserModel
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName, 
                LastName = user.LastName
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserModel model)
        {
            if (User.Identity == null && User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                // Retrieve user based on current identity rather than model based on form data
                var user = await _userManager.FindByNameAsync(userName: User.Identity.Name);
                if (user == null)
                {
                    return NotFound();
                }

                // Update properties
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.FirstName = model.FirstName; 
                user.LastName = model.LastName;
                 
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index)); 
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            //Ending up in this block means something failed
            return BadRequest();
        }
    }
}
