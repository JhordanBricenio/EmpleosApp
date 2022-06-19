using EmpleosApp.Models;
using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmpleosApp.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepositorio _categoriasRepository;
       // private readonly IAuthRepositorio _authRepositorio;
        public CategoriasController(ICategoriaRepositorio categoriasRepository)
        {
            this._categoriasRepository = categoriasRepository;
            //this._authRepositorio = authRepositorio;
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
            if (categoria.Nombre.Length<3)
            {
                ModelState.AddModelError("Nombre", "El nombre debe tener al menos 3 caracteres");

            }
            if (categoria.Descripcion.Length < 10)
            {
                ModelState.AddModelError("Descripcion", "El nombre debe tener al menos 3 caracteres");

            }
            if (ModelState.IsValid)
            {

             _categoriasRepository.Guardar(categoria);
             TempData["SuccessMessage"] = "Se añádio la categoría de forma correcta";
              return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Categoria = _categoriasRepository.ObtenerPorId(id);
            if (Categoria == null)
            {
                return RedirectToAction("Index");
            }
            return View(Categoria);
        }

        [HttpPost]
        public IActionResult Edit(int id, Categoria categoria )
        {
            if (categoria.Nombre.Length < 3)
            {
                ModelState.AddModelError("Nombre", "El nombre debe tener al menos 3 caracteres");

            }
            if (categoria.Descripcion.Length < 10)
            {
                ModelState.AddModelError("Descripcion", "El nombre debe tener al menos 3 caracteres");

            }
            _categoriasRepository.Editar(id, categoria);
            TempData["SuccessMessage"] = "Se editó la categoría de forma correcta";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _categoriasRepository.Eliminar(id);
            TempData["SuccessMessage"] = "Se eliminó la categoría de forma correcta";
            return RedirectToAction("Index");
        }


    }
}
