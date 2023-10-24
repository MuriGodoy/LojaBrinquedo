using LojaBrinquedoAPI.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LojaBrinquedoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrinhoController : ControllerBase
    {

        //[HttpPost]
        //public IActionResult CriarCarrinho([FromQuery] CriarCarrinhoDto carrinhoDto)
        //{
        //    //var criar = _carrinhoService.CriarCarrinho(carrinhoDto);
        //    //if (criar.Result.IsFailed)
        //    //{
        //    //    return BadRequest(criar.Result.Errors);
        //    //}
        //    //return Ok(carrinhoDto);
        //}
    }
}
