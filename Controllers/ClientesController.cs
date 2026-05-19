using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionFerreteria.Models.Entities;
using SistemaGestionFerreteria.Repositories.Interfaces;

namespace SistemaGestionFerreteria.Controllers;

[Authorize]
public class ClientesController(IClienteRepository clienteRepository) : Controller
{
    public async Task<IActionResult> Index()
    {
        var clientes = await clienteRepository.ObtenerTodosAsync();

        return View(clientes);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Cliente cliente)
    {
        if (!ModelState.IsValid)
        {
            return View(cliente);
        }

        await clienteRepository.CrearAsync(cliente);

        TempData["success"] = "Cliente creado correctamente";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var cliente = await clienteRepository.ObtenerPorIdAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Cliente cliente)
    {
        if (!ModelState.IsValid)
        {
            return View(cliente);
        }

        await clienteRepository.ActualizarAsync(cliente);

        TempData["success"] = "Cliente actualizado correctamente";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await clienteRepository.ObtenerPorIdAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await clienteRepository.EliminarAsync(id);

        TempData["success"] = "Cliente eliminado correctamente";

        return RedirectToAction(nameof(Index));
    }
}