using LojaBrinquedoAPI.Data;
using LojaBrinquedoAPI.Models;

namespace LojaBrinquedoAPI.Services
{
    public class ProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

       public List<Produto> RecuperaProdutos()
       {
            var produto = _context.Produtos.ToList();
            return produto;
       }

        public List<Produto> RecuperaProdutoPorID(int id)
        {
            var produto = _context.Produtos.Where(produto => produto.Id == id).ToList();
            return produto;
        }
    }
}
