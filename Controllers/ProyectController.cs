using Microsoft.AspNetCore.Mvc;
using TechOil.Models;

namespace TechOil.Controllers
{
    [Route("api/proyects")]
    [ApiController]
    public class ProyectController : ControllerBase
    {

        private List<Proyect> proyectos = new List<Proyect>
        {
            new Proyect { Id = 1, Nombre = "Proyecto 1", Direccion = "Dirección 1", Estado = 1 },          
            new Proyect { Id = 2, Nombre = "Proyecto 2", Direccion = "Dirección 2", Estado = 2 },
            new Proyect { Id = 3, Nombre = "Proyecto 3", Direccion = "Dirección 3", Estado = 3 }
           
        };

        // Obtener todos los proyectos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(proyectos);
        }

        // Obtener proyecto por ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Proyect proyecto = proyectos.FirstOrDefault(p => p.Id == id);
            if (proyecto == null)
            {
                return NotFound("Proyecto no encontrado");
            }
            return Ok(proyecto);
        }
        // Crea un nuevo proyecto
        [HttpPost]
        public IActionResult Post([FromBody] Proyect proyecto)
        {
            if (proyecto == null)
            {
                return BadRequest("Datos de proyecto no válidos");
            }

            proyecto.Id = proyectos.Max(p => p.Id) + 1;
            proyectos.Add(proyecto);

            return CreatedAtAction("Get", new { id = proyecto.Id }, proyecto);
        }

        //Actualizar Proyecto por Id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Proyect updatedProyecto)
        {
            Proyect proyecto = proyectos.FirstOrDefault(p => p.Id == id);
            if (proyecto == null)
            {
                return NotFound("Proyecto no encontrado");
            }

            if (updatedProyecto == null)
            {
                return BadRequest("Datos de proyecto no válidos");
            }

            // Realiza la actualización de los campos del proyecto
            proyecto.Nombre = updatedProyecto.Nombre;
            proyecto.Direccion = updatedProyecto.Direccion;
            proyecto.Estado = updatedProyecto.Estado;

            return Ok(proyecto);
        }

        // Elimina proyecto por ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Proyect proyecto = proyectos.FirstOrDefault(p => p.Id == id);
            if (proyecto == null)
            {
                return NotFound("Proyecto no encontrado");
            }

            proyectos.Remove(proyecto);
            return NoContent();
        }
    }
}
