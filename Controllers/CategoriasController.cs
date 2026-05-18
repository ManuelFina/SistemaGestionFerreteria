using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionFerreteria.Models.Entities;
using SistemaGestionFerreteria.Repositories.Interfaces;

namespace SistemaGestionFerreteria.Controllers
{
    [Authorize]
    public class CategoriasController(ICategoriaRepository categoriaRepository) : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository = categoriaRepository;

        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaRepository.ObtenerTodasAsync();

            return View(categorias);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return View(categoria);
            }

            await _categoriaRepository.CrearAsync(categoria);

            TempData["success"] = "Categoria creada correctamente";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _categoriaRepository.ObtenerPorIdAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return View(categoria);
            }

            await _categoriaRepository.ActualizarAsync(categoria);

            TempData["success"] = "Categoria actualizada correctamente";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaRepository.ObtenerPorIdAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriaRepository.EliminarAsync(id);

            TempData["success"] = "Categoria eliminada correctamente";

            return RedirectToAction(nameof(Index));
        }
    }
}