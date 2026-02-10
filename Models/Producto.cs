using System.ComponentModel.DataAnnotations;

namespace SistemaGestionFerreteria.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public required string Nombre { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public int ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }

        //public ICollection<DetalleVenta> DetallesVenta { get; set; }
    }

}
