using EmpleosApp.DB;
using EmpleosApp.Models;

namespace EmpleosApp.Repositorio
{
    public interface ICategoriaRepositorio
    {
        List<Categoria> ObtenerTodos();

        void Guardar(Categoria categoria);

        Categoria ObtenerPorId(int id);

        Categoria ObtenerPorIdCategoria(Categoria categoria);

        void Editar(Categoria categoria);

        void Eliminar(int id);
    }
    public class CategoriaRepository : ICategoriaRepositorio
    {
        private DbEntities _dbEntities;
        public CategoriaRepository(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public void Editar(Categoria categoria)
        {
            
        }

        public void Eliminar(int id)
        {
            var categoriaDb = ObtenerPorId(id);
            _dbEntities.Categorias.Remove(categoriaDb);
            _dbEntities.SaveChanges();
        }

        public void Guardar(Categoria categoria)
        {
            _dbEntities.Add(categoria);
            _dbEntities.SaveChanges();
        }

        public Categoria ObtenerPorId(int id)
        {
            return _dbEntities.Categorias.Find(id);
        }

        public Categoria ObtenerPorIdCategoria(Categoria categoria)
        {
            return _dbEntities.Categorias.Where(x => x.Id == categoria.Id).SingleOrDefault();
        }
        public List<Categoria> ObtenerTodos()
        {
            return _dbEntities.Categorias.ToList();
        }
    }
}
