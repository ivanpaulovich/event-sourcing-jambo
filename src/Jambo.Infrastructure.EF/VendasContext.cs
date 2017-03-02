using Jambo.Infrastructure.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jambo.Infrastructure.EF
{
    public class VendasContext : DbContext
    {
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Lote> Lotes { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }

        public VendasContext(DbContextOptions<VendasContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID).ValueGeneratedNever();
                entity.Property(e => e.Titulo).HasColumnType("varchar(100)");
                entity.Property(e => e.Descricao).HasColumnType("varchar(500)");
                entity.Property(e => e.DataRealizacao);

                entity.ToTable("Eventos");
            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID).ValueGeneratedNever();
                entity.Property(e => e.IDEvento);
                entity.Property(e => e.Quantidade);
                entity.Property(e => e.DataLimite);

                entity.HasOne(d => d.EventoNavigation)
                    .WithMany(p => p.LotesNavigation)
                    .HasForeignKey(d => d.IDEvento);

                entity.ToTable("Lotes");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID).ValueGeneratedNever();
                entity.Property(e => e.IDLote);
                entity.Property(e => e.DataEmissao);

                entity.HasOne(d => d.LoteNavigation)
                    .WithMany(p => p.PedidosNavigation)
                    .HasForeignKey(d => d.IDLote);

                entity.ToTable("Pedidos");
            });
        }
    }
}
