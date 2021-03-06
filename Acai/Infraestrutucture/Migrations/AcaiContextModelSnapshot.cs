﻿// <auto-generated />
using System;
using Infraestrutucture;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestrutucture.Migrations
{
    [DbContext(typeof(AcaiContext))]
    partial class AcaiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Adicional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MinutosAdicionais")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorAdicionais")
                        .HasColumnType("Decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Adicionais");
                });

            modelBuilder.Entity("Domain.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSabor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdTamanho")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TempoTotal")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("Decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdSabor");

                    b.HasIndex("IdTamanho");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Domain.PedidoAdicional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdAdicional")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPedido")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdAdicional");

                    b.HasIndex("IdPedido");

                    b.ToTable("PedidoAdicional");
                });

            modelBuilder.Entity("Domain.Sabor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MinutosAdicionais")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sabores");
                });

            modelBuilder.Entity("Domain.Tamanho", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MinutosAdicionais")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("Decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Tamanhos");
                });

            modelBuilder.Entity("Domain.Pedido", b =>
                {
                    b.HasOne("Domain.Sabor", "Sabor")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdSabor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Tamanho", "Tamanho")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdTamanho")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.PedidoAdicional", b =>
                {
                    b.HasOne("Domain.Adicional", "Adicional")
                        .WithMany("PedidoAdicionais")
                        .HasForeignKey("IdAdicional")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Pedido", "Pedido")
                        .WithMany("PedidoAdicionais")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
