using System.ComponentModel.DataAnnotations;

namespace SistemaGestionFerreteria.Models.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Telefono { get; set; }

        public ICollection<Venta>? Ventas { get; set; }
    }
}