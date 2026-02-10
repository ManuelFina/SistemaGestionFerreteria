using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SistemaGestionFerreteria.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public required string Nombre { get; set; }

        public string? Descripcion { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }

}
