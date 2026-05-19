using Microsoft.AspNetCore.Mvc;
using SistemaGestionFerreteria.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SistemaGestionFerreteria.Data;
using SistemaGestionFerreteria.Models.ViewModels;
using System.Globalization;

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

            var ventasAgrupadas = await _context.Ventas
    .GroupBy(v => v.Fecha.Month)
    .Select(g => new
    {
        Mes = g.Key,
        Total = g.Sum(v => v.Total)
    })
    .OrderBy(x => x.Mes)
    .ToListAsync();

            model.Meses = ventasAgrupadas
                .Select(v => CultureInfo.CurrentCulture
                .DateTimeFormat
                .GetMonthName(v.Mes))
                .ToList();

            model.VentasPorMes = ventasAgrupadas
                .Select(v => v.Total)
                .ToList();

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
