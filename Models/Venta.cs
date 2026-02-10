using System.ComponentModel.DataAnnotations;

namespace SistemaGestionFerreteria.Models
{
    public class Venta
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Total { get; set; }

        //public ICollection<DetalleVenta> Detalles { get; set; }
    }

}
