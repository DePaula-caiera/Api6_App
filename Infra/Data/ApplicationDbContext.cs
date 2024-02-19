using Flunt.Notifications;
using IWantApp.Domain.Produtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Infra.Data;
public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Produto>? Produtos { get; set; }
    public DbSet<Categoria>? Categorias { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Ignore<Notification>();

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


