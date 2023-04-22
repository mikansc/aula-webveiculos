using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebVeiculos.Models;

namespace WebVeiculos.Data;

// Mapeia a tabela e colunas de Onibus no banco de dados
public class OnibusMap : IEntityTypeConfiguration<Onibus>
{
  public void Configure(EntityTypeBuilder<Onibus> builder)
  {
    builder.ToTable("Onibus");
    builder.HasKey(x => x.Id);
    builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

    builder.Property(x => x.Placa)
        .IsRequired()
        .HasColumnName("Placa")
        .HasColumnType("VARCHAR")
        .HasMaxLength(8);

    builder.Property(x => x.Modelo)
        .IsRequired()
        .HasColumnName("Modelo")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80);

    builder.Property(x => x.Marca)
        .IsRequired()
        .HasColumnName("Marca")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80);

    builder.Property(x => x.Ano)
      .IsRequired()
      .HasColumnName("Ano")
      .HasColumnType("INT");

    builder.Property(x => x.QtdAssentos)
          .IsRequired()
          .HasColumnName("QtdAssentos")
          .HasColumnType("INT");

    builder.Property(x => x.PossuiBanheiro)
          .IsRequired()
          .HasColumnName("PossuiBanheiro")
          .HasColumnType("BIT");

    builder.Property(x => x.PossuiWifi)
          .IsRequired()
          .HasColumnName("PossuiWifi")
          .HasColumnType("BIT");

    builder.Property(x => x.PossuiTomada)
          .IsRequired()
          .HasColumnName("PossuiTomada")
          .HasColumnType("BIT");

    builder.Property(x => x.PossuiTv)
          .IsRequired()
          .HasColumnName("PossuiTv")
          .HasColumnType("BIT");
  }
}