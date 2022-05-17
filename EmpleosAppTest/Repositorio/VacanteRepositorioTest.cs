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
    public class VacanteRepositorioTest
    {
        private static IQueryable<Vacante>? data;
        [SetUp]
        public void Setup()
        {
            data = new List<Vacante>
            {
                new Vacante { Id = 1, Nombre = "Vacante 01" },
                new Vacante { Id = 2, Nombre = "Vacante 01" },

            }.AsQueryable();
        }
        [Test]
        public void ObtenerTodosTestCaso01()
        {
            var mockBdSetVacante = new MockDbSet<Vacante>(data);


            var mockBd = new Mock<DbEntities>();
            mockBd.Setup(x => x.Vacantes).Returns(mockBdSetVacante.Object);

            var cuentaRepo = new VacanteRepository(mockBd.Object);

            var result = cuentaRepo.ObtenerTodos();

            Assert.AreEqual(2, result.Count);
        }
    }
}
