using EmpleosApp.Models;
using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmpleosApp.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly ISolicitudRepositorio _solicitudesRepository;
        private readonly IAuthRepositorio _authRepositorio;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SolicitudesController(ISolicitudRepositorio solicitudesRepository, IAuthRepositorio authRepositorio, IWebHostEnvironment hostEnvironment)
        {
            _solicitudesRepository = solicitudesRepository;
            _authRepositorio = authRepositorio;
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            var solicitudes = _solicitudesRepository.ObtenerTodos();
            return View("ListSolicitudes", solicitudes);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.Vacantes = _solicitudesRepository.ObtenerPorId(id);
            return View("FormSolicitud");
        }
        
        [HttpPost]
        public IActionResult Save(Solicitud solicitud)
        {

            solicitud.IdUsuario = GetLoggerUser().Id;
            solicitud.Fecha = DateTime.Now;
            solicitud.Archivo = UploadedFile(solicitud);
           
                
                _solicitudesRepository.Guardar(solicitud);
                TempData["SuccessMessage"] = "Gracias por enviar tu CV!";
                return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            _solicitudesRepository.Eliminar(id);
            TempData["SuccessMessage"] = "Solicitud eliminada";
            return RedirectToAction("Index");
        }
        
        private string UploadedFile(Solicitud solicitud)
        {
            string? fileName = null;
            //ImageFile = variable local
            //ImegnName= nombre

            if (solicitud.ImageFile != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                fileName = Path.GetFileNameWithoutExtension(solicitud.ImageFile.FileName);
                string extension = Path.GetExtension(solicitud.ImageFile.FileName);
                solicitud.Archivo = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/archivos/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    solicitud.ImageFile.CopyTo(fileStream);
                }
            }

            return fileName;
        }
        public FileResult Download(string docName)
        {
            var FileVirtualPath = "~/archivos/" + docName;

            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));

        }
        private Usuario GetLoggerUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            
            var username = claim.Value;
            return _authRepositorio.aunteticacion(username);
        }


    }
}
