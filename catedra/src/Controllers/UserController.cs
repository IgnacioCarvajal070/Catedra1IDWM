using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra.src.Data;
using Microsoft.AspNetCore.Mvc;
using catedra.src.Dtos;
using catedra.src.Models;
using catedra.src.Interfaces;
namespace catedra.src.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController: ControllerBase
    {
        private readonly ApplicationDBContext _context;   
        private readonly IUserRepository _userRepository;

        public UserController(ApplicationDBContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            if (_context.Users.Any(u => u.Rut == userDto.Rut))
            {
            return Conflict(new { message = "El RUT ya existe." });
            }
            if (!DateTime.TryParse(userDto.Fecha, out DateTime FechaPars) || FechaPars >= DateTime.Now)
            {
            return BadRequest(new { message = "La fecha de nacimiento debe ser válida y menor a la fecha actual." });
            }
        
            var user = new User
            {
                Rut = userDto.Rut,
                Nombre = userDto.Nombre,
                Correo = userDto.Correo,
                Genero = userDto.Genero,
                Fecha = userDto.Fecha
            };
            await _userRepository.CreateUser(user);
            return CreatedAtAction(nameof(CreateUser), "Usuario creado exitosamente");
        }
    }
}