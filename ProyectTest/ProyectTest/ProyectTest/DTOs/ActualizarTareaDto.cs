using System.ComponentModel.DataAnnotations;

namespace ProyectTest.DTOs;

public class ActualizarTareaDto
{
    [Required(ErrorMessage = "El título es obligatorio.")]
    [StringLength(100, MinimumLength = 3,
        ErrorMessage = "El título debe tener entre 3 y 100 caracteres.")]
    public string Titulo { get; set; } = string.Empty;

    public bool Completada { get; set; }
}