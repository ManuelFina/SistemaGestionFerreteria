using System.ComponentModel.DataAnnotations;

namespace SistemaGestionFerreteria.Models
{
    public class Proveedor
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public required string Nombre { get; set; }

        [Phone]
        public string? Telefono { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }

}
