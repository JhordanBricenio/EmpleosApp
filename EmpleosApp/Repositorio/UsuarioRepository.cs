using EmpleosApp.DB;
using EmpleosApp.Models;

namespace EmpleosApp.Repositorio
{

    public interface IUsuarioRepositorio
    {
        List<Usuario> ObtenerTodos();

        void registrarUsuario(Usuario usuario);

        Usuario GetUsuario(int id);

        void DeleteUsuario(int id);
    }    
    public class UsuarioRepository: IUsuarioRepositorio
    {

        private DbEntities _dbEntities;
        public UsuarioRepository(DbEntities dbEntities)
        {
           _dbEntities = dbEntities;
        }

        public void DeleteUsuario(int id)
        {
            var usuarioDelete = GetUsuario(id);
            _dbEntities.Usuarios.Remove(usuarioDelete);
            _dbEntities.SaveChanges();
        }

        public Usuario GetUsuario(int id)
        {
            return _dbEntities.Usuarios.First(o => o.Id == id);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _dbEntities.Usuarios.ToList();
        }

        public void registrarUsuario(Usuario usuario)
        {
            _dbEntities.Usuarios.Add(usuario);
            _dbEntities.SaveChanges();
        }
    }
}
