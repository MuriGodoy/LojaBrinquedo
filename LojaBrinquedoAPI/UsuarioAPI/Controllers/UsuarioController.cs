using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.Data.Dtos;
using UsuarioAPI.Services;

namespace UsuarioAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _service;

    public UsuarioController(UsuarioService service)
    {
        _service = service;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="usuarioDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto usuarioDto)
    {
        await _service.Cadastra(usuarioDto);
        return Ok("Usuário criado com sucesso!");
    }
}
