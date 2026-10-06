using ProyectTest.Models;

namespace ProyectTest.Services;

public class TareaService : ITareaService
{
    private static readonly List<Tarea> _tareas = new()
    {
        new Tarea { Id = 1, Titulo = "Aprender .NET", Completada = true },
        new Tarea { Id = 2, Titulo = "Crear mi primera API", Completada = false },
        new Tarea { Id = 3, Titulo = "Tomar un café", Completada = false }
    };

    public IEnumerable<Tarea> ObtenerTodas() => _tareas;

    public Tarea? ObtenerPorId(int id) =>
        _tareas.FirstOrDefault(t => t.Id == id);

    public Tarea Crear(string titulo, bool completada)
    {
        var nuevaTarea = new Tarea
        {
            Id = _tareas.Count == 0 ? 1 : _tareas.Max(t => t.Id) + 1,
            Titulo = titulo,
            Completada = completada
        };
        _tareas.Add(nuevaTarea);
        return nuevaTarea;
    }

    public bool Actualizar(int id, string titulo, bool completada)
    {
        var tarea = _tareas.FirstOrDefault(t => t.Id == id);
        if (tarea is null)
            return false;

        tarea.Titulo = titulo;
        tarea.Completada = completada;
        return true;
    }

    public bool Eliminar(int id)
    {
        var tarea = _tareas.FirstOrDefault(t => t.Id == id);
        if (tarea is null)
            return false;

        _tareas.Remove(tarea);
        return true;
    }
}