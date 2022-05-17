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
    public class VacantesControllerTest
    {
        [Test]
        public void IndexTest01()
        {
            var mockVacante = new Mock<IVacanteRepositorio>();
                mockVacante.Setup(x => x.ObtenerTodos()).Returns(new List<Vacante>() { new Vacante()});
            var mockCategoria = new Mock<ICategoriaRepositorio>();
            
            
            var controller = new VacantesController(mockVacante.Object, mockCategoria.Object);
            var result =(ViewResult)controller.Index();
            Assert.IsNotNull(result);
            Assert.AreEqual(1, ((List<Vacante>)result.Model).Count);
        }

        [Test]
        public void DetalleTest01()
        {
            var mockVacante = new Mock<IVacanteRepositorio>();
                mockVacante.Setup(x => x.ObtenerPorId(1)).Returns(new Vacante() );
            var mockCategoria = new Mock<ICategoriaRepositorio>();


            var controller = new VacantesController(mockVacante.Object, mockCategoria.Object);
            
            var result =(ViewResult) controller.VerDetalle(1);
            Assert.IsNotNull(result);

            Assert.IsInstanceOf<Vacante>(result.Model);
        }
    }
}