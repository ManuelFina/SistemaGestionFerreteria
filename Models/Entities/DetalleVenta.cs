using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionFerreteria.Models.Entities
{
    public class DetalleVenta
    {
        public int Id { get; set; }

        [Required]
        public int VentaId { get; set; }

        public Venta? Venta { get; set; }

        [Required]
        public int ProductoId { get; set; }

        public Producto? Producto { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioUnitario { get; set; }
    }
}