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
                new Categoria { Id = 1, Nombre = "Categoria01" },
                new Categoria { Id = 2, Nombre = "Categoria02" },

            }.AsQueryable();
        }
        [Test]
        public void ObtenerTodosTestCaso01()
        {
           var mockBdSetCategoria = new MockDbSet<Categoria>(data);


           var mockBd = new Mock<DbEntities>();
               mockBd.Setup(x => x.Categorias).Returns(mockBdSetCategoria.Object);

            var cateRepo = new CategoriaRepository(mockBd.Object);

            var result = cateRepo.ObtenerTodos();

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void ObtenerPorNombreTestCaso01()
        {
            var mockBdSetCategoria = new MockDbSet<Categoria>(data);


            var mockBd = new Mock<DbEntities>();
            mockBd.Setup(x => x.Categorias).Returns(mockBdSetCategoria.Object);

            var cateRepo = new CategoriaRepository(mockBd.Object);

            var result = cateRepo.ObtenerPorNombre("Categoria01");

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void ObtenerPorIdTestCaso01()
        {
            var mockBdSetCategoria = new MockDbSet<Categoria>(data);


            var mockBd = new Mock<DbEntities>();
            mockBd.Setup(x => x.Categorias).Returns(mockBdSetCategoria.Object);

            var cateRepo = new CategoriaRepository(mockBd.Object);

            var result = cateRepo.ObtenerPorId(1);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GuardarTestCaso01()
        {
            var mockBdSetCategoria = new MockDbSet<Categoria>(data);


            var mockBd = new Mock<DbEntities>();
            mockBd.Setup(x => x.Categorias).Returns(mockBdSetCategoria.Object);

            var cateRepo = new CategoriaRepository(mockBd.Object);
                 cateRepo.Guardar(new Categoria() { Id = 3, Nombre = "Categoria01" });

            



            //mockBdSetCategoria.Verify(o => o.Add(datoAgregar), Times.Once());


           // Assert.Null(result);
        }

        [Test]
        public void EliminarTestCaso01()
        {
            var mockBdSetCategoria = new MockDbSet<Categoria>(data);
              // mockBdSetCategoria.Setup(o =>o.);


            var mockBd = new Mock<DbEntities>();
                mockBd.Setup(x => x.Categorias).Returns(mockBdSetCategoria.Object);

            var cateRepo = new CategoriaRepository(mockBd.Object);
                cateRepo.Eliminar(1);

            var datoMockEliminar = data.First(o => o.Id == 1);
                 mockBdSetCategoria.Verify(o => o.Remove(datoMockEliminar), Times.Once());

            // Assert.Null(result);
        }

        [Test]
        public void EditarTestCaso01()
        {
            var mockBdSetCategoria = new MockDbSet<Categoria>(data);
            // mockBdSetCategoria.Setup(o =>o.);


            var mockBd = new Mock<DbEntities>();
                mockBd.Setup(x => x.Categorias).Returns(mockBdSetCategoria.Object);

            var cateRepo = new CategoriaRepository(mockBd.Object);
            cateRepo.Editar(1, data.First(o => o.Id == 1));

            var datoMockEliminar = data.First(o => o.Id == 1);
                mockBdSetCategoria.Verify(o => o.Update(datoMockEliminar), Times.Never());

            // Assert.Null(result);
        }
    }
}
