using Microsoft.EntityFrameworkCore;
using SistemaGestionFerreteria.Data;
using SistemaGestionFerreteria.Models.Entities;
using SistemaGestionFerreteria.Repositories.Interfaces;

namespace SistemaGestionFerreteria.Repositories.Implementaciones
{
    public class CategoriaRepository(ApplicationDbContext context) : ICategoriaRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Categoria>> ObtenerTodasAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria?> ObtenerPorIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task CrearAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var categoria = await ObtenerPorIdAsync(id);

            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}