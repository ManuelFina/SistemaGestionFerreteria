using System.ComponentModel.DataAnnotations;

namespace SistemaGestionFerreteria.Models.Entities
{
    public class Proveedor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [Phone]
        public string? Telefono { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public ICollection<Producto>? Productos { get; set; }
    }
}