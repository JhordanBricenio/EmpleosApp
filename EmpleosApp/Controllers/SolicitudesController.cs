using EmpleosApp.Models;
using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace EmpleosApp.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly ISolicitudRepositorio _solicitudesRepository;

        public SolicitudesController(ISolicitudRepositorio solicitudesRepository)
        {
            _solicitudesRepository = solicitudesRepository;
        }
        public IActionResult Index()
        {
            var solicitudes = _solicitudesRepository.ObtenerTodos();
            return View("ListSolicitudes", solicitudes);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var vacante = _solicitudesRepository.ObtenerPorId(id);
            return View("FormSolicitud", vacante);
        }
        
        [HttpPost]
        public IActionResult Save(Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                _solicitudesRepository.Guardar(solicitud);
                TempData["SuccessMessage"] = "Se añádio el libro a su biblioteca";
                return RedirectToAction("Index");
            }
            return View("FormSolicitud", solicitud);
        }


    }
}
