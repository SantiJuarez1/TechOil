using Microsoft.AspNetCore.Mvc;
using TechOil.Models;

namespace TechOil.Controllers
{
    [Route("api/work")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private List<Work> works = new List<Work>
        {
            new Work
            {
                IdTrabajo = 1,
                Fecha = "2023-10-28",
                IdProyecto = 1,
                IdServicio = 1,
                CantHoras = 5,
                ValorHora = 50.0M
            },
            new Work
            {
                IdTrabajo = 2,
                Fecha = "2023-10-29",
                IdProyecto = 2,
                IdServicio = 2,
                CantHoras = 7,
                ValorHora = 60.0M
            }           
        };

        // Obtener todos los trabajos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(works);
        }

        // obtener trabajo por ID
        [HttpGet("{idTrabajo}")]
        public IActionResult Get(int idTrabajo)
        {
            Work work = works.FirstOrDefault(w => w.IdTrabajo == idTrabajo);
            if (work == null)
            {
                return NotFound("Trabajo no encontrado");
            }
            return Ok(work);
        }

        // Crear nuevo trabajo
        [HttpPost]
        public IActionResult Post([FromBody] Work work)
        {
            if (work == null)
            {
                return BadRequest("Datos de trabajo no válidos");
            }

            work.IdTrabajo = works.Max(w => w.IdTrabajo) + 1;
            work.Costo = work.CantHoras * work.ValorHora; // Calcular el costo

            works.Add(work);

            return CreatedAtAction("Get", new { idTrabajo = work.IdTrabajo }, work);
        }

        // Actualizar Trabajo por Id
        [HttpPut("{idTrabajo}")]
        public IActionResult Put(int idTrabajo, [FromBody] Work updatedWork)
        {
            Work work = works.FirstOrDefault(w => w.IdTrabajo == idTrabajo);
            if (work == null)
            {
                return NotFound("Trabajo no encontrado");
            }

            if (updatedWork == null)
            {
                return BadRequest("Datos de trabajo no válidos");
            }

            work.Fecha = updatedWork.Fecha;
            work.IdProyecto = updatedWork.IdProyecto;
            work.IdServicio = updatedWork.IdServicio;
            work.CantHoras = updatedWork.CantHoras;
            work.ValorHora = updatedWork.ValorHora;
            work.Costo = work.CantHoras * work.ValorHora; // Recalcular el costo

            return Ok(work);
        }

        // Eliminar trabajo por su ID
        [HttpDelete("{idTrabajo}")]
        public IActionResult Delete(int idTrabajo)
        {
            Work work = works.FirstOrDefault(w => w.IdTrabajo == idTrabajo);
            if (work == null)
            {
                return NotFound("Trabajo no encontrado");
            }

            works.Remove(work);
            return NoContent();
        }
    }
}
