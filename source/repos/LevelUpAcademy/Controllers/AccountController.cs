using LevelUpAcademy.Models;
using LevelUpAcademy.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LevelUpAcademy.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
       // private IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager
                                //,IEmailSender emailSender
            ) {
            _userManager=userManager;
            _signInManager=signInManager;
           // _emailSender=emailSender;
        
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrWhiteSpace(model.Password))
                    {
                        ModelState.AddModelError("", "Password cannot be null or empty.");
                        return View(model);
                    }
                    if(model.Email==null) 
                        return View(model);

                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError(string.Empty, "Password non valido");
                    
                }
               
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(HomeController.Error), "Home", new { errorMessage = ex.ToString() });
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel
            {
                AvailableRoles = new List<SelectListItem>
                {
                    new SelectListItem { Value = "Student", Text = "Studente" },
                    new SelectListItem { Value = "Teacher", Text = "Docente" },
                    //new SelectListItem { Value = "Admin", Text = "Amministratore" }
                }
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrWhiteSpace(model.Password))
                    {
                        ModelState.AddModelError("", "Password cannot be null or empty.");
                        return View(model);
                    }

                    var User = new ApplicationUser { UserName = model.Email, Email = model.Email, FullName = model.FullName };
                    await _userManager.AddToRoleAsync(User, model.Role);

                    var result = await _userManager.CreateAsync(User, model.Password);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(User, isPersistent: false);
                        //var code = await _userManager.GenerateEmailConfirmationTokenAsync(User);
                        //var newCode = System.Web.HttpUtility.UrlEncode(code);
                        //var callBackUrl = Url.Action(nameof(ConfirmEmail), "Account", new { userId = User.Id, code = newCode }, protocol: HttpContext.Request.Scheme);

                        //// Fix: Ensure model.Email is not null before calling SendEmailAsync
                        //var email = model.Email ?? string.Empty;
                        //await _emailSender.SendEmailAsync(email, "Confirm your account", $"Conferma il tuo account cliccando <a href='{callBackUrl}'>qui</a>.");
                        return RedirectToAction("Index", "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                model.AvailableRoles = new List<SelectListItem>
                {
                    new SelectListItem { Value = "Student", Text = "Studente" },
                    new SelectListItem { Value = "Teacher", Text = "Docente" },
                    //new SelectListItem { Value = "Admin", Text = "Amministratore" }
                };
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(HomeController.Error), "Home", new { errorMessage = ex.ToString() });
            }
        }

        //public async Task<IActionResult> ConfirmEmail( string userId,string code)
        //{
        //    if (userId == null || code == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    var user= await _userManager.FindByNameAsync(userId);
        //    if (user == null) return NotFound($"Utente {userId} non esistente");
        //    var result = await _userManager.ConfirmEmailAsync(user, code);
        //    if (result.Succeeded) {
        //        return View("ConfirmEmailSuccess");
        //    }
        //    return View("Error");
        //}
    }
}
