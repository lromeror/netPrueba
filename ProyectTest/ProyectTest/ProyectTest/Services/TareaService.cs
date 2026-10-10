using ProyectTest.Data;
using ProyectTest.Models;

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
    public IEnumerable<Tarea> ObtenerTodas()
    {
        return _context.Tareas.ToList(); //Retorna todas las tareas desde la base de datos
    }

    public Tarea? ObtenerPorId(int id) {
        return _context.Tareas.FirstOrDefault(t => t.Id == id);
    }

    public Tarea Crear(string titulo, bool completada)
    {
        var nuevaTarea = new Tarea
        {
            Titulo = titulo,
            Completada = completada
        };
        _context.Tareas.Add(nuevaTarea);
        _context.SaveChanges(); // Guarda los cambios en la base de datos
        return nuevaTarea;
    }

    public bool Actualizar(int id, string titulo, bool completada)
    {
        var tarea = _context.Tareas.FirstOrDefault(t => t.Id == id);
        if (tarea is null)
            return false;

        tarea.Titulo = titulo;
        tarea.Completada = completada;

        _context.SaveChanges(); // Guarda los cambios en la base de datos
        return true;
    }

    public bool Eliminar(int id)
    {
        var tarea = _context.Tareas.FirstOrDefault(t => t.Id == id);
        if (tarea is null)
            return false;

        _context.Tareas.Remove(tarea);
        _context.SaveChanges(); // Guarda los cambios en la base de datos
        return true;
    }
}