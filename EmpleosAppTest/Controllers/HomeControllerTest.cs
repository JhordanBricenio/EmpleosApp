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
                mockVacante.Setup(x => x.ObtenerTodos()).Returns(new List<Vacante>() {new Vacante()});
            var mockCategoria = new Mock<ICategoriaRepositorio>();
            var controller = new HomeController(mockVacante.Object, mockCategoria.Object);
            var result =(ViewResult) controller.Index();
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