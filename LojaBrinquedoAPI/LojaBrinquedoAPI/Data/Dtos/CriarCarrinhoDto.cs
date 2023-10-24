using System.ComponentModel.DataAnnotations;

namespace LojaBrinquedoAPI.Data.Dtos
{
    public class CriarCarrinhoDto
    {
        public int? Quantidade { get; set; }
        public int? ProdutoId { get; set; }
        public object? Produto { get; set; }
    }
}
