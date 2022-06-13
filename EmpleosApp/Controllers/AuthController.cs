using EmpleosApp.Models;
using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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
           // Usuario user = new Usuario();
            password = DesEncriptar(password);

            var result = _authRepository.aunteticacionCok(username, password);

            /* if (result.Perfiles.Count == 0)
             {
                 var response = new
                 {
                     success = false,
                     message = "Usted no tiene Acceso al Sistema"
                 };
                 return Json(response);
             }
             */


            if (_authRepository.aunteticacionCokie(username, password))
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, username)
                    
                    
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                foreach (var Rol in result.Perfiles)
                {
                    
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, Rol.Perfil.perfil));


                }

               
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal,
                            new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddDays(1), IsPersistent = true });
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("AuthError", "Usuario o contraseña incorrectos");

            return View("FormLogin");
        }
       


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "home" );
        }

        private string DesEncriptar(string password)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[]? stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }        

    }
}
