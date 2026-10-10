using ProyectTest.Models;

namespace ProyectTest.Services;

public interface ITareaService
{
    //Devuelve todas como interface de tarea
    // Devolvemos promises de tareas, ya que es asincrónico
    Task<IEnumerable<Tarea>> ObtenerTodasAsync();
    Task<Tarea?> ObtenerPorIdAsync(int id);
    Task<Tarea> CrearAsync(string titulo, bool completada);
    Task<bool> ActualizarAsync(int id, string titulo, bool completada);
    Task<bool> EliminarAsync(int id);
}