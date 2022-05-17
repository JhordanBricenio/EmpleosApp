using EmpleosApp.Models;
using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace EmpleosApp.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepositorio _categoriasRepository;
        public CategoriasController(ICategoriaRepositorio categoriasRepository)
        {
            this._categoriasRepository = categoriasRepository;
        }
        public IActionResult Index()
        {
            
            var categorias= _categoriasRepository.ObtenerTodos();
            return View("ListCategoria", categorias);
        }
        
        public IActionResult Create()
        {
            return View("FormCategoria");
        }

        public IActionResult Save(Categoria categoria)
        {
            if (ModelState.IsValid)
            {

             _categoriasRepository.Guardar(categoria);
             TempData["SuccessMessage"] = "Se añádio la categoría de forma correcta";
              return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }
        public IActionResult Edit(int id )
        {
            var Categoria = _categoriasRepository.ObtenerPorId(id);
            //var Cliente = ctx.Clientes.Where(x=>x.IdCliente == id).SingleOrDefault()
            if (Categoria == null)
            {
                return RedirectToAction("Index");
            }
            return View(Categoria);
        }

        public ActionResult Delete(int id)
        {
            _categoriasRepository.Eliminar(id);
            return RedirectToAction("Index");
        }

    }
}
