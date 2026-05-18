using SistemaGestionFerreteria.Models.Entities;

namespace SistemaGestionFerreteria.Repositories.Interfaces
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<Proveedor>> ObtenerTodosAsync();

        Task<Proveedor?> ObtenerPorIdAsync(int id);

        Task CrearAsync(Proveedor proveedor);

        Task ActualizarAsync(Proveedor proveedor);

        Task EliminarAsync(int id);
    }
}