using EmpleosApp.DB;
using EmpleosApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpleosApp.Repositorio
{
    public interface IVacanteRepositorio
    {
        List<Vacante> ObtenerTodos();
        Vacante ObtenerPorId(int id);

        List<Vacante> ObtenerDestacados(int pagina, int cantidadRegistrosPorPagina);

        List<Vacante> ObtenerDestacados();
        List<Vacante> ObtenerPorDescricion(int id);

        void Create(Vacante vacante);

        void Update(Vacante vacante);

        bool VacanteExists(int id);
    }
    
    public class VacanteRepository : IVacanteRepositorio
    {
        private DbEntities _dbEntities;

        public VacanteRepository(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public void Create(Vacante vacante)
        {
            _dbEntities.Vacantes.Add(vacante);
            _dbEntities.SaveChanges();
        }

        public List<Vacante> ObtenerDestacados(int pagina, int cantidadRegistrosPorPagina)
        {
            return _dbEntities.Vacantes.Include("Categorias")
                 .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                 .Take(cantidadRegistrosPorPagina).ToList();

           // return _dbEntities.Vacantes.Include("Categorias").ToList();
        }

        public List<Vacante> ObtenerDestacados()
        {
            return _dbEntities.Vacantes.Include("Categorias").ToList();
        }

        public List<Vacante> ObtenerPorDescricion(int id)
        {
            return _dbEntities.Vacantes.Where(x => x.IdCategoria == id).Include("Categorias").ToList();
          //  return _dbEntities.Vacantes.Where(x => x.Descripcion.Contains(cadena)).ToListAsync().Result;
        }

        public Vacante ObtenerPorId(int id)
        {
            return _dbEntities.Vacantes.Include("Categorias").First(o => o.Id== id);
        }
        
        public List<Vacante> ObtenerTodos()
        {
            //return _dbEntities.Vacantes.ToList();
           return _dbEntities.Vacantes.Include("Categorias").ToList();


        }

        public void Update(Vacante vacante)
        { 
            _dbEntities.Update(vacante);
            _dbEntities.SaveChanges();
        }

        public bool VacanteExists(int id)
        {
            return _dbEntities.Vacantes.Any(o => o.Id == id);
             //_context.Carousel.Any(e => e.CarouselId == id);
        }
    }
}

