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
    public class HomeControllerTest
    {
        [Test]
        public void IndexTest01()
        {
            var mockVacante = new Mock<IVacanteRepositorio>();
                //mockVacante.Setup(x => x.ObtenerDestacados(1, 1)).Returns(new List<Vacante>() {new Vacante(){Id=1, Descripcion = "Hola" } });
                mockVacante.Setup(o =>o.ObtenerDestacados()).Returns(new List<Vacante>() { new Vacante() { Id = 1, Descripcion = "Hola" } });
            var mockCategoria = new Mock<ICategoriaRepositorio>();
            
            var controller = new HomeController(mockVacante.Object, mockCategoria.Object);

            var result =(ViewResult) controller.Index(1);
            Assert.IsNotNull(result);

           //Assert.IsNotNull(result.Model);//Modelo  enviado hacia la vsita no es nulo

        }

        [Test]
        public void DetalleTest01()
        {
            var mockVacante = new Mock<IVacanteRepositorio>();
            var mockCategoria = new Mock<ICategoriaRepositorio>();
            var controller = new HomeController(mockVacante.Object, mockCategoria.Object);
            var result = controller.Acerca();
            Assert.IsNotNull(result);
        }
    }
}