using EmpleosApp.Models;
using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace EmpleosApp.Controllers
{
    public class UsuariosController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
           var usuarios= _usuarioRepositorio.ObtenerTodos();
            return View("ListUsuarios", usuarios);
        }
        

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            var cantidad = _usuarioRepositorio.ContarUserNameUsuario(usuario);
            if (cantidad > 0)
            {
                ModelState.AddModelError("Username", "El nombre de usuario ya esta registrado.");
            }
            if (usuario.Nombre.Length<3)
            {
                ModelState.AddModelError("Nombre", "la longitud debe ser mayor a 3 caracteres.");

            }
            if (usuario.Username.Length < 3)
            {
                ModelState.AddModelError("Username", "la longitud debe estar entre 8 y 3 caracteres.");

            }
            if (usuario.Password.Length < 5)
            {
                ModelState.AddModelError("Password", "la longitud debe mayor a 5 caracteres.");

            }

            if (ModelState.IsValid)
            {
                usuario.Password = Encriptar(usuario.Password);
                
                usuario.Estado = 1;
                usuario.FechaRegistro = DateTime.Now;      
                Perfil perfil = new Perfil();
                perfil.Id=2;
                usuario.agregar(perfil);



                _usuarioRepositorio.registrarUsuario(usuario);
                return RedirectToAction("Login", "Auth");
            }
            return View("Create");

        }

        public IActionResult Delete(int id)
        {
            _usuarioRepositorio.DeleteUsuario(id);
            TempData["SuccessMessage"] = "Se eliminó el usuario de forma correcta";
            return RedirectToAction("Index");

        }        

        private static string Encriptar(string password)
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
