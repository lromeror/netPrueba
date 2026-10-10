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
    public async Task<IActionResult> ObtenerTodas()
    {
        var tareas = await _tareaService.ObtenerTodasAsync();
        return Ok(tareas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var tarea = await _tareaService.ObtenerPorIdAsync(id);

        if (tarea is null)
            return NotFound();

        return Ok(tarea);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CrearTareaDto dto)
    {
        var nuevaTarea = await _tareaService.CrearAsync(dto.Titulo, dto.Completada);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevaTarea.Id }, nuevaTarea);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, ActualizarTareaDto dto)
    {
        var exito = await _tareaService.ActualizarAsync(id, dto.Titulo, dto.Completada);

        if (!exito)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var exito = await _tareaService.EliminarAsync(id);

        if (!exito)
            return NotFound();

        return NoContent();
    }
}