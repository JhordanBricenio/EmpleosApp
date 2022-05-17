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
    public class UsuarioRepositorioTest
    {
        private static IQueryable<Usuario>? data;
        [SetUp]
        public void Setup()
        {
            data = new List<Usuario>
            {
                new Usuario { Id = 1, Nombre = "admin" },
                new Usuario { Id = 2, Nombre = "test" },
                new Usuario { Id = 3, Nombre = "test02" },

            }.AsQueryable();
        }
        [Test]
        public void ObtenerTodosTestCaso01()
        {
            var mockBdSetCategoria = new MockDbSet<Usuario>(data);


            var mockBd = new Mock<DbEntities>();
            mockBd.Setup(x => x.Usuarios).Returns(mockBdSetCategoria.Object);

            var cuentaRepo = new UsuarioRepository(mockBd.Object);

            var result = cuentaRepo.ObtenerTodos();

            Assert.AreEqual(3, result.Count);
        }
    }
}
