﻿// <auto-generated />
using System;
using MentoriaQuintaFeira2021.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MentoriaQuintaFeira2021.Migrations
{
    [DbContext(typeof(EFContext))]
    partial class EFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MentoriaQuintaFeira2021.Entities.Cliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Nome = "JOSE DA SILVA"
                        },
                        new
                        {
                            ID = 2,
                            Nome = "MARIA APARECIDA"
                        },
                        new
                        {
                            ID = 3,
                            Nome = "CARLOS ANDRE"
                        },
                        new
                        {
                            ID = 4,
                            Nome = "PAULO VELOSO"
                        },
                        new
                        {
                            ID = 5,
                            Nome = "SERGIO CABRAL"
                        });
                });

            modelBuilder.Entity("MentoriaQuintaFeira2021.Entities.Produto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Categoria = "BEBIDAS",
                            Descricao = "COCA COLA",
                            Quantidade = 100,
                            Valor = 3.50m
                        },
                        new
                        {
                            ID = 2,
                            Categoria = "BEBIDAS",
                            Descricao = "CERVEJA",
                            Quantidade = 100,
                            Valor = 7.50m
                        },
                        new
                        {
                            ID = 3,
                            Categoria = "BEBIDAS",
                            Descricao = "VINHO",
                            Quantidade = 100,
                            Valor = 13.50m
                        },
                        new
                        {
                            ID = 4,
                            Categoria = "BEBIDAS",
                            Descricao = "CACHAÇA",
                            Quantidade = 100,
                            Valor = 1.50m
                        },
                        new
                        {
                            ID = 5,
                            Categoria = "BISCOITO",
                            Descricao = "PASSATEMPO",
                            Quantidade = 100,
                            Valor = 3.50m
                        },
                        new
                        {
                            ID = 6,
                            Categoria = "BISCOITO",
                            Descricao = "BONO",
                            Quantidade = 100,
                            Valor = 3.50m
                        },
                        new
                        {
                            ID = 7,
                            Categoria = "LANCHES",
                            Descricao = "PIZZA",
                            Quantidade = 100,
                            Valor = 2.50m
                        },
                        new
                        {
                            ID = 8,
                            Categoria = "LANCHES",
                            Descricao = "COXINHA",
                            Quantidade = 100,
                            Valor = 1.00m
                        });
                });

            modelBuilder.Entity("MentoriaQuintaFeira2021.Entities.Venda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("MentoriaQuintaFeira2021.Entities.Venda", b =>
                {
                    b.HasOne("MentoriaQuintaFeira2021.Entities.Cliente", "Cliente")
                        .WithMany("Vendas")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MentoriaQuintaFeira2021.Entities.Produto", "Produto")
                        .WithMany("Vendas")
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("MentoriaQuintaFeira2021.Entities.Cliente", b =>
                {
                    b.Navigation("Vendas");
                });

            modelBuilder.Entity("MentoriaQuintaFeira2021.Entities.Produto", b =>
                {
                    b.Navigation("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}
