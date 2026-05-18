using SistemaGestionFerreteria.Models.Entities;

namespace SistemaGestionFerreteria.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> ObtenerTodosAsync();

        Task<Producto?> ObtenerPorIdAsync(int id);

        Task CrearAsync(Producto producto);

        Task ActualizarAsync(Producto producto);

        Task EliminarAsync(int id);
    }
}