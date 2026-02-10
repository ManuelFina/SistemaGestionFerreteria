using System.ComponentModel.DataAnnotations;

namespace SistemaGestionFerreteria.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        //[Required]
        //public string PasswordHash { get; set; }

        [Required]
        public required string Rol { get; set; } // Admin / Empleado

        public bool Activo { get; set; } = true;

        public required ICollection<Venta> Ventas { get; set; }
    }

}
