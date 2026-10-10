using ProyectTest.Data;
using ProyectTest.Models;
using Microsoft.EntityFrameworkCore;
namespace ProyectTest.Services;

public class TareaService : ITareaService   
{

    private readonly AppDbContext _context;

    // El DbContext llega por inyección de dependencias
    public TareaService(AppDbContext context)
    {
        _context = context;
    }

    /*
    private static readonly List<Tarea> _tareas = new()
    {
        new Tarea { Id = 1, Titulo = "Aprender .NET", Completada = true },
        new Tarea { Id = 2, Titulo = "Crear mi primera API", Completada = false },
        new Tarea { Id = 3, Titulo = "Tomar un café", Completada = false }
    };
    */

    public async Task<IEnumerable<Tarea>> ObtenerTodasAsync()// Método asincrónico para obtener todas las tareas
    {
        return await _context.Tareas.ToListAsync(); // Retorna todas las tareas desde la base de datos
    }

    public async Task<Tarea?> ObtenerPorIdAsync(int id) {
        return await _context.Tareas.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Tarea> CrearAsync(string titulo, bool completada)
    {
        var nuevaTarea = new Tarea
        {
            Titulo = titulo,
            Completada = completada
        };
        _context.Tareas.Add(nuevaTarea);
        await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
        return nuevaTarea;
    }

    public async Task<bool> ActualizarAsync(int id, string titulo, bool completada)
    {
        var tarea = await _context.Tareas.FirstOrDefaultAsync(t => t.Id == id);
        if (tarea is null)
            return false;

        tarea.Titulo = titulo;
        tarea.Completada = completada;

        await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
        return true;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var tarea = await _context.Tareas.FirstOrDefaultAsync(t => t.Id == id);
        if (tarea is null)
            return false;

        _context.Tareas.Remove(tarea);
        await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
        return true;
    }
}