using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;
using UserManagement.Models.Components;
using UserManagement.Services;

namespace UserManagement.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly IUserManagementService _userManagementService;

        public AuthenticationController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManagementService.RegisterUser(model);

                if (result.Succeeded)
                {
                    // Log the user in or redirect as needed
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View("Error");
                }
            }

            // If we got this far, something failed go back home
            return BadRequest();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _userManagementService.Login(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View("Error");
                }
            }

            // If we got this far, something failed, go back home
            return BadRequest();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Logout(UserViewModel model)
        {
            await _userManagementService.Logout(model);
            return RedirectToAction("Index", "Home");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(UserBaseViewModel model)
        {
            await _userManagementService.Delete(model);
            return RedirectToAction("Index", "Home");
        }
    }
}
