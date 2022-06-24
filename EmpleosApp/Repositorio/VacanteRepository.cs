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

        int ContarVancanteNombre(Vacante vacante);

        void Delete(int id);
    }
    
    public class VacanteRepository : IVacanteRepositorio
    {
        private readonly DbEntities _dbEntities;

        public VacanteRepository(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public int ContarVancanteNombre(Vacante vacante)
        {
            return _dbEntities.Vacantes.Count(x => x.Nombre == vacante.Nombre);
        }

        public void Create(Vacante vacante)
        {
            _dbEntities.Vacantes.Add(vacante);
            _dbEntities.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbEntities.Vacantes.Remove(ObtenerPorId(id));
            _dbEntities.SaveChanges();
        }

        public List<Vacante> ObtenerDestacados(int pagina, int cantidadRegistrosPorPagina)
        {
            return _dbEntities.Vacantes.Include("Categorias")
                .OrderByDescending(x => x.Fecha)
                 .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                 .Take(cantidadRegistrosPorPagina).ToList();

        }

        public List<Vacante> ObtenerDestacados()
        {
            return _dbEntities.Vacantes.Include("Categorias").ToList();
        }

        public List<Vacante> ObtenerPorDescricion(int id)
        {
            return _dbEntities.Vacantes.Where(x => x.IdCategoria == id).Include("Categorias").ToList();
        }

        public Vacante ObtenerPorId(int id)
        {
            return _dbEntities.Vacantes.Include("Categorias").First(o => o.Id== id);
        }
        
        public List<Vacante> ObtenerTodos()
        {
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
        }
    }
}

