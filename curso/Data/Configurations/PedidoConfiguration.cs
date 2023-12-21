using Microsoft.EntityFrameworkCore;
using cursoEFCore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cursoEFCore.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IniciadoEm).HasDefaultValueSql("getdate()").ValueGeneratedOnAdd();
            builder.Property(p => p.Status).HasConversion<string>();
            builder.Property(p => p.TipoFrete).HasConversion<int>();
            builder.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");

            builder.HasMany(p => p.Itens)
                 .WithOne(p => p.Pedido)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}