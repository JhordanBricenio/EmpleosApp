using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleosApp.Models
{
    [Table("Vacantes")]

    public  class Vacante
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public String? Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Salario { get; set; }
        public int Estatus { get; set; }
        public int Destacado { get; set; }

        public String? Imagen { get; set; }

        public String? Detalles { get; set; }

        public int IdCategoria { get; set; }


        public  Categoria Categorias { get; set; }


        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; }



    }
}
