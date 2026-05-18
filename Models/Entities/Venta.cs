using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionFerreteria.Models.Entities
{
    public class Venta
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        public ICollection<DetalleVenta>? DetalleVentas { get; set; }
    }
}