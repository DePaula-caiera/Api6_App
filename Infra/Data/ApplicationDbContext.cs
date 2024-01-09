using IWantApp.Domain.Produtos;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Infra.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<Produto>? Produtos { get; set; }
    public DbSet<Categoria>? Categorias { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Produto>()
            .Property(p => p.Nome).IsRequired();
        builder.Entity<Produto>()
            .Property(p => p.Descricao).HasMaxLength(255);

        builder.Entity<Categoria>()
            .Property(c => c.Nome).IsRequired();
        builder.Entity<Categoria>()
            .ToTable("Categorias");
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(100);
    }
}


