using EmpleosApp.DB;
using EmpleosApp.Models;
using EmpleosApp.Repositorio;
using EmpleosAppTest.Helpers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleosAppTest.Repositorio
{
    public class CategoriaRepositorioTest
    {
        private static IQueryable<Categoria>? data;
        [SetUp]
        public void Setup()
        {
            data = new List<Categoria>
            {
                new Categoria { Id = 1, Nombre = "Categoria 01" },
                new Categoria { Id = 2, Nombre = "Categoria 02" },

            }.AsQueryable();
        }
        [Test]
        public void ObtenerTodosTestCaso01()
        {
           var mockBdSetCategoria = new MockDbSet<Categoria>(data);


           var mockBd = new Mock<DbEntities>();
               mockBd.Setup(x => x.Categorias).Returns(mockBdSetCategoria.Object);

            var cuentaRepo = new CategoriaRepository(mockBd.Object);

            var result = cuentaRepo.ObtenerTodos();

            Assert.AreEqual(2, result.Count);
        }
    }
}
