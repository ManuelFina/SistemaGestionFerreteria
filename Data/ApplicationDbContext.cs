using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaGestionFerreteria.Models.Entities;
using SistemaGestionFerreteria.Models.ViewModels;

namespace SistemaGestionFerreteria.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Proveedor> Proveedores { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Venta> Ventas { get; set; }

        public DbSet<DetalleVenta> DetalleVentas { get; set; }

        //stored procedure para obtener el listado de ventas con cliente, fecha y total
        public DbSet<VentaListadoViewModel> VentasListado { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VentaListadoViewModel>()
                .HasNoKey()
                .ToView(null);
        }
    }


}
