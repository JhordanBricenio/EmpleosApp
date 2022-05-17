using EmpleosApp.DB;
using EmpleosApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpleosApp.Repositorio
{
    public interface IVacanteRepositorio
    {
        List<Vacante> ObtenerTodos();
        Vacante ObtenerPorId(int id);

        List<Vacante> ObtenerDestacados();
    }
    
    public class VacanteRepository : IVacanteRepositorio
    {
        private DbEntities _dbEntities;

        public VacanteRepository(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public List<Vacante> ObtenerDestacados()
        {
            return _dbEntities.Vacantes.Where(x => x.Destacado == 1).Include("Categorias").ToList();
           // return _dbEntities.Vacantes.Include("Categorias").ToList();
        }

        public Vacante ObtenerPorId(int id)
        {
            return _dbEntities.Vacantes.First(o => o.Id== id);
        }
        
        public List<Vacante> ObtenerTodos()
        {
            return _dbEntities.Vacantes.ToList();
           // return _dbEntities.Vacantes.Include("Categoria").ToList();


        }
    }
}
