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
            var controller = new CategoriasController(mockCategorias.Object);
            var result =(ViewResult)controller.Index();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);//Modelo  enviado hacia la vsita no es nulo

        }


        [Test]
        public void CreateGetTest01()
        {
            var mockCategorias = new Mock<ICategoriaRepositorio>();
            var controller = new CategoriasController(mockCategorias.Object);
            var result = controller.Create();
            Assert.IsNotNull(result);

        }

        [Test]
        public void CreatePostTest01()
        {
            var mockCategorias = new Mock<ICategoriaRepositorio>();
            
            
            
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["SuccessMessage"] = "admin";
            var controller = new CategoriasController(mockCategorias.Object)
            {
                TempData = tempData
            }; 
            var result = controller.Save(new Categoria() { Id = 1, Nombre = "Ingenieria" });
            Assert.IsNotNull(result);

        }
        
        [Test]
        public void EditGetTest01()
        {
            var mockCategorias = new Mock<ICategoriaRepositorio>();
            mockCategorias.Setup(x => x.ObtenerPorId(1)).Returns(new Categoria() { Id = 1, Nombre = "Ingenieria" });
            var controller = new CategoriasController(mockCategorias.Object);
            var result = controller.Edit(1);
            Assert.IsNotNull(result);

        }

        [Test]
        public void EditPostTest01()
        {
            var mockCategorias = new Mock<ICategoriaRepositorio>();
            
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["SuccessMessage"] = "admin";

            
            mockCategorias.Setup(x => x.Editar(1, new Categoria()));
            var controller = new CategoriasController(mockCategorias.Object)
            {
                TempData = tempData
            };
            
            var result = controller.Edit(1, new Categoria());
            Assert.IsNotNull(result);

        }


        [Test]
        public void DeleteTest01()
        {
            var mockCategorias = new Mock<ICategoriaRepositorio>();
                mockCategorias.Setup(x => x.Eliminar(1));

            var httpContext = new DefaultHttpContext();
            
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
                tempData["SuccessMessage"] = "admin";
                
            var controller = new CategoriasController(mockCategorias.Object)
            {
                TempData = tempData
            };

            var result = controller.Delete(1);
            Assert.IsNotNull(result);

        }
    }
}
