using System.ComponentModel.DataAnnotations;

namespace ProyectTest.DTOs;

public class RegistroDto
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string NombreUsuario { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;
}