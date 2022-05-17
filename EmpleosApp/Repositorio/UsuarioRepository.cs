using EmpleosApp.DB;
using EmpleosApp.Models;

namespace EmpleosApp.Repositorio
{

    public interface IUsuarioRepositorio
    {
        List<Usuario> ObtenerTodos();
    }    
    public class UsuarioRepository: IUsuarioRepositorio
    {

        private DbEntities _dbEntities;
        public UsuarioRepository(DbEntities dbEntities)
        {
           _dbEntities = dbEntities;
        }

        public List<Usuario> ObtenerTodos()
        {
            return _dbEntities.Usuarios.ToList();
        }


    }
}
