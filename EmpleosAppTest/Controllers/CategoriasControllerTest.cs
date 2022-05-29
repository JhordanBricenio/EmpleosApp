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
    public  class CategoriasControllerTest
    {
        [Test]
        public void IndexTest01()
        {
            var mockCategorias = new Mock<ICategoriaRepositorio>();
            mockCategorias.Setup(x => x.ObtenerTodos()).Returns(new List<Categoria>() { new Categoria() });
            var controller = new CategoriasController(mockCategorias.Object, null);
            var result =(ViewResult)controller.Index();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);//Modelo  enviado hacia la vsita no es nulo

        }


        [Test]
        public void CreateGetTest01()
        {
            var mockCategorias = new Mock<ICategoriaRepositorio>();
            var controller = new CategoriasController(mockCategorias.Object, null);
            var result = controller.Create();
            Assert.IsNotNull(result);

        }
    }
}
