using LojaBrinquedoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaBrinquedoAPI.Data;

public class AppDbContext : DbContext
{
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.Entity<ProdutoCarrinho>()
                .HasKey(x => new { x.ProdutoId, x.CarrinhoId });

        builder.Entity<ProdutoCarrinho>()
            .HasOne(p => p.Produto)
            .WithMany(p => p.ProdutosCarrinhos)
            .HasForeignKey(p => p.ProdutoId);

        builder.Entity<ProdutoCarrinho>()
            .HasOne(c => c.Carrinho)
            .WithMany(c => c.ProdutosCarrinhos)
            .HasForeignKey(c => c.CarrinhoId);

        builder.Entity<ProdutoCarrinho>()
            .HasKey(pc => new { pc.ProdutoId, pc.CarrinhoId });

        builder.Entity<ProdutoCarrinho>()
            .HasOne(pc => pc.Carrinho)
            .WithMany(carrinho => carrinho.ProdutosCarrinhos)
            .HasForeignKey(pc => pc.CarrinhoId);

        builder.Entity<ProdutoCarrinho>()
            .HasOne(pc => pc.Produto)
            .WithMany(produto => produto.ProdutosCarrinhos)
            .HasForeignKey(pc => pc.ProdutoId);
    }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CarrinhoDeCompra> CarrinhoDeCompras { get; set; }
        public DbSet<ProdutoCarrinho> ProdutoCarrinhos { get; set; }
    }