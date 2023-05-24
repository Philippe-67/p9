using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using p9.Models;

namespace p9.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Utilisateur> _signInManager;

        public AccountController(SignInManager<Utilisateur> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false).Result;

                if (result.Succeeded)
                {
                    // Rediriger vers la page d'accueil ou toute autre page après une connexion réussie
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    model.ShowInvalidCredentialsMessage = true;
                }
            }

            return View(model);
        }
    }
}
