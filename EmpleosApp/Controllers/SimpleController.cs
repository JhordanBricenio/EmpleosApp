using EmpleosApp.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpleosApp.Controllers
{
    public class SimpleController : Controller
    {
        private DbEntities _dbEntities;
        public SimpleController(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }
        // GET: SimpleController
        public ActionResult Index()
        {
            
            var ret = _dbEntities.Usuarios.Include("Perfiles.Perfil").ToList();
            return View(ret); 
        }



       

    }
}
