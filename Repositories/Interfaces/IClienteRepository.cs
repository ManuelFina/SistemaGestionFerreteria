using SistemaGestionFerreteria.Models.Entities;

namespace SistemaGestionFerreteria.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ObtenerTodosAsync();

        Task<Cliente?> ObtenerPorIdAsync(int id);

        Task CrearAsync(Cliente cliente);

        Task ActualizarAsync(Cliente cliente);

        Task EliminarAsync(int id);
    }
}