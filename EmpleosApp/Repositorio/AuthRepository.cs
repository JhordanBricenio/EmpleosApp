using EmpleosApp.DB;
using EmpleosApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpleosApp.Repositorio
{
    public interface IAuthRepositorio
    {
        Usuario aunteticacion(string username);
        bool aunteticacionCokie(string username, string password);

        Usuario aunteticacionCok(string username, string password);



    }
    public class AuthRepository : IAuthRepositorio
    {
        private readonly DbEntities _dbEntities;
        public AuthRepository(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public Usuario aunteticacion(string username)
        {
            return _dbEntities.Usuarios.First(o => o.Username == username);
        }

        public bool aunteticacionCokie(string username, string password)
        {
            return _dbEntities.Usuarios.Include("Perfiles.Perfil").Any(o => o.Username == username && o.Password == password);
        }
        public Usuario aunteticacionCok(string username, string password)
        {
            return _dbEntities.Usuarios.Where(o => o.Username == username && o.Password == password).Include("Perfiles.Perfil").SingleOrDefault();
        }


    }
}
