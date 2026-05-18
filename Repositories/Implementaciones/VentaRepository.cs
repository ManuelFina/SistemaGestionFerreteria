using Microsoft.EntityFrameworkCore;
using SistemaGestionFerreteria.Data;
using SistemaGestionFerreteria.Models.Entities;
using SistemaGestionFerreteria.Repositories.Interfaces;

namespace SistemaGestionFerreteria.Repositories.Implementaciones
{
    public class VentaRepository(ApplicationDbContext context) : IVentaRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Venta>> ObtenerTodasAsync()
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.DetalleVentas)
                .ToListAsync();
        }

        public async Task<Venta?> ObtenerPorIdAsync(int id)
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.DetalleVentas)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task CrearAsync(Venta venta)
        {
            await _context.Ventas.AddAsync(venta);
            await _context.SaveChangesAsync();
        }
    }
}