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
    public class SolicitudRepositorioTest
    {

        private static IQueryable<Solicitud>? data;
        [SetUp]
        public void Setup()
        {
            data = new List<Solicitud>
            {
                new Solicitud { Id = 1, Fecha=DateTime.Now },
                new Solicitud { Id = 2, Fecha=DateTime.Now },
                new Solicitud { Id = 3, Fecha=DateTime.Now },

            }.AsQueryable();
        }
        [Test]
        public void ObtenerTodosTestCaso01()
        {
            var mockBdSetSolicitud = new MockDbSet<Solicitud>(data);


            var mockBd = new Mock<DbEntities>();
            mockBd.Setup(x => x.Solicitudes).Returns(mockBdSetSolicitud.Object);

            var cuentaRepo = new SolicitudRepository(mockBd.Object);

            var result = cuentaRepo.ObtenerTodos();

            Assert.AreEqual(3, result.Count);
        }
    }
}
