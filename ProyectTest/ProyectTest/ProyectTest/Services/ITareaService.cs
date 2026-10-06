using ProyectTest.Models;

namespace ProyectTest.Services;

public interface ITareaService
{
    IEnumerable<Tarea> ObtenerTodas();
    Tarea? ObtenerPorId(int id); 
    Tarea Crear(string titulo, bool completada);
    bool Actualizar(int id, string titulo, bool completada);
    bool Eliminar(int id);
}