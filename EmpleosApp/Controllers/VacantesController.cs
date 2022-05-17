using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace EmpleosApp.Controllers
{
    
    public class VacantesController : Controller
    {
        private IVacanteRepositorio _vacanteRepositorio;
        private ICategoriaRepositorio _categoriaRepositorio;
        public VacantesController(IVacanteRepositorio vacanteRepositorio, ICategoriaRepositorio categoriaRepositorio)
        {
            this._vacanteRepositorio = vacanteRepositorio;
            this._categoriaRepositorio = categoriaRepositorio;
        }
        public IActionResult Index()
        {
            var vacantes = _vacanteRepositorio.ObtenerTodos();
            return View("ListVacantes", vacantes);
        }
        public IActionResult VerDetalle(int id)
        {
            var vacantes = _vacanteRepositorio.ObtenerPorId(id);
            return View("Detalle",vacantes);
        }
        public IActionResult Create()
        {
            var categorias = _categoriaRepositorio.ObtenerTodos();
            return View("FormVacante", categorias);
        }

    }
}
