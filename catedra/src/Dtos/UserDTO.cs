using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catedra.src.Dtos
{
    public class UserDTO
    {
        [Required]
        public int Rut { get; set; }
        
        [Required]
        [MaxLength(100, ErrorMessage = "El nombre debe ser mas corto que 100 caracteres")]
        [MinLength(3, ErrorMessage = "El nombre no puede ser inferior a 3 caracteres")]
        public string nombre { get; set; } = string.Empty;

        [Required]
        public string Correo { get; set; } = string.Empty;
        [Required]
        [RegularExpression("M|F", ErrorMessage = "El genero debe ser M o F")]
        public string Genero { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "La fecha de nacimiento debe estar en formato YYYY-MM-DD.")]
        public string Fecha { get; set; } = string.Empty;
    }
}