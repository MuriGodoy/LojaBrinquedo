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
           
        }

        public DbSet<Produto> Produtos { get; set; }
}