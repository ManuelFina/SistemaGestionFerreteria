using Microsoft.AspNetCore.Mvc;
using SistemaGestionFerreteria.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SistemaGestionFerreteria.Data;
using SistemaGestionFerreteria.Models.ViewModels;

namespace SistemaGestionFerreteria.Controllers
{
    public class HomeController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                TotalProductos = await _context.Productos.CountAsync(),

                TotalClientes = await _context.Clientes.CountAsync(),

                TotalVentas = await _context.Ventas.CountAsync(),

                TotalFacturado = await _context.Ventas.SumAsync(v => v.Total),

                ProductosStockBajo = await _context.Productos
                    .CountAsync(p => p.Stock < 10)
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
