using Microsoft.AspNetCore.Mvc;
using ProyectTest.DTOs;
using ProyectTest.Services;

namespace ProyectTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareasController : ControllerBase
{
    private readonly ITareaService _tareaService;

    // El servicio llega por el constructor (inyección de dependencias)
    public TareasController(ITareaService tareaService)
    {
        _tareaService = tareaService;
    }

    [HttpGet]
    public IActionResult ObtenerTodas()
    {
        return Ok(_tareaService.ObtenerTodas());
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        var tarea = _tareaService.ObtenerPorId(id);

        if (tarea is null)
            return NotFound();

        return Ok(tarea);
    }

    [HttpPost]
    public IActionResult Crear(CrearTareaDto dto)
    {
        var nuevaTarea = _tareaService.Crear(dto.Titulo, dto.Completada);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevaTarea.Id }, nuevaTarea);
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, ActualizarTareaDto dto)
    {
        var exito = _tareaService.Actualizar(id, dto.Titulo, dto.Completada);

        if (!exito)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        var exito = _tareaService.Eliminar(id);

        if (!exito)
            return NotFound();

        return NoContent();
    }
}