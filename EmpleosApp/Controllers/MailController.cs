using Microsoft.AspNetCore.Mvc;
using EmpleosApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleosApp.Controllers
{
    public class MailController : Controller
    {
        private readonly IMailService MailService;
        public MailController(IMailService MailService)
        {
            this.MailService = MailService;
        }
        public IActionResult Index(string email )
        {
            ViewBag.Email = email;   
            return View();
        }

        [HttpPost]
        public IActionResult Index(String proveedorEmail, String direccionEnvio, String asunto, String mensaje) 
        {
            if (proveedorEmail.ToLower() == "gmail")
            {
                this.MailService.SendEmailGmail(direccionEnvio, asunto, mensaje);
            } else
            {
                this.MailService.SendEmailOutlook(direccionEnvio, asunto, mensaje);
            }
            TempData["SuccessMessage"] = "Email enviado a " + direccionEnvio;
            //ViewData["MENSAJE"] = "email enviado a " + direccionEnvio;
            return RedirectToAction("Index", "Solicitudes");
        }
    }
}
