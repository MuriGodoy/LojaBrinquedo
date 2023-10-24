using LojaBrinquedoAPI.Models;
using LojaBrinquedoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LojaBrinquedoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly ProdutoService _service;

    public ProdutoController(ProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public List<Produto> RecuperaProdutos()
    {
        var produto = _service.RecuperaProdutos();
        return produto;
    }
}
