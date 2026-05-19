namespace SistemaGestionFerreteria.Models.ViewModels
{
    public class VentaListadoViewModel
    {
        public int VentaId { get; set; }

        public string Cliente { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }
    }
}