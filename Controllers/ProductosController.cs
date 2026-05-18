using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaGestionFerreteria.Models.Entities;
using SistemaGestionFerreteria.Repositories.Interfaces;

namespace SistemaGestionFerreteria.Controllers;

[Authorize]
public class ProductosController(
    IProductoRepository productoRepository,
    ICategoriaRepository categoriaRepository,
    IProveedorRepository proveedorRepository) : Controller
{
    public async Task<IActionResult> Index()
    {
        var productos = await productoRepository.ObtenerTodosAsync();

        return View(productos);
    }

    public async Task<IActionResult> Create()
    {
        await CargarCombosAsync();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Producto producto)
    {
        if (!ModelState.IsValid)
        {
            await CargarCombosAsync();

            return View(producto);
        }

        await productoRepository.CrearAsync(producto);

        TempData["success"] = "Producto creado correctamente";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var producto = await productoRepository.ObtenerPorIdAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        await CargarCombosAsync();

        return View(producto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Producto producto)
    {
        if (!ModelState.IsValid)
        {
            await CargarCombosAsync();

            return View(producto);
        }

        await productoRepository.ActualizarAsync(producto);

        TempData["success"] = "Producto actualizado correctamente";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var producto = await productoRepository.ObtenerPorIdAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await productoRepository.EliminarAsync(id);

        TempData["success"] = "Producto eliminado correctamente";

        return RedirectToAction(nameof(Index));
    }

    private async Task CargarCombosAsync()
    {
        var categorias = await categoriaRepository.ObtenerTodasAsync();

        var proveedores = await proveedorRepository.ObtenerTodosAsync();

        ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre");

        ViewBag.Proveedores = new SelectList(proveedores, "Id", "Nombre");
    }
}