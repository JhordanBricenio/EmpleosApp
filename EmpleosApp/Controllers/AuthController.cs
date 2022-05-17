using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmpleosApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepositorio _authRepository;


        public AuthController(IAuthRepositorio authRepository)
        {
            this._authRepository = authRepository;
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View("FormLogin");
        }
        
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            //si el usario existe ne la base d edatos crear la cockie de lo contrario no existe
            if (_authRepository.aunteticacionCokie(username, password))
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("AuthError", "Usuario o contraseña incorrectos");

            return View("FormLogin");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("FormLogin");
        }
      
    }
}
