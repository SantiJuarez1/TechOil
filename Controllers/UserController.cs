using Microsoft.AspNetCore.Mvc;
using TechOil.Models;
using System.Runtime.ConstrainedExecution;
using TechOil.Models.DTOs;

namespace TechOil.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private List<User> users = new List<User>
        {
            new User { Id = 1, Nombre = "Usuario 1", Dni = 12345, Categoria = 1 },
            new User { Id = 2, Nombre = "Usuario 2", Dni = 67890, Categoria = 2 }
        };

        // Obtener todos los usuarios
        [HttpGet]
        public IActionResult Get()
        {
            List<UserDTO> userDTOs = users.Select(u => new UserDTO
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Dni = u.Dni,
                Categoria = u.Categoria
            }).ToList();

            return Ok(userDTOs);
        }

        // Obtener usuario por ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound("Usuario no encontrado");
            }

            UserDTO userDTO = new UserDTO
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Dni = user.Dni,
                Categoria = user.Categoria
            };

            return Ok(userDTO);
        }

        // Crear nuevo usuario
        [HttpPost]
        public IActionResult Post([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("Datos de usuario no válidos");
            }

            User newUser = new User
            {
                Id = users.Max(u => u.Id) + 1,
                Nombre = userDTO.Nombre,
                Dni = userDTO.Dni,
                Categoria = userDTO.Categoria
            };

            users.Add(newUser);

            return CreatedAtAction("Get", new { id = newUser.Id }, newUser);
        }

        //Actualizar usuario por Id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDTO updatedUserDTO)
        {
            User user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound("Usuario no encontrado");
            }

            if (updatedUserDTO == null)
            {
                return BadRequest("Datos de usuario no válidos");
            }

            user.Nombre = updatedUserDTO.Nombre;
            user.Dni = updatedUserDTO.Dni;
            user.Categoria = updatedUserDTO.Categoria;

            return Ok(user);
        }

        // Eliminar un usuario por su ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound("Usuario no encontrado");
            }

            users.Remove(user);
            return NoContent();
        }
    }
}
