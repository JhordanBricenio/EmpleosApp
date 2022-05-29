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
            if (ModelState.IsValid)
            {
                usuario.Password = Encriptar(usuario.Password);
                
                usuario.Estado = 1;
                usuario.FechaRegistro = DateTime.Now;
                // Creamos el Perfil que le asignaremos al usuario nuevo
                Perfil perfil = new Perfil();
               // perfil.Id=2; // Perfil USUARIO
               // usuario.agregar(perfil);



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

        private string Encriptar(string password)
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
