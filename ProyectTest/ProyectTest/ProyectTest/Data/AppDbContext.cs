namespace ProyectTest.Data;
using ProyectTest.Models;
using Microsoft.EntityFrameworkCore;


public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)//Inyeccion de dependen
    {//Recibe la configuración de la base de datos desde Program.cs y la pasa a la clase base DbContext

    }

        public DbSet<Tarea> Tareas { get; set; } = null!; //Nombre de la tabla en la base de datos.
                                                          //El operador null! indica que la propiedad no puede ser nula,
                                                          //pero se inicializa en tiempo de ejecución.


}

