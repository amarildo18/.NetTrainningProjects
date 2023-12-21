using Microsoft.EntityFrameworkCore;
using cursoEFCore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cursoEFCore.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.Telefone).HasColumnType("CHAR(11)");
            builder.Property(P => P.Cep).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(P => P.Estado).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(P => P.Cidade).HasMaxLength(60);

            builder.HasIndex(i => i.Telefone).HasName("idx_cliente_telefone");
        }
    }
}