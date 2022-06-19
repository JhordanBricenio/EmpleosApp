using EmpleosApp.Models;
using EmpleosApp.Repositorio;
using EmpleosApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace EmpleosApp.Controllers
{
     
    public class HomeController : Controller
    {
        private readonly IVacanteRepositorio _vacanteRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        
        
        public HomeController(IVacanteRepositorio vacanteRepositorio, ICategoriaRepositorio categoriaRepositorio)
        {
            this._vacanteRepositorio = vacanteRepositorio;
            this._categoriaRepositorio = categoriaRepositorio;
        }
        
        public IActionResult Index(int pagina = 1)
        {
            var cantidadRegistrosPorPagina = 5;

            var vacantes = _vacanteRepositorio.ObtenerDestacados(pagina, cantidadRegistrosPorPagina);
            
            
                

            var totalDeRegistros = _vacanteRepositorio.ObtenerDestacados().Count();


            var modelo = new IndexViewModel();
            modelo.Vacantes = vacantes;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = cantidadRegistrosPorPagina;

            ViewBag.Categorias = _categoriaRepositorio.ObtenerTodos();
            //var vacante = _vacanteRepositorio.ObtenerDestacados();

            
            return View(modelo);

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