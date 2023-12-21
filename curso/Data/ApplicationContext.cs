using cursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using cursoEFCore.Data.Configurations;
using Microsoft.Extensions.Logging;

namespace cursoEFCore.Data
{
    public class ApplicationContext: DbContext
    {
        public static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());
        public DbSet<Pedido> Pedidos{get; set;}
        public DbSet<Produto> Produtos{get; set; }
        public DbSet<Cliente> Clientes{get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging()
                .UseSqlServer("Data source=(localdb)\\mssqllocaldb;Initial catalog=CursoEFCore;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            /*
            modelBuilder.Entity<Cliente>(p => {
                p.ToTable("Clientes");
                p.HasKey(p => p.Id);
                p.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();
                p.Property(p => p.Telefone).HasColumnType("CHAR(11)");
                p.Property(P => P.Cep).HasColumnType("CHAR(8)").IsRequired();
                p.Property(P => P.Estado).HasColumnType("CHAR(2)").IsRequired();
                p.Property(P => P.Cidade).HasMaxLength(60);

                p.HasIndex(i => i.Telefone).HasName("idx_cliente_telefone");
            });

            modelBuilder.Entity<Produto>(p => {
                p.ToTable("Produtos");
                p.HasKey(p => p.Id);
                p.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
                p.Property(p => p.Descricao).HasColumnType("VARCHAR(60)");
                p.Property(p => p.Valor).IsRequired();
                p.Property(p => p.TipoProduto).HasConversion<string>();
            });

            modelBuilder.Entity<Pedido>(p => {
                p.ToTable("Pedidos");
                p.HasKey(p => p.Id);
                p.Property(p => p.IniciadoEm).HasDefaultValue("GETDATE()").ValueGeneratedOnAdd();
                p.Property(p => p.Status).HasConversion<string>();
                p.Property(p => p.TipoFrete).HasConversion<int>();
                p.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");

                p.HasMany(p => p.Itens)
                 .WithOne(p => p.Pedido)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PedidoItem>(p => {
                p.ToTable("PedidoItens");
                p.HasKey(p => p.Id);
                p.Property(p => p.Quantidade).HasDefaultValue(0).IsRequired();
                p.Property(p => p.Valor).HasDefaultValue(0).IsRequired();
                p.Property(p => p.Desconto).HasDefaultValue(0).IsRequired();
            });
            */
        }
    }
}