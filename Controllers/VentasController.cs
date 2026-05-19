using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaGestionFerreteria.Models.Entities;
using SistemaGestionFerreteria.Models.ViewModels;
using SistemaGestionFerreteria.Repositories.Interfaces;

namespace SistemaGestionFerreteria.Controllers;

[Authorize]
public class VentasController(
    IVentaRepository ventaRepository,
    IClienteRepository clienteRepository,
    IProductoRepository productoRepository) : Controller
{
    public async Task<IActionResult> Index()
    {
        var ventas = await ventaRepository.ObtenerTodasAsync();

        return View(ventas);
    }

    public async Task<IActionResult> Create()
    {
        await CargarCombosAsync();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VentaViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await CargarCombosAsync();

            return View(model);
        }

        var producto = await productoRepository.ObtenerPorIdAsync(model.ProductoId);

        if (producto == null)
        {
            return NotFound();
        }

        var total = producto.Precio * model.Cantidad;

        var venta = new Venta
        {
            ClienteId = model.ClienteId,
            Fecha = DateTime.Now,
            Total = total,
            DetalleVentas =
            [
                new()
                {
                    ProductoId = model.ProductoId,
                    Cantidad = model.Cantidad,
                    PrecioUnitario = producto.Precio
                }
            ]
        };

        await ventaRepository.CrearVentaAsync(venta);

        TempData["success"] = "Venta registrada correctamente";

        return RedirectToAction(nameof(Index));
    }

    private async Task CargarCombosAsync()
    {
        var clientes = await clienteRepository.ObtenerTodosAsync();

        var productos = await productoRepository.ObtenerTodosAsync();

        ViewBag.Clientes = new SelectList(clientes, "Id", "Nombre");

        ViewBag.Productos = new SelectList(productos, "Id", "Nombre");
    }
}