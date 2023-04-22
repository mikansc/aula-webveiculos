using Microsoft.EntityFrameworkCore;
using WebVeiculos.Models;

namespace WebVeiculos.Data
{
  public class WebVeiculosContext : DbContext // Extender DbContext
  {

    public WebVeiculosContext(DbContextOptions<WebVeiculosContext> options) : base(options)
    {
    }
    
    // DbSet -> Representa uma tabela do banco de dados
    public DbSet<Carro> Carros { get; set; }
    public DbSet<Onibus> Onibus { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new CarroMap());
      modelBuilder.ApplyConfiguration(new OnibusMap());
    }
  }
}
