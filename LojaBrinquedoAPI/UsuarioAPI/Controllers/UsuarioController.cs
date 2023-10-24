using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.Data.Dtos;
using UsuarioAPI.Services;

namespace UsuarioAPI.Controllers;

/// <summary>
/// Controller para gerenciar as funções de usuário
/// </summary>
[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _service;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="service"></param>
    public UsuarioController(UsuarioService service)
    {
        _service = service;
    }

    /// <summary>
    /// Cadastra um usuário no banco de dados
    /// </summary>
    /// <param name="usuarioDto">Objeto com os campos necessários para a criação de usuário
    /// (Email é uma string)</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso o cadastro ocorra de forma correta</response>
    [HttpPost("cadastro")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto usuarioDto)
    {
        await _service.Cadastra(usuarioDto);
        return Ok("Usuário criado com sucesso!");
    }

    /// <summary>
    /// Metodo para logar o usuário
    /// </summary>
    /// <param name="usuarioDto">Objeto com o campo necessário para o login do usuário</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso o cadastro ocorra de forma correta</response>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(LoginUsuarioDto usuarioDto)
    {
        var token = await _service.Login(usuarioDto);
        return Ok(token);
    }
}
