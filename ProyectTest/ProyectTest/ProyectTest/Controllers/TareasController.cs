using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectTest.Models;

namespace ProyectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private static readonly List<Tarea> _tareas = new()
        {
            new Tarea { Id = 1, Titulo = "Aprender .NET", Completada = true },
            new Tarea { Id = 2, Titulo = "Crear mi primera API", Completada = false },
            new Tarea { Id = 3, Titulo = "Tomar un café", Completada = false }
        };


        [HttpGet]
        public IActionResult ObtenerTodas()
        {
            return Ok(_tareas);
        }


        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var tarea = _tareas.FirstOrDefault(t => t.Id == id);

            if (tarea is null)
                return NotFound();

            return Ok(tarea);
        }


        [HttpPost]
        public IActionResult Crear(Tarea nuevaTarea)
        {
            // Calculamos el siguiente id disponible
            nuevaTarea.Id = _tareas.Count == 0 ? 1 : _tareas.Max(t => t.Id) + 1;

            _tareas.Add(nuevaTarea);

            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevaTarea.Id }, nuevaTarea);
        }

        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, Tarea tareaActualizada)
        {
            var tarea = _tareas.FirstOrDefault(t => t.Id == id);

            if (tarea is null)
                return NotFound();

            tarea.Titulo = tareaActualizada.Titulo;
            tarea.Completada = tareaActualizada.Completada;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var tarea = _tareas.FirstOrDefault(t => t.Id == id);

            if (tarea is null)
                return NotFound();

            _tareas.Remove(tarea);

            return NoContent();
        }
    }
}
