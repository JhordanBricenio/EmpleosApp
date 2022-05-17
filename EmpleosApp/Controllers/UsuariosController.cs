using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create()
        {
            return View();
        }
    }
}
