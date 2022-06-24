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

        int ContarPorNombre(Categoria categoria);
    }
    public class CategoriaRepository : ICategoriaRepositorio
    {
        private readonly DbEntities _dbEntities;
        public CategoriaRepository(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public int ContarPorNombre(Categoria categoria)
        {
            return _dbEntities.Categorias.Count(o => o.Nombre == categoria.Nombre);
        }

        public void Editar(int id, Categoria categoria)
        {
            var EditCat = _dbEntities.Categorias.First(o => o.Id == id);
            EditCat.Nombre = categoria.Nombre;
            EditCat.Descripcion = categoria.Descripcion;
            _dbEntities.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var categoriaDb = _dbEntities.Categorias.First(o => o.Id == id);
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
            return _dbEntities.Categorias.First(o => o.Id == id);
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
