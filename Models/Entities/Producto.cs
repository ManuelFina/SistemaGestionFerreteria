using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionFerreteria.Models.Entities
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 999999)]
        public decimal Precio { get; set; }

        [Required]
        [Range(0, 10000)]
        public int Stock { get; set; }

        public string? ImagenUrl { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }

        [Required]
        public int ProveedorId { get; set; }

        public Proveedor? Proveedor { get; set; }

        public ICollection<DetalleVenta>? DetalleVentas { get; set; }
    }
}