using System.ComponentModel.DataAnnotations;

namespace SistemaGestionFerreteria.Models.ViewModels
{
    public class VentaViewModel
    {
        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Cantidad { get; set; }
    }
}