using SistemaGestionFerreteria.Models.Entities;

namespace SistemaGestionFerreteria.Repositories.Interfaces
{
    public interface IVentaRepository
    {
        Task<IEnumerable<Venta>> ObtenerTodasAsync();

        Task<Venta?> ObtenerPorIdAsync(int id);

        Task CrearVentaAsync(Venta venta);
    }
}