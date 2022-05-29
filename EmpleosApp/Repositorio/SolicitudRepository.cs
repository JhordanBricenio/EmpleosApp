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

        Solicitud ObtenerPorIdDelete(int id);
        void Eliminar(int id);
    }
    public class SolicitudRepository: ISolicitudRepositorio
    {

            private DbEntities _dbEntities;
            public SolicitudRepository(DbEntities dbEntities)
            {
                _dbEntities = dbEntities;
            }

        public void Eliminar(int id)
        {
            var solicitud = ObtenerPorIdDelete(id);
            _dbEntities.Remove(solicitud);
            _dbEntities.SaveChanges();
        }

        public void Guardar(Solicitud solicitud)
        {
            _dbEntities.Solicitudes.Add(solicitud);
            _dbEntities.SaveChanges();
        }

        public Vacante ObtenerPorId(int id)
        {
            return _dbEntities.Vacantes.Include("Categorias").First(o => o.Id == id);
        }

        public Solicitud ObtenerPorIdDelete(int id)
        {
            return _dbEntities.Solicitudes.First(o => o.Id == id);
        }

        public List<Solicitud> ObtenerTodos()
            {
            return _dbEntities.Solicitudes
                    .Include("Vacante")
                    .Include("Usuario")
                    .ToList();
                        
                        //.Include("Vacantes").ToList();
            }
        
    }
}