using CargoManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoManagement.Api.Data;

public class CargoDbContext : DbContext
{
    public CargoDbContext(DbContextOptions<CargoDbContext> options) : base(options) { }

    public DbSet<Cargo> Cargos => Set<Cargo>();
    public DbSet<Container> Containers => Set<Container>();
    public DbSet<Manifest> Manifests => Set<Manifest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.ToTable("cargos");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Numero).HasColumnName("numero").HasMaxLength(50).IsRequired();
            entity.Property(e => e.Tipo).HasColumnName("tipo").HasMaxLength(30).IsRequired();
            entity.Property(e => e.Peso).HasColumnName("peso").HasColumnType("decimal(10,2)");
            entity.Property(e => e.Origem).HasColumnName("origem").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Destino).HasColumnName("destino").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Status).HasColumnName("status").HasMaxLength(20).IsRequired();
            entity.Property(e => e.DataRegistro).HasColumnName("data_registro");
        });

        modelBuilder.Entity<Container>(entity =>
        {
            entity.ToTable("containers");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo).HasColumnName("codigo").HasMaxLength(20).IsRequired();
            entity.Property(e => e.CargoId).HasColumnName("cargo_id");
            entity.Property(e => e.Tamanho).HasColumnName("tamanho").HasMaxLength(10).IsRequired();
            entity.Property(e => e.Conteudo).HasColumnName("conteudo").HasMaxLength(200).IsRequired();
            entity.Property(e => e.Lacrado).HasColumnName("lacrado");

            entity.HasOne(e => e.Cargo)
                  .WithMany(c => c.Containers)
                  .HasForeignKey(e => e.CargoId);
        });

        modelBuilder.Entity<Manifest>(entity =>
        {
            entity.ToTable("manifests");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CargoId).HasColumnName("cargo_id");
            entity.Property(e => e.Numero).HasColumnName("numero").HasMaxLength(50).IsRequired();
            entity.Property(e => e.DataEmissao).HasColumnName("data_emissao");
            entity.Property(e => e.Despachante).HasColumnName("despachante").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Observacoes).HasColumnName("observacoes").HasMaxLength(500);

            entity.HasOne(e => e.Cargo)
                  .WithMany(c => c.Manifests)
                  .HasForeignKey(e => e.CargoId);
        });
    }
}
