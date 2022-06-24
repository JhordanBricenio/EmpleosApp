using EmpleosApp.Models;
using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpleosApp.Controllers
{

    public class VacantesController : Controller
    {
        private readonly IVacanteRepositorio _vacanteRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IWebHostEnvironment _hostEnvironment;
        public VacantesController(IVacanteRepositorio vacanteRepositorio, ICategoriaRepositorio categoriaRepositorio, IWebHostEnvironment hostEnvironment)
        {
            this._vacanteRepositorio = vacanteRepositorio;
            this._categoriaRepositorio = categoriaRepositorio;
            this._hostEnvironment = hostEnvironment;
        }

        private string UploadedFile(Vacante vacante)
        {
            string fileName = null;


            if (vacante.ImageFile != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                fileName = Path.GetFileNameWithoutExtension(vacante.ImageFile.FileName);
                string extension = Path.GetExtension(vacante.ImageFile.FileName);
                vacante.Imagen = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    vacante.ImageFile.CopyTo(fileStream);
                }
            }

            return fileName;
        }
        public IActionResult Index()
        {
            var vacantes = _vacanteRepositorio.ObtenerTodos();
            return View("ListVacantes", vacantes);
        }
        public IActionResult VerDetalle(int id)
        {
            var vacantes = _vacanteRepositorio.ObtenerPorId(id);
            return View("Detalle", vacantes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categorias = _categoriaRepositorio.ObtenerTodos();
            ViewBag.Fecha = DateTime.Now;
            return View("FormVacante", categorias);
        }

        [HttpPost]
        public IActionResult Create(Vacante vacante)
        {
            vacante.Fecha = DateTime.Now;
            var cantidad = _vacanteRepositorio.ContarVancanteNombre(vacante);

            if (cantidad > 0)
            {
                ModelState.AddModelError("Nombre", "Ya existe una vacante con ese nombre");
            }

            vacante.Fecha = DateTime.Now;
            vacante.Imagen = UploadedFile(vacante);

            _vacanteRepositorio.Create(vacante);
            TempData["SuccessMessage"] = "Se agregó la vacante de forma correcta";
            return RedirectToAction(nameof(Index));


        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Vacante = _vacanteRepositorio.ObtenerPorId(id);
            if (Vacante == null)
            {
                return RedirectToAction("Index");
            }
            return View(Vacante);
        }

        [HttpPost]
        public IActionResult Edit(int id, Vacante vacante)
        {
            vacante.Fecha = DateTime.Now;
            if (id != vacante.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    if (vacante.ImageFile != null)
                    {
                        if (vacante.Imagen != null)
                        {
                            string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", vacante.Imagen);
                            System.IO.File.Delete(filePath);
                        }
                        vacante.Imagen = UploadedFile(vacante);
                    }

                    _vacanteRepositorio.Update(vacante);
                    TempData["SuccessMessage"] = "Se actualizó la vacante de forma correcta";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_vacanteRepositorio.VacanteExists(vacante.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vacante);
        }

        public IActionResult Delete(int id)
        {
            _vacanteRepositorio.Delete(id);
            TempData["SuccessMessage"] = "Se eliminó la vacante de forma correcta";
            return RedirectToAction(nameof(Index));
        }


    }
}
