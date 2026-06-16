using Microsoft.EntityFrameworkCore;
using SistemaGestionFerreteria.Data;
using SistemaGestionFerreteria.Models.Entities;
using SistemaGestionFerreteria.Models.ViewModels;
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

        public async Task CrearVentaAsync(Venta venta)
        {
            foreach (var detalle in venta.DetalleVentas!)
            {
                var producto = await _context.Productos
                    .FirstOrDefaultAsync(p => p.Id == detalle.ProductoId);

                if (producto == null)
                    throw new Exception("Producto no encontrado.");
                
                if (producto.Stock < detalle.Cantidad)
                    throw new Exception($"Stock insuficiente para {producto.Nombre}");
                
                producto.Stock -= detalle.Cantidad;
            }

            await _context.Ventas.AddAsync(venta);

            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<VentaListadoViewModel>> ObtenerVentasSPAsync()
        {
            return await _context.VentasListado
                .FromSqlRaw("EXEC SP_LISTAR_VENTAS")
                .ToListAsync();
        }
    }
}