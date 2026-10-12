using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectTest.Data;
using ProyectTest.DTOs;
using ProyectTest.Models;

namespace ProyectTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("registro")]
    public async Task<IActionResult> Registrar(RegistroDto dto)
    {
        var yaExiste = await _context.Usuarios.AnyAsync(u => u.NombreUsuario == dto.NombreUsuario);

        if (yaExiste)
            return BadRequest("El nombre de usuario ya está en uso.");

        var usuario = new Usuario
        {
            NombreUsuario = dto.NombreUsuario,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return Ok("Usuario registrado correctamente.");
    }
}