using EmpleosApp.DB;
using EmpleosApp.Models;

namespace EmpleosApp.Repositorio
{
    public interface ICategoriaRepositorio
    {
        List<Categoria> ObtenerTodos();

        void Guardar(Categoria categoria);

        Categoria ObtenerPorId(int id);

        void Editar(int id, Categoria categoria);

        void Eliminar(int id);

        List<Categoria> ObtenerPorNombre(string cadena);
    }
    public class CategoriaRepository : ICategoriaRepositorio
    {
        private DbEntities _dbEntities;
        public CategoriaRepository(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public void Editar(int id, Categoria categoria)
        {
            var EditCat = ObtenerPorId(id);
            EditCat.Nombre = categoria.Nombre;
            EditCat.Descripcion = categoria.Descripcion;
            _dbEntities.SaveChanges();
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

        public List<Categoria> ObtenerPorNombre(string cadena)
        {
            return _dbEntities.Categorias.Where(x => x.Nombre.Contains(cadena)).ToList();
        }

        public List<Categoria> ObtenerTodos()
        {
            return _dbEntities.Categorias.ToList();
        }
    }
}
