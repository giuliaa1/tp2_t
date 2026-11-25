using LocadoraVeiculos.Api.Models;
using Microsoft.EntityFrameworkCore;
namespace LocadoraVeiculos.Api.Data;
public class LocadoraContext : DbContext {
 public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options) { }
 public DbSet<Fabricante> Fabricantes => Set<Fabricante>();
 public DbSet<Categoria> Categorias => Set<Categoria>();
 public DbSet<Veiculo> Veiculos => Set<Veiculo>();
 public DbSet<Cliente> Clientes => Set<Cliente>();
 public DbSet<Aluguel> Alugueis => Set<Aluguel>();
 protected override void OnModelCreating(ModelBuilder b) {
  b.Entity<Veiculo>().HasIndex(x=>x.Placa).IsUnique();
  b.Entity<Cliente>().HasIndex(x=>x.Cpf).IsUnique();
  b.Entity<Cliente>().HasIndex(x=>x.Email).IsUnique();
  b.Entity<Veiculo>().HasOne(x=>x.Fabricante).WithMany(x=>x.Veiculos).HasForeignKey(x=>x.FabricanteId).OnDelete(DeleteBehavior.Restrict);
  b.Entity<Veiculo>().HasOne(x=>x.Categoria).WithMany(x=>x.Veiculos).HasForeignKey(x=>x.CategoriaId).OnDelete(DeleteBehavior.Restrict);
  b.Entity<Aluguel>().HasOne(x=>x.Cliente).WithMany(x=>x.Alugueis).HasForeignKey(x=>x.ClienteId).OnDelete(DeleteBehavior.Restrict);
  b.Entity<Aluguel>().HasOne(x=>x.Veiculo).WithMany(x=>x.Alugueis).HasForeignKey(x=>x.VeiculoId).OnDelete(DeleteBehavior.Restrict);
  b.Entity<Categoria>().Property(x=>x.ValorDiariaSugerido).HasPrecision(10,2);
  b.Entity<Aluguel>().Property(x=>x.ValorDiaria).HasPrecision(10,2);
  b.Entity<Aluguel>().Property(x=>x.ValorTotal).HasPrecision(12,2);
 }
}
