using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleosApp.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }
    }
}
