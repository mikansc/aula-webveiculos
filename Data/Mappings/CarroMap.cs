using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebVeiculos.Models;

namespace WebVeiculos.Data;

// Mapeia a tabela e colunas de Carro no banco de dados
public class CarroMap : IEntityTypeConfiguration<Carro>
{
  public void Configure(EntityTypeBuilder<Carro> builder)
  {
    builder.ToTable("Carros");
    builder.HasKey(x => x.Id);
    builder
      .Property(x => x.Id)
      .ValueGeneratedOnAdd()
      .UseIdentityColumn();

    builder.Property(x => x.Marca)
        .IsRequired()
        .HasColumnName("Marca")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80);

    builder.Property(x => x.Modelo)
        .IsRequired()
        .HasColumnName("Modelo")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80);

    builder.Property(x => x.Ano)
        .IsRequired()
        .HasColumnName("Ano")
        .HasColumnType("INT");
    builder.Property(x => x.Cor)
        .IsRequired()
        .HasColumnName("Cor")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80);

    builder.Property(x => x.Placa)
        .IsRequired()
        .HasColumnName("Placa")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80);

    builder.Property(x => x.Combustivel)
        .IsRequired()
        .HasColumnName("Combustivel")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80);

    builder.Property(x => x.QtdPortas)
        .IsRequired()
        .HasColumnName("QtdPortas")
        .HasColumnType("INT");

    builder.Property(x => x.LitragemPortaMalas)
        .IsRequired()
        .HasColumnName("LitragemPortaMalas")
        .HasColumnType("INT");
  }
}