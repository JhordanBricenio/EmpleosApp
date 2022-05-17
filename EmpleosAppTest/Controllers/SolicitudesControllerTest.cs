using EmpleosApp.Controllers;
using EmpleosApp.Models;
using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var controller = new SolicitudesController(mockSolicitud.Object);
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
            var controller = new SolicitudesController(mockSolicitud.Object);
            var result = controller.Create(1);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);

        }
    }
}