using System.ComponentModel.DataAnnotations;

namespace SistemaGestionFerreteria.Models.Entities
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Descripcion { get; set; }

        public ICollection<Producto>? Productos { get; set; }
    }
}
