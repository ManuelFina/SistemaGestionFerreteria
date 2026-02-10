namespace SistemaGestionFerreteria.Models.ViewModel
{
    public class ProductoListViewModel
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public decimal Precio { get; set; }
        public required string Categoria { get; set; }
    }
}
