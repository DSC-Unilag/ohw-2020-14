using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TRAVEL_PLANNER.Data;
using TRAVEL_PLANNER.Models.AccountViewModel;

namespace TRAVEL_PLANNER.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUsers> _userManager;

        private readonly SignInManager<AppUsers> _signInManager;

        public AccountController(UserManager<AppUsers> userManager, SignInManager<AppUsers> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
         
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email,
                                                                        loginViewModel.Password, loginViewModel.RememberMe,
                                                                        lockoutOnFailure: false);

                if (result.Succeeded)
                {                    
                    return RedirectToAction(nameof(TravelPlanController.SearchPlan), "TravelPlan");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "InCorrect Username or Password");

                    return View(loginViewModel);
                }
            }

            return View(loginViewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var user = new AppUsers
                {
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email,
                };

                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction(nameof(TravelPlanController.SearchPlan), "TravelPlan");
                }

                AddErrors(result);
            }

            return View(registerViewModel);
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
    }
}