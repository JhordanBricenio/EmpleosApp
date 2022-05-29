using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleosApp.Models
{
    [Table("Solicitudes")]
    public class Solicitud
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public string?  Comentarios { get; set; }
        public string  Archivo { get; set; }

        public int IdUsuario { get; set; }

        public int IdVacante { get; set; }
        public virtual Usuario? Usuario { get; set; }

        public virtual Vacante? Vacante { get; set; }


        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; }
    }
}
