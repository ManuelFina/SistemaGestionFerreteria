using Microsoft.EntityFrameworkCore;
using SistemaGestionFerreteria.Data;
using SistemaGestionFerreteria.Models.Entities;
using SistemaGestionFerreteria.Repositories.Interfaces;

namespace SistemaGestionFerreteria.Repositories.Implementaciones
{
    public class ProductoRepository(ApplicationDbContext context) : IProductoRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Producto>> ObtenerTodosAsync()
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .ToListAsync();
        }

        public async Task<Producto?> ObtenerPorIdAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CrearAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var producto = await ObtenerPorIdAsync(id);

            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}