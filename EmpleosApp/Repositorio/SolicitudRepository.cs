using EmpleosApp.DB;
using EmpleosApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpleosApp.Repositorio
{

    public interface ISolicitudRepositorio
    {
        List<Solicitud> ObtenerTodos();
        Vacante ObtenerPorId(int id);

        void Guardar(Solicitud solicitud);
    }
    public class SolicitudRepository: ISolicitudRepositorio
    {

            private DbEntities _dbEntities;
            public SolicitudRepository(DbEntities dbEntities)
            {
                _dbEntities = dbEntities;
            }

        public void Guardar(Solicitud solicitud)
        {
            _dbEntities.Solicitudes.Add(solicitud);
        }

        public Vacante ObtenerPorId(int id)
        {
            return _dbEntities.Vacantes.Include("Categorias").First(o => o.Id == id);
        }

        public List<Solicitud> ObtenerTodos()
            {
                return _dbEntities.Solicitudes.ToList();
            }
        
    }
}