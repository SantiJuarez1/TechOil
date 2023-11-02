using Microsoft.AspNetCore.Mvc;
using TechOil.Models;

namespace TechOil.Controllers
{
    [Route("api/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private List<Service> services = new List<Service>
        {
            new Service { Id = 1, Descripcion = "Servicio 1", Estado = 1, valorHora = 50.0M },
            new Service { Id = 2, Descripcion = "Servicio 2", Estado = 2, valorHora = 60.0M }
            // Agrega más servicios según tus necesidades
        };

        // Obtener todos los servicios
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(services);
        }

        // Obtener servicio por ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Service service = services.FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                return NotFound("Servicio no encontrado");
            }
            return Ok(service);
        }

        // Crear un nuevo servicio
        [HttpPost]
        public IActionResult Post([FromBody] Service service)
        {
            if (service == null)
            {
                return BadRequest("Datos de servicio no válidos");
            }

            service.Id = services.Max(s => s.Id) + 1;
            services.Add(service);

            return CreatedAtAction("Get", new { id = service.Id }, service);
        }

        //Actualizar servicio por Id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Service updatedService)
        {
            Service service = services.FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                return NotFound("Servicio no encontrado");
            }

            if (updatedService == null)
            {
                return BadRequest("Datos de servicio no válidos");
            }

            service.Descripcion = updatedService.Descripcion;
            service.Estado = updatedService.Estado;
            service.valorHora = updatedService.valorHora;

            return Ok(service);
        }

        // Eliminar servicio por ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Service service = services.FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                return NotFound("Servicio no encontrado");
            }

            services.Remove(service);
            return NoContent();
        }
    }
}
