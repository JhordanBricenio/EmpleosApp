using EmpleosApp.Models;
using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmpleosApp.Controllers
{
    [Authorize]    
    public class HomeController : Controller
    {
        private readonly IVacanteRepositorio _vacanteRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        
        
        public HomeController(IVacanteRepositorio vacanteRepositorio, ICategoriaRepositorio categoriaRepositorio)
        {
            this._vacanteRepositorio = vacanteRepositorio;
            this._categoriaRepositorio = categoriaRepositorio;
        }
        
        public IActionResult Index()
        {

            var vacantes = _vacanteRepositorio.ObtenerDestacados();
            ViewBag.Categorias = _categoriaRepositorio.ObtenerTodos();
            return View(vacantes);
        }
        public IActionResult Detalle()
        {
            return View();
        }
        
        public IActionResult Acerca()
        {
            return View();
        }  
    }
}