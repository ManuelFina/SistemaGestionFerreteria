namespace SistemaGestionFerreteria.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalProductos { get; set; }

        public int TotalClientes { get; set; }

        public int TotalVentas { get; set; }

        public decimal TotalFacturado { get; set; }

        public int ProductosStockBajo { get; set; }
    }
}