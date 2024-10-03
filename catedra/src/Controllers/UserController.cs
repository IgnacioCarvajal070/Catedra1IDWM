using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra.src.Data;
using Microsoft.AspNetCore.Mvc;
using catedra.src.Dtos;
using catedra.src.Models;
namespace catedra.src.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController: ControllerBase
    {
        private readonly ApplicationDBContext _context;   
        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            if (_context.Users.Any(u => u.Rut == createUserDto.Rut))
            {
            return Conflict(new { message = "El RUT ya existe." });
            }
            if (!DateTime.TryParse(createUserDto.Fecha, out DateTime FechaPars) || FechaPars >= DateTime.Now)
            {
            return BadRequest(new { message = "La fecha de nacimiento debe ser válida y menor a la fecha actual." });
            }
        
            var user = new User
            {
            Rut = createUserDto.Rut,
            Nombre = createUserDto.nombre,
            Correo = createUserDto.Correo,
            Genero = createUserDto.Genero,
            Fecha = FechaPars.ToString("yyyy-MM-dd")
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            
            return CreatedAtAction(nameof(CreateUser), "Usuario creado exitosamente");
        }
    }
}