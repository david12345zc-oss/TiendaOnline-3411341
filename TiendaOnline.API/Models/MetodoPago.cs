using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.API.Models
{
    public class MetodoPago
    {
        [Key]
        public int IdMetodoPago { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;
    }
}