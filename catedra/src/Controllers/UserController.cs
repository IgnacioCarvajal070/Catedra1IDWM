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
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetAllUsers();

            if (users == null || !users.Any())
            {
                return NotFound(new { message = "No se encontraron usuarios." });
            }

            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userSearch = await _userRepository.GetUserById(id);
            if (userSearch == null)
            {
                return NotFound(new { message = "Usuario no encontrado." });
            }

            
            if (_context.Users.Any(u => u.Rut == userDto.Rut && u.Id != id))
            {
                return Conflict(new { message = "El RUT ya existe para otro usuario." });
            }

            if (!DateTime.TryParse(userDto.Fecha, out DateTime FechaPars) || FechaPars >= DateTime.Now)
            {
                return BadRequest(new { message = "La fecha de nacimiento debe ser válida y menor a la fecha actual." });
            }
            userSearch.Rut = userDto.Rut;
            userSearch.Nombre = userDto.Nombre;
            userSearch.Correo = userDto.Correo;
            userSearch.Genero = userDto.Genero;
            userSearch.Fecha = userDto.Fecha;

            await _userRepository.UpdateUser(userSearch);
            return Ok(new { message = "Usuario actualizado exitosamente." });
            }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound(new { message = "Usuario no encontrado." });
            }

            await _userRepository.DeleteUser(user);
            return Ok(new { message = "Usuario eliminado exitosamente." });
        }
    }
}