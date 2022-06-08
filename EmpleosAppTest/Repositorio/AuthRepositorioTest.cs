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
    public class AuthRepositorioTest
    {
        private static IQueryable<Usuario>? data;
        [SetUp]
        public void Setup()
        {
            data = new List<Usuario>
            {
                new Usuario { Id = 1, Username = "admin" , Password="123"},
                new Usuario {  Id = 1, Username = "test" , Password="123" },
                
            }.AsQueryable();
        }
        [Test]
        public void ObtenerUsuarioPorNombreTestCaso01()
        {
            var mockBdSetUsuario= new MockDbSet<Usuario>(data);


            var mockBd = new Mock<DbEntities>();
                mockBd.Setup(x => x.Usuarios).Returns(mockBdSetUsuario.Object);

            var usuarioRepo = new AuthRepository(mockBd.Object);

            var result = usuarioRepo.aunteticacion("admin");

            Assert.IsNotNull(result);
        }

        [Test]
        public void ObtenerUsuarioPorNombreYPasswordTestCaso01()
        {
            var mockBdSetUsuario = new MockDbSet<Usuario>(data);


            var mockBd = new Mock<DbEntities>();
            mockBd.Setup(x => x.Usuarios).Returns(mockBdSetUsuario.Object);

            var usuarioRepo = new AuthRepository(mockBd.Object);

            var result = usuarioRepo.aunteticacionCokie("admin", "123");

            Assert.AreEqual(true, result);
        }
    }
}
