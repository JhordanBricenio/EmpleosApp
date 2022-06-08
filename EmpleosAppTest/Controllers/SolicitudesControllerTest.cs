using EmpleosApp.Controllers;
using EmpleosApp.Models;
using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmpleosAppTest.Controllers
{
    public class SolicitudesControllerTest
    {
        [Test]
        public void IndexTest01()
        {
            var mockSolicitud= new Mock<ISolicitudRepositorio>();
            mockSolicitud.Setup(x => x.ObtenerTodos()).Returns(new List<Solicitud>() { new Solicitud() });
            var controller = new SolicitudesController(mockSolicitud.Object, null, null);
            var result =(ViewResult)controller.Index();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOf<List<Solicitud>>(result.Model);
            Assert.AreEqual(1, ((List<Solicitud>)result.Model).Count);

        }

        [Test]
        public void CreateTest01()
        {
            var mockSolicitud = new Mock<ISolicitudRepositorio>();
            var controller = new SolicitudesController(mockSolicitud.Object, null, null);
            var result = controller.Create(1);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);

        }

        [Test]
        public void CreatePost01()
        {
            var mockSolicitud = new Mock<ISolicitudRepositorio>();
                mockSolicitud.Setup(o => o.Guardar(new Solicitud()));

            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
                mockClaimsPrincipal.Setup(x => x.Claims).Returns(new List<Claim> { new Claim(ClaimTypes.Name, "admin") });


            //Para crear el http context creamos un mock de la clase http context (mockContext)
            var mockContext = new Mock<HttpContext>();//Configurando user el cual usa htppcontext
                mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            //Mock para no usar el usuario(auntenticacion) de la base de datos
            var mockAuthRepo = new Mock<IAuthRepositorio>();
                mockAuthRepo.Setup(o => o.aunteticacion("admin")).Returns(new Usuario { Id = 1, Username = "admin" });

            //Mock para burlar tempData 
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
                tempData["SuccessMessage"] = "admin";


            var controller = new SolicitudesController(mockSolicitud.Object, mockAuthRepo.Object, null)
                {
                TempData = tempData
                };
                controller.ControllerContext = new ControllerContext()
                {
                    HttpContext = mockContext.Object
                };

            var result = controller.Save(new Solicitud());
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RedirectToActionResult>(result);

        }

        [Test]
        public void DeleteTest01()
        {
            var mockSolicitud = new Mock<ISolicitudRepositorio>();

            //Mock para burlar tempData 
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
                tempData["SuccessMessage"] = "admin";
            
            var controller = new SolicitudesController(mockSolicitud.Object, null, null)
                {
                    TempData = tempData
                }; 
            var result = controller.Delete(1);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RedirectToActionResult>(result);

        }

    }
}