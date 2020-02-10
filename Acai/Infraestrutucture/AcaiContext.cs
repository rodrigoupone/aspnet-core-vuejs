using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestrutucture
{
    public class AcaiContext : DbContext
    {
        public AcaiContext(DbContextOptions<AcaiContext> options) : base(options)
        {
        }

        public DbSet<Adicional> Adicionais { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Sabor> Sabores { get; set; }
        public DbSet<Tamanho> Tamanhos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Adicional>().Property(c => c.ValorAdicionais).HasColumnType("Decimal(18,2)");

            builder.Entity<Tamanho>().Property(c => c.Valor).HasColumnType("Decimal(18,2)");

            builder.Entity<Pedido>().Property(c => c.ValorTotal).HasColumnType("Decimal(18,2)");

            builder.Entity<PedidoAdicional>()
             .HasOne(c => c.Pedido)
             .WithMany(c => c.PedidoAdicionais)
             .HasForeignKey(c => c.IdPedido);

            builder.Entity<PedidoAdicional>()
             .HasOne(c => c.Adicional)
             .WithMany(c => c.PedidoAdicionais)
             .HasForeignKey(c => c.IdAdicional);

        }
    }
}
