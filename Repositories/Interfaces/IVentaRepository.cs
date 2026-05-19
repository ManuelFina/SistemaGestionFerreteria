using SistemaGestionFerreteria.Models.Entities;
using SistemaGestionFerreteria.Models.ViewModels;

namespace SistemaGestionFerreteria.Repositories.Interfaces
{
    public interface IVentaRepository
    {
        Task<IEnumerable<Venta>> ObtenerTodasAsync();

        Task<Venta?> ObtenerPorIdAsync(int id);

        Task CrearVentaAsync(Venta venta);

        Task<IEnumerable<VentaListadoViewModel>> ObtenerVentasSPAsync(); //stored procedure
    }
}