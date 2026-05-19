using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionFerreteria.Models.Entities;
using SistemaGestionFerreteria.Repositories.Interfaces;

namespace SistemaGestionFerreteria.Controllers;

[Authorize]
public class ProveedoresController(IProveedorRepository proveedorRepository) : Controller
{
    public async Task<IActionResult> Index()
    {
        var proveedores = await proveedorRepository.ObtenerTodosAsync();

        return View(proveedores);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Proveedor proveedor)
    {
        if (!ModelState.IsValid)
        {
            return View(proveedor);
        }

        await proveedorRepository.CrearAsync(proveedor);

        TempData["success"] = "Proveedor creado correctamente";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var proveedor = await proveedorRepository.ObtenerPorIdAsync(id);

        if (proveedor == null)
        {
            return NotFound();
        }

        return View(proveedor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Proveedor proveedor)
    {
        if (!ModelState.IsValid)
        {
            return View(proveedor);
        }

        await proveedorRepository.ActualizarAsync(proveedor);

        TempData["success"] = "Proveedor actualizado correctamente";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var proveedor = await proveedorRepository.ObtenerPorIdAsync(id);

        if (proveedor == null)
        {
            return NotFound();
        }

        return View(proveedor);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await proveedorRepository.EliminarAsync(id);

        TempData["success"] = "Proveedor eliminado correctamente";

        return RedirectToAction(nameof(Index));
    }
}