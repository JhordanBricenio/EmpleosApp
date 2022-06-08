using EmpleosApp.Models;
using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpleosApp.Controllers
{
    
    public class VacantesController : Controller
    {
        private IVacanteRepositorio _vacanteRepositorio;
        private ICategoriaRepositorio _categoriaRepositorio;
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
            //ImageFile = variable local
            //ImegnName= nombre
            
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
            return View("Detalle",vacantes);
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
            
            //var categorias = _categoriaRepositorio.ObtenerTodos();
            


            //Save image to wwwroot/image
            vacante.Imagen = UploadedFile(vacante);

                //Insert record
                _vacanteRepositorio.Create(vacante);
                return RedirectToAction(nameof(Index));
                
            
            //return View("FormVacante", categorias);
            
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categorias = _categoriaRepositorio.ObtenerTodos();
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
            if (id != vacante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
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


    }
}
